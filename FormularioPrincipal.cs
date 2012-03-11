using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Digitalizador
{
    
    public partial class FormularioPrincipal : Form
    {
        Modulacion.CreadorCurvas cs = new Modulacion.CreadorCurvas();
        int longitudOnda; //longitud de Onda de las curvas
        Random generador = new Random(); //Para crear curvas aleatorias
        PointF[] curvaAleatoria;
        Pen lapiz = new Pen(Color.Black);
        int deltaX = 5; //Desplazamiento a la derecha de la onda (para ver mejor)
        int numTrozosAleatorios = 5;
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {
            Color colorFondoPaneles = Color.Silver;
            panelCurvaAnalogica.BackColor = colorFondoPaneles;
            panelCurvaDigital.BackColor = colorFondoPaneles;
            panelCurvaDigital.BorderStyle = BorderStyle.FixedSingle;
            panelCurvaAnalogica.BorderStyle = BorderStyle.FixedSingle;
            longitudOnda = panelCurvaAnalogica.Width/numTrozosAleatorios;
            crearCurvaAleatoria();
            dibujarCurvaAleatoria();
        }

        private PointF[] concatenar(PointF[] trozo1, PointF[] trozo2)
        {
            PointF[] vectorSuma = new PointF[trozo1.Length + trozo2.Length];
            trozo1.CopyTo(vectorSuma, 0);
            trozo2.CopyTo(vectorSuma, trozo1.Length);
            return vectorSuma;

        }
        private void crearCurvaAleatoria()
        {
            int frecMinima = 1;
            int frecMaxima = 4;
            int amplitudMinima = 15;
            
            int ultimoX; //No se usa el valor devuelto por el creador
            int amplitudMaxima = panelCurvaAnalogica.Height / 2;

            int frecuenciaAleatoria = generador.Next(frecMinima, frecMaxima); ;
            int amplitudAleatoria = generador.Next(amplitudMinima, amplitudMaxima);

            PointF[] trozoAleatorio;
            curvaAleatoria = cs.crearCurva(amplitudAleatoria, deltaX,
                    frecuenciaAleatoria, 0, longitudOnda, out ultimoX);

            for (int ii = 0; ii < numTrozosAleatorios-1; ii++)
            {
                frecuenciaAleatoria= generador.Next(frecMinima, frecMaxima); ;
                amplitudAleatoria = generador.Next(amplitudMinima, amplitudMaxima);
                
                trozoAleatorio = cs.crearCurva(amplitudAleatoria, 0, 
                    frecuenciaAleatoria,ultimoX, longitudOnda, out ultimoX);
                curvaAleatoria = concatenar(curvaAleatoria, trozoAleatorio);
            }
            //curvaAleatoria = cs.crearCurva(amplitudMaxima, 0, frecuencia, deltaX, longitudOnda, out ultimoX);
        }

        private void dibujarCurvaAleatoria()
        {
            Graphics dc = panelCurvaAnalogica.CreateGraphics();
            borrarPanel(panelCurvaAnalogica);
            dc.TranslateTransform(0, (int)(panelCurvaAnalogica.Height / 2));
            dc.DrawCurve(lapiz, curvaAleatoria);
        }
        private int calcularMuestras()
        {
            double valorSeleccionado = System.Convert.ToDouble(spnBitsMuestreo.Value);
            int numMuestras = (int)Math.Pow(2, valorSeleccionado);
            return numMuestras;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            crearCurvaAleatoria();
            dibujarCurvaAleatoria();
            redibujarCurvaDigital();
        }
        private void redibujarCurvaDigital()
        {
            int numMuestras = calcularMuestras();
   
            PointF[] curvaDigitalizada = digitalizar(curvaAleatoria, numMuestras);

            int numBits = System.Convert.ToInt32(spnBitsMuestreo.Value);
            string cadInformativa = numMuestras + " muestras";
            cadInformativa += " (" + numBits + " bits)";
            int bitsTotalesCurvaDigital = curvaDigitalizada.Length * numBits;
            cadInformativa += ". Memoria necesaria:" + bitsTotalesCurvaDigital + " bits.";
            lblInformacion.Text = cadInformativa;

            dibujarCurvaDigital(curvaDigitalizada);
        }

        private void borrarPanel(Panel panel)
        {
            Graphics dc = panel.CreateGraphics();
            Color colorFondo = panel.BackColor;
            dc.Clear(colorFondo);

        }


        //Calcula los puntos intermedios y los devuelve
        private PointF[] duplicarMuestras(PointF[] curva)
        {
            int longitudNuevaCurva = (curva.Length * 2)-1;
            
            PointF[] senialMejorada = new PointF[longitudNuevaCurva];
            int pos = 0;
            int posAnterior = 0;
            int posSiguiente = 1;
            while (pos < senialMejorada.Length)
            {
                //Los puntos pares son los mismos de la curva
                if ((pos % 2) == 0)
                {
                    senialMejorada[pos] = curva[posAnterior];
                }
                else
                {
                    PointF puntoAnterior = curva[posAnterior++];
                    PointF puntoSiguiente = curva[posSiguiente++];
                    PointF puntoIntermedio = new PointF();
                    puntoIntermedio.X=(puntoAnterior.X + puntoSiguiente.X)/2;
                    puntoIntermedio.Y=(puntoAnterior.Y + puntoSiguiente.Y)/2;
                    senialMejorada[pos] = puntoIntermedio;
                }
                pos++;
            }
            return senialMejorada;
        }
        ///Crea una secuencia de puntos que permita dibujar
        ///la curva de forma digital. Lo que se hace es
        ///remuestrear la señal una y otra vez, interpolando puntos
        ///hasta que se alcanza el grado de mejora;
        private PointF[] digitalizar(PointF[] curva, int numMuestras)
        {
            PointF[] curvaParaDevolver = (PointF[])curva.Clone(); ;
            if (numMuestras == curva.Length)
            {
                return curva;
            }
            //Al principio toda curva tiene cuatro puntos;
            int gradoMejora = 4;
            while (gradoMejora != numMuestras)
            {
                curvaParaDevolver = duplicarMuestras(curvaParaDevolver);
                gradoMejora *= 2;
            }
            return curvaParaDevolver;

        }
        private void dibujarCurvaDigital(PointF[] curvaDigital)
        {
            borrarPanel(panelCurvaDigital);
            Graphics dc = panelCurvaDigital.CreateGraphics();
            dc.TranslateTransform(0, (int)panelCurvaDigital.Height / 2);
            int posPuntoActual = 0;
            int posPuntoSiguiente = 1;
            PointF puntoActual;
            PointF puntoIntermedio;
            PointF puntoSiguiente;

            while (posPuntoSiguiente != curvaDigital.Length)
            {
                puntoActual = curvaDigital[posPuntoActual];
                puntoSiguiente = curvaDigital[posPuntoSiguiente];

                puntoIntermedio = new PointF(puntoActual.X, puntoSiguiente.Y);

                dc.DrawLine(lapiz, puntoActual, puntoIntermedio);
                dc.DrawLine(lapiz, puntoIntermedio, puntoSiguiente);

                posPuntoActual++;
                posPuntoSiguiente++;
            }
        } //Fin del metodo

        private void cmbNumMuestras_SelectedIndexChanged(object sender, EventArgs e)
        {
            redibujarCurvaDigital();
        }

        private void FormularioPrincipal_Paint(object sender, PaintEventArgs e)
        {
            dibujarCurvaAleatoria();
            redibujarCurvaDigital();

        }

        private void spnBitsMuestreo_ValueChanged(object sender, EventArgs e)
        {
            redibujarCurvaDigital();
        }
    }
}
