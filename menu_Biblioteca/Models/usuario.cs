using System;

namespace system_books.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            Activo = true;
        }

        public Usuario(int id, string nombre, string email)
        {
            Id = id;
            Nombre = nombre;
            Email = email;
            Activo = true;
        }

        public string ResumenCorto()
        {
            return $"Usuario: {Nombre}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nNombre: {Nombre}\nEmail: {Email}\nActivo: {Activo}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}