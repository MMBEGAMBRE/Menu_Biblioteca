using System;
using System.Collections.Generic;
using System.Linq;
using system_books.Models;

namespace system_books.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public void AgregarUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public bool EliminarUsuario(string documento)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Documento == documento);

            if (usuario != null)
            {
                usuarios.Remove(usuario);
                return true;
            }

            return false;
        }

        public List<Usuario> ObtenerTodos()
        {
            return usuarios;
        }

        public Usuario BuscarPorDocumento(string documento)
        {
            return usuarios.FirstOrDefault(u => u.Documento == documento);
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            return usuarios
                .Where(u => u.Nombre.ToLower().Contains(nombre.ToLower()))
                .ToList();
        }

        public List<Usuario> OrdenarPorNombre()
        {
            return usuarios.OrderBy(u => u.Nombre).ToList();
        }

        public int TotalUsuarios()
        {
            return usuarios.Count;
        }

        public (int activos, int inactivos) UsuariosPorEstado()
        {
            int activos = usuarios.Count(u => u.Activo == true);
            int inactivos = usuarios.Count(u => u.Activo == false);

            return (activos, inactivos);
        }
    }
}