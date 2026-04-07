using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaMenu.Models;

namespace BibliotecaMenu.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private int nextId = 1;

        public void AgregarUsuario(Usuario usuario)
        {
            usuario.Id = nextId++;
            usuarios.Add(usuario);
        }

        public List<Usuario> ObtenerUsuarios() => usuarios;

        public List<Usuario> ObtenerActivos()   => usuarios.Where(u => u.Activo).ToList();

        public List<Usuario> ObtenerInactivos() => usuarios.Where(u => !u.Activo).ToList();

        public Usuario BuscarPorId(int id) => usuarios.FirstOrDefault(u => u.Id == id);

        public List<Usuario> BuscarPorNombre(string texto) =>
            usuarios.Where(u => u.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)).ToList();

        public bool EliminarUsuario(int id)
        {
            var usuario = BuscarPorId(id);
            if (usuario == null) return false;
            usuarios.Remove(usuario);
            return true;
        }

        public bool ActualizarNombre(int id, string nombre)
        {
            var u = BuscarPorId(id);
            if (u == null) return false;
            u.Nombre = nombre;
            return true;
        }

        public bool ActualizarContacto(int id, string contacto)
        {
            var u = BuscarPorId(id);
            if (u == null) return false;
            u.Contacto = contacto;
            return true;
        }

        public bool ToggleActivo(int id)
        {
            var u = BuscarPorId(id);
            if (u == null) return false;
            u.Activo = !u.Activo;
            return true;
        }

        public List<Usuario> OrdenarPorNombre() => usuarios.OrderBy(u => u.Nombre).ToList();

        // KPIs
        public int TotalUsuarios()   => usuarios.Count;
        public int TotalActivos()    => usuarios.Count(u => u.Activo);
        public int TotalInactivos()  => usuarios.Count(u => !u.Activo);
    }
}