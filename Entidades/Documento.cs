using System.Text;

namespace Entidades
{

    public abstract class Documento
    {
        public enum Paso

        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        private int anio;
        private string autor;
        private string barCode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;

        //Constructor de la clase Documento
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barCode)
        {
            this.anio = anio;
            this.autor = autor;
            this.barCode = barCode;
            this.numNormalizado = numNormalizado;
            this.titulo = titulo;
            this.estado = Paso.Inicio;
        }

        // GETTERS => Propiedades sólo de lectura
        public int Anio
        {
            get => this.anio;
        }

        public string Autor
        {
            get => this.autor;
        }
        public string BarCode
        {
            get => this.barCode;
        }

        public Paso Estado
        {
            get => this.estado;
        }

        protected string NumNormalizado
        {
            get => this.numNormalizado;
        }

        public string Titulo
        {
            get => this.titulo;
        }

        // Avanza el estado del documento al siguiente paso
        public bool AvanzarEstado()
        {
            if (this.estado == Paso.Terminado)
            {
                return false;
            }
            else
            {
                this.estado += 1;
                return true;
            }
        }

        // Método ToString() sobrescrito para proporcionar una representación legible del objeto Documento
        // Devuelve una cadena formateada que incluye el título, autor, año y código de barras del documento
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Título: {titulo}");
            sb.AppendLine($"Autor: {autor}");
            sb.AppendLine($"Año: {anio}");
            sb.AppendLine($"Cód. de barras: {barCode}");
            return sb.ToString();
        }
    }
}