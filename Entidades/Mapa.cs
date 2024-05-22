using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        private int alto;
        private int ancho;

        //Constructor de la SubClase Mapa
        //Utiliza excepciones
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string barCode, int ancho, int alto)
            : base(titulo, autor, anio, "", barCode)
        {
            // Validar que el ancho y el alto sean mayores que cero
            if (ancho <= 0)
            {
                throw new ArgumentException("El ancho del mapa debe ser mayor que cero.");
            }

            if (alto <= 0)
            {
                throw new ArgumentException("El alto del mapa debe ser mayor que cero.");
            }

            this.alto = alto;
            this.ancho = ancho;
        }

        //Propiedades de sólo lectura
        public int Alto
        {
            get => this.alto;
        }
        public int Ancho
        {
            get => this.ancho;
        }
        // Obtiene la superficie del mapa (alto * ancho)
        public int Superficie
        {
            get => Alto * Ancho;
        }

        // Sobrecarga de operadores

        // Comprueba si dos mapas son iguales
        public static bool operator ==(Mapa m1, Mapa m2)
        {
            return m1.BarCode == m2.BarCode
                || (m1.Titulo == m2.Titulo && m1.Autor == m2.Autor
                && m1.Anio == m2.Anio && m1.Superficie == m2.Superficie);
        }

        // Comprueba si dos mapas son diferentes
        public static bool operator !=(Mapa m1, Mapa m2)
        {
            return !(m1 == m2);
        }


        // Sobrescritura de método ToString

        // Devuelve una representación en formato de cadena del mapa
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            sb.AppendLine($"Superficie: {Alto} * {Ancho} = {Superficie} cm2.");
            return sb.ToString();
        }
    }
}