using System;

namespace system_books.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro LibroPrestado { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public bool Devuelto { get; set; }

        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            Devuelto = false;
        }

        public Prestamo(int id, Libro libro, Usuario usuario)
        {
            Id = id;
            LibroPrestado = libro;
            Usuario = usuario;
            FechaPrestamo = DateTime.Now;
            Devuelto = false;
        }

        public string Detalle()
        {
            return $"ID: {Id}\nLibro: {LibroPrestado?.Titulo}\nUsuario: {Usuario?.Nombre}\nFecha: {FechaPrestamo}\nDevuelto: {Devuelto}";
        }

        public override string ToString()
        {
            return Detalle();
        }
    }
}
