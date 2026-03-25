using System;

namespace system_books.Models
{
    public class Libro
    {
        // Propiedades
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; }

        // Constructor vacío
        public Libro()
        {
            Disponible = true;
        }

        // Constructor completo
        public Libro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Disponible = true;
        }

        // Método resumen
        public string ResumenCorto()
        {
            return $"Libro: {Titulo} - Disponible: {Disponible}";
        }

        // Método detalle
        public string DetalleCompleto()
        {
            return $"ID: {Id}, Título: {Titulo}, Autor: {Autor}, Disponible: {Disponible}";
        }

        // Método ToString
        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}