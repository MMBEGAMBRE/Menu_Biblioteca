using System;
using System.Collections.Generic;
using System.Linq;
using system_books.Models;

public class PrestamoService
{
    private List<Prestamo> prestamos = new List<Prestamo>();

    // AGREGAR
    public void AgregarPrestamo(Prestamo prestamo)
    {
        prestamos.Add(prestamo);
    }

    // OBTENER TODOS
    public List<Prestamo> ObtenerTodos()
    {
        return prestamos;
    }

    // ELIMINAR
    public bool EliminarPrestamo(int id)
    {
        var prestamo = prestamos.FirstOrDefault(p => p.Id == id);
        if (prestamo != null)
        {
            prestamos.Remove(prestamo);
            return true;
        }
        return false;
    }

    // BUSCAR POR ID
    public Prestamo BuscarPorId(int id)
    {
        return prestamos.FirstOrDefault(p => p.Id == id);
    }

    // BUSCAR POR ESTADO
    public List<Prestamo> BuscarPorEstado(EstadoPrestamo estado)
   {
    return prestamos.Where(p => p.Estado == estado).ToList();
}

    // ORDENAR POR FECHA DE DEVOLUCIÓN
    public List<Prestamo> OrdenarPorFechaLimite()
    {
        return prestamos.OrderBy(p => p.FechaDevolucion).ToList();
    }


    // KPIs 
  

    public int TotalPrestamos()
    {
        return prestamos.Count;
    }

    public int PrestamosActivos()
    {
        return prestamos.Count(p => p.Estado.ToString() == "Activo");
    }

    public int PrestamosDevueltos()
    {
        return prestamos.Count(p => p.Estado.ToString() == "Devuelto");
    }

     public int PrestamosVencidos()
     {
       return prestamos.Count(p => p.EstaVencido());
     }

    // PROMEDIO DE DÍAS
      public double PromedioDiasPrestamo()
     {
      if (prestamos.Count == 0) return 0;

      return prestamos.Average(p => p.DiasTranscurridos());
     }
}