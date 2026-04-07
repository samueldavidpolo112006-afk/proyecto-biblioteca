using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();
        private int nextId = 1;

        public void AgregarLibro(Libro libro)
        {
            libro.Id = nextId++;
            libros.Add(libro);
        }

        public List<Libro> ObtenerLibros() => libros;

        public List<Libro> ObtenerDisponibles() => libros.Where(l => l.Disponible).ToList();

        public List<Libro> ObtenerPrestados() => libros.Where(l => !l.Disponible).ToList();

        public Libro BuscarPorId(int id) => libros.FirstOrDefault(l => l.Id == id);

        public List<Libro> BuscarPorTitulo(string texto) =>
            libros.Where(l => l.Titulo.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

        public List<Libro> BuscarPorAutor(string texto) =>
            libros.Where(l => l.Autor.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

        public bool EliminarLibro(int id)
        {
            var libro = BuscarPorId(id);
            if (libro == null || !libro.Disponible) return false;
            libros.Remove(libro);
            return true;
        }

        public bool ActualizarLibro(int id, string titulo, string autor, int anio, string categoria)
        {
            var libro = BuscarPorId(id);
            if (libro == null) return false;
            libro.Titulo    = titulo;
            libro.Autor     = autor;
            libro.Anio      = anio;
            libro.Categoria = categoria;
            return true;
        }

        public List<Libro> OrdenarPorTitulo() => libros.OrderBy(l => l.Titulo).ToList();

        public List<Libro> OrdenarPorAnio() => libros.OrderBy(l => l.Anio).ToList();

        // KPIs
        public int TotalLibros()       => libros.Count;
        public int TotalDisponibles()  => libros.Count(l => l.Disponible);
        public int TotalPrestados()    => libros.Count(l => !l.Disponible);
    }
}