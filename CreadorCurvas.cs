using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace Modulacion
{
    class CreadorCurvas
    {
        int alturaMaxima;
        int anchuraMaxima;
        int numPuntosPorCurva = 5;
        public CreadorCurvas()
        {
        }
        public void setAlturaMaxima(int altMaxima)
        {
            alturaMaxima = altMaxima;
        }
        public void setAnchuraMaxima(int anchoMaximo)
        {
            anchuraMaxima = anchoMaximo;
        }
        public void setDimensiones(int ancho, int alto)
        {
            setAlturaMaxima(alto);
            setAnchuraMaxima(ancho);
        }
        public CreadorCurvas(int altMaxima, int anchoMaximo)
        {
            alturaMaxima=altMaxima;
            anchuraMaxima=anchoMaximo;
        }
        /// <summary>
        /// Crea una curva que representa una señal
        /// </summary>
        /// <param name="amplitud">Altura de la señal</param>
        /// <param name="radianesIniciales">Fase donde se comienza a dibujar</param>
        /// <param name="hercios">Número de ondas por segundo</param>
        /// <param name="zoomX">Multiplicador de zoom</param>
        /// <param name="xOrigen">Punto x de origen</param>
        /// <returns></returns>
        public PointF[] crearCurva(float amplitud, float radianesIniciales, int hercios, int deltaX, int longitudOnda, out int ultimoX)
        {
            int numPuntosCurva = numPuntosPorCurva;
            int numPuntos = (numPuntosCurva * hercios) ;
            PointF[] puntos;
            puntos = new PointF[numPuntos];
            float delta = (float)(Math.PI * 2) / (numPuntosCurva-1);
            float deltaLongitudOnda = longitudOnda / numPuntos;
            float contadorRadianes = radianesIniciales;
            int ultimoPunto=0;
            for (int contadorPuntos = 0; contadorPuntos < numPuntos; contadorPuntos++)
            {
                puntos[contadorPuntos].X = (contadorRadianes) / hercios;
                puntos[contadorPuntos].X = puntos[contadorPuntos].X +deltaX+(deltaLongitudOnda*contadorPuntos);
                ultimoPunto = (int)puntos[contadorPuntos].X;
                puntos[contadorPuntos].Y = (float)(amplitud * Math.Sin(contadorRadianes));
                puntos[contadorPuntos].Y = -puntos[contadorPuntos].Y;
                contadorRadianes += delta;
                ;
            }
            ultimoX = ultimoPunto;
            return puntos;
        }

        /// <summary>
        /// Se calcula las distintas alturas que puede tener una señal
        /// modulada en amplitud. Se utiliza para despues dibujar
        /// las curvas AM con distintas alturas.
        /// </summary>
        /// <param name="numAmplitudes"></param>
        /// <returns></returns>
        private float[] crearAmplitudes(int numAmplitudes)
        {
            int alturaMinima=20;
            float [] vectorAmplitudes = new float[numAmplitudes];
            float saltoAmplitud = (alturaMaxima-alturaMinima) / numAmplitudes;
            float altura = alturaMinima;
            for (int pos = 0; pos < numAmplitudes; pos++)
            {
                vectorAmplitudes[pos] = altura;
                altura = altura + saltoAmplitud;
            }
            return vectorAmplitudes;
        }

        /// <summary>
        /// Si la cadena binaria no tiene un mínimo, se añaden ceros por la izquieda
        /// </summary>
        /// <param name="numNiveles"></param>
        /// <param name="cadenaBinaria"></param>
        /// <returns></returns>
        public string ajustaCadenaBinaria(int numNiveles, string cadenaBinaria)
        {
            string cadCeros = "";
            int longitudBloque = (int) Math.Log(numNiveles, 2);

            if (longitudBloque > cadenaBinaria.Length)
            {
                int contadorInicial;
                for (contadorInicial = cadenaBinaria.Length; contadorInicial < longitudBloque; contadorInicial++)
                {
                    cadCeros += "0";
                }
                return cadCeros + cadenaBinaria;
            }
            int resto = cadenaBinaria.Length % longitudBloque;
            
            if (resto != 0)
            {
                for (int pos=0; pos<longitudBloque-resto; pos++)
                {
                    cadCeros="0"+cadCeros;
                }
            }
            return cadCeros + cadenaBinaria;
        }
        private int numEstadosModulacion(int numNiveles, string cadBinaria)
        {
            return (int)(cadBinaria.Length / numNiveles);
        }
        
    }
}
