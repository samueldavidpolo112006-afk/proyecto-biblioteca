using System;

namespace system_books.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            Activo = true;
        }

        public Usuario(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Activo = true;
        }

        public string ResumenCorto()
        {
            return $"Usuario: {Nombre} - Activo: {Activo}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}, Nombre: {Nombre}, Activo: {Activo}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}