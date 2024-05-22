using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro,
            mapa
        }
        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;

        // Constructor de la clase Escaner que inicializa sus propiedades
        //Utiliza excepciones
        public Escaner(string marca, TipoDoc tipo)
        {
            // Validar que la marca no sea nula o vacía
            if (string.IsNullOrEmpty(marca))
            {
                throw new ArgumentException("La marca del escáner no puede ser nula o vacía.");
            }

            // Asignar la marca y el tipo del escáner
            this.tipo = tipo;
            this.marca = marca;
            // Inicializar la lista de documentos del escáner
            this.listaDocumentos = new List<Documento>();

            // Asignar el departamento según el tipo de documentos que puede escanear el escáner
            if (tipo == TipoDoc.mapa)
            {
                this.locacion = Departamento.mapoteca;
            }
            else if (tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
        }

        // Propiedades de solo lectura para acceder a la lista de documentos, la locación, la marca y el tipo del escáner
        public List<Documento> ListaDocumentos
        {
            get => this.listaDocumentos;
        }

        public Departamento Locacion
        {
            get => this.locacion;
        }

        public string Marca
        {
            get => this.marca;
        }

        public TipoDoc Tipo
        {
            get => this.tipo;
        }


        // Sobrecarga del operador de igualdad ==
        // Comprueba si un documento está presente en la lista de documentos del escáner
        public static bool operator ==(Escaner e, Documento d)
        {
            return e.ListaDocumentos.Contains(d);
        }

        // Sobrecarga del operador de desigualdad !=
        // Comprueba si un documento no está presente en la lista de documentos del escáner
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e == d);
        }

        // Sobrecarga del operador + para agregar un documento al escáner
        // Verifica si el documento es del tipo que puede escanear el escáner y si no está ya presente en la lista de documentos
        // Si el documento está en estado "Inicio", lo agrega a la lista de documentos del escáner y avanza su estado
        public static bool operator +(Escaner e, Documento d)
        {
            if ((e.Tipo == TipoDoc.libro && d is Libro) || (e.Tipo == TipoDoc.mapa && d is Mapa))
            {
                // Verificar si el documento ya está en la lista del escáner
                foreach (Documento documento in e.ListaDocumentos)
                {

                    // Si el documento es un libro o mapa y es igual al nuevo documento, no se agrega
                    if ((documento is Libro && d is Libro && (Libro)documento == (Libro)d) ||
                        (documento is Mapa && d is Mapa && (Mapa)documento == (Mapa)d))
                    {
                        return false;
                    }
                }

                // Si el documento no está en la lista y está en estado "Inicio", se agrega al escáner
                if (d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado(); // Avanza el estado antes de añadirlo
                    e.ListaDocumentos.Add(d);
                    return true;
                }
            }
            return false;
        }

        // Método para cambiar el estado de un documento presente en la lista de documentos del escáner
        // Retorna true si se cambia correctamente el estado del documento, false en caso contrario
        public bool CambiarEstadoDocumento(Documento d)
        {
            if (d is null)
            {
                return false;
            }
            foreach (Documento doc in ListaDocumentos)
            {
                if (doc == d)
                {
                    return doc.AvanzarEstado();
                }
            }
            return false;
        }
    }
}

