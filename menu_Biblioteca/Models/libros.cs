using System;

namespace system_books.Models
{
    public class Libro
    {
        // PROPIEDADES
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public bool Disponible { get; set; }

        // CONSTRUCTOR VACÍO
        public Libro()
        {
            Disponible = true;
        }

        // CONSTRUCTOR COMPLETO
        public Libro(int id, string titulo, string autor)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Disponible = true;
        }

        // MÉTODOS
        public string ResumenCorto()
        {
            return $"Libro: {Titulo} - {Autor}";
        }

        public string DetalleCompleto()
        {
            return $"ID: {Id}\nTitulo: {Titulo}\nAutor: {Autor}\nDisponible: {Disponible}";
        }

        public override string ToString()
        {
            return DetalleCompleto();
        }
    }
}