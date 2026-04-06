using System;
using System.Collections.Generic;
using system_books.Models; 

namespace system_books.Services
{
    public class LibroService
    {
        private List<Libro> libros = new List<Libro>();

        // AGREGAR
        public void AgregarLibro(Libro libro)
        {
            libros.Add(libro);
        }

        // OBTENER TODOS
        public List<Libro> ObtenerLibros()
        {
            return libros;
        }

        // ELIMINAR
       public void EliminarLibro(int id)
{
    libros.RemoveAll(l => l.Id == id);
}

        // BUSCAR POR ID  
     public Libro BuscarPorId(int id)
{
    return libros.Find(l => l.Id == id);
}
        // ORDENAR POR TITULO
        public List<Libro> OrdenarPorTitulo()
        {
            return libros.OrderBy(l => l.Titulo).ToList();
        }

        // KPI: TOTAL LIBROS
        public int TotalLibros()
        {
            return libros.Count;
        }

        // KPI: DISPONIBLES
        public int LibrosDisponibles()
        {
            return libros.Count(l => l.Disponible == true);
        }

        // KPI: PRESTADOS
        public int LibrosPrestados()
        {
            return libros.Count(l => l.Disponible == false);
        }
    }
}