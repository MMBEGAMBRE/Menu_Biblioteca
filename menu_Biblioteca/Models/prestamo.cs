using System;

namespace system_books.Models
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro LibroPrestado { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime? FechaDevolucion { get; set; }
        public EstadoPrestamo Estado { get; set; }

        public Prestamo()
        {
            FechaPrestamo = DateTime.Now;
            Estado = EstadoPrestamo.Activo;
        }

        public Prestamo(int id, Libro libro, Usuario usuario)
        {
            Id = id;
            LibroPrestado = libro;
            Usuario = usuario;
            FechaPrestamo = DateTime.Now;
            Estado = EstadoPrestamo.Activo;
        }

        public bool EstaVencido()
        {
            return (DateTime.Now - FechaPrestamo).Days > 7;
        }

        public int DiasTranscurridos()
        {
            return (DateTime.Now - FechaPrestamo).Days;
        }

        public string ResumenCorto()
        {
            return $"Préstamo {Id}: {LibroPrestado?.Titulo} - {Usuario?.Nombre}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nLibro: {LibroPrestado?.Titulo}\nUsuario: {Usuario?.Nombre}\nFecha: {FechaPrestamo}\nEstado: {Estado}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}