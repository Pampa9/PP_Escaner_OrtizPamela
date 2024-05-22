using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        private int numPaginas;

        //Constructor de la SubClase Libro
        //Utiliza excepciones
        public Libro(string titulo, string autor, int anio, string numNormalizado, string barCode, int numPaginas) : base(titulo, autor, anio, numNormalizado, barCode)
        {
            // Validar que el título no sea nulo o vacío
            if (string.IsNullOrEmpty(titulo))
            {
                throw new ArgumentException("El título del libro no puede ser nulo o vacío.");
            }

            // Validar que el autor no sea nulo o vacío
            if (string.IsNullOrEmpty(autor))
            {
                throw new ArgumentException("El autor del libro no puede ser nulo o vacío.");
            }

            // Validar que el número de páginas sea mayor que cero
            if (numPaginas <= 0)
            {
                throw new ArgumentException("El número de páginas del libro debe ser mayor que cero.");
            }

            // Asignar el número de páginas
            this.numPaginas = numPaginas;
        }


        // Propiedades de solo lectura 
        public string ISBN
        {
            get => NumNormalizado;
        }

        public int NumPaginas
        {
            get => numPaginas;
        }


        // Sobrecarga de operadores

        // Comprueba si dos libros son iguales
        public static bool operator ==(Libro l1, Libro l2)
        {
            return l1.BarCode == l2.BarCode
                || l1.ISBN == l2.ISBN
                || (l1.Titulo == l2.Titulo && l1.Autor == l2.Autor);
        }

        // Comprueba si dos libros son diferentes
        public static bool operator !=(Libro l1, Libro l2)
        {
            return !(l1 == l2);
        }

        // Sobrescritura de método ToString

        // Devuelve una representación en formato de cadena del libro
        public override string ToString()
        {
            string baseString = base.ToString();
            StringBuilder sb = new StringBuilder(baseString);

            // Agregamos la información del ISBN antes del código de barras
            sb.Insert(baseString.IndexOf("Cód. de barras:"), $"ISBN: {ISBN}\n");

            // Agregamos la información del número de páginas después del código de barras
            sb.AppendLine($"Numero de páginas: {NumPaginas}");

            // Retornamos la representación completa del libro
            return sb.ToString();
        }

    }
}
