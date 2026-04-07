using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class PrestamoService
    {
        private List<Prestamo> prestamos = new List<Prestamo>();
        private int nextId = 1;

        public void AgregarPrestamo(Prestamo prestamo)
        {
            prestamo.Id = nextId++;
            prestamo.Libro.Disponible = false;
            prestamos.Add(prestamo);
        }

        public List<Prestamo> ObtenerPrestamos() => prestamos;

        public List<Prestamo> ObtenerActivos() =>
            prestamos.Where(p => p.Estado == EstadoPrestamo.Activo).ToList();

        public List<Prestamo> ObtenerDevueltos() =>
            prestamos.Where(p => p.Estado == EstadoPrestamo.Devuelto).ToList();

        public List<Prestamo> ObtenerVencidos() =>
            prestamos.Where(p => p.EstaVencido()).ToList();

        public Prestamo BuscarPorId(int id) => prestamos.FirstOrDefault(p => p.Id == id);

        public bool RegistrarDevolucion(int id)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo == null || prestamo.Estado == EstadoPrestamo.Devuelto) return false;
            prestamo.Estado          = EstadoPrestamo.Devuelto;
            prestamo.FechaDevolucion = DateTime.Now;
            prestamo.Libro.Disponible = true;
            return true;
        }

        public bool EliminarPrestamo(int id)
        {
            var prestamo = BuscarPorId(id);
            if (prestamo == null) return false;
            prestamos.Remove(prestamo);
            return true;
        }

        public List<Prestamo> OrdenarPorFechaLimite() =>
            prestamos.OrderBy(p => p.FechaLimite).ToList();

        // KPIs
        public int TotalPrestamos()   => prestamos.Count;
        public int TotalActivos()     => prestamos.Count(p => p.Estado == EstadoPrestamo.Activo);
        public int TotalDevueltos()   => prestamos.Count(p => p.Estado == EstadoPrestamo.Devuelto);
        public int TotalVencidos()    => prestamos.Count(p => p.EstaVencido());

        public double PromedioDiasPrestamo()
        {
            if (!prestamos.Any()) return 0;
            return prestamos.Average(p => p.DiasTranscurridos());
        }
    }
}