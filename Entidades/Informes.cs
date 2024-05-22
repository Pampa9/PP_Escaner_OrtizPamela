using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Informes
    {
        // Método estático que muestra los documentos distribuidos desde el escáner
        // Calcula la extensión total de los documentos distribuidos, la cantidad de documentos distribuidos y un resumen de los mismos
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        // Método interno que muestra los documentos en un estado específico
        // Calcula la extensión total, la cantidad de documentos y un resumen de los mismos para un estado dado
        private static void MostrarDocumentosPorEstado(Escaner e, Documento.Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";

            foreach (Documento doc in e.ListaDocumentos)
            {
                if (doc.Estado == estado)
                {
                    if (doc is Libro libro)
                    {
                        extension += libro.NumPaginas;
                    }
                    else if (doc is Mapa mapa)
                    {
                        extension += mapa.Superficie;
                    }

                    cantidad++;
                    resumen += $"{doc.Titulo}, {doc.Autor}, {doc.Anio}\n";
                }
            }
        }

        // Método estático que muestra los documentos en estado "EnEscaner"
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnEscaner, out extension, out cantidad, out resumen);
        }

        // Método estático que muestra los documentos en estado "EnRevision"
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.EnRevision, out extension, out cantidad, out resumen);
        }

        // Método estático que muestra los documentos en estado "Terminado"
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Documento.Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
}
