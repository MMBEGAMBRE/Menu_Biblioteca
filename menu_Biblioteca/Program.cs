using System;
using System.Linq;
using System.Collections.Generic;
using system_books.Models;
using system_books.Services;


namespace menu_Biblioteca;

class Program
{
    static LibroService libroService = new LibroService();
    static UsuarioService usuarioService = new UsuarioService();

    static List<Libro> LibrosPrueba = new List<Libro>(); // 
    
    static List<Prestamo> PrestamosPrueba = new List<Prestamo>();

    static void Main(string[] args)
    {
        InicializarObjetosPrueba();

       // PASAR DATOS DE PRUEBA AL SERVICE
foreach (var libro in LibrosPrueba)
{
    libroService.AgregarLibro(libro);
}

// PRUEBA LIBROSERVICE
Console.WriteLine("=== PRUEBA LIBROSERVICE ===");
Console.WriteLine("Total libros: " + libroService.TotalLibros());
Console.WriteLine("Disponibles: " + libroService.LibrosDisponibles());
Console.WriteLine("Prestados: " + libroService.LibrosPrestados());
Console.WriteLine("============================\n");

        ShowMainMenu();
    }


    
    static void InicializarObjetosPrueba()
    {
        // libros de prueba, usan el constructor de Libro que tú tienes: (id, titulo, autor)
        LibrosPrueba.Add(new Libro(1, "Cien años de soledad", "Gabriel García Márquez"));
        LibrosPrueba.Add(new Libro(2, "El principito", "Antoine de Saint-Exupéry") { Disponible = false });

        usuarioService.AgregarUsuario(new Usuario(1, "María López", "maria@correo.com"));
        usuarioService.AgregarUsuario(new Usuario(2, "Juan Pérez", "juan@correo.com"));

        //  préstamo de prueba
var usuario = usuarioService.ObtenerTodos().First(u => u.Id == 2);

PrestamosPrueba.Add(new Prestamo(
    1,
    LibrosPrueba[1],
    usuario
)
{
    FechaPrestamo = DateTime.Now.AddDays(-10)
});
    }

 
    static void ShowMainMenu()
    {
        int option = 0;

        do
        {
            Console.Clear();
            Console.WriteLine(" SISTEMA DE BIBLIOTECA ");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Prestamos");
            Console.WriteLine("4. Busquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opcion: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1:
                  ShowBooksMenu();
                    break;

                case 2:
                    ShowUsersMenu();
                    break;

                case 3:
                    ShowLoansMenu();
                    break;

                case 4:
                    ShowSearchReportsMenu();
                    break;

                case 5:
                    ShowPersistenceMenu();
                    break;

                case 6:
                    ConfirmExitAndSave();
                    break;

                default:
                    Console.WriteLine("Opcion no valida");
                    Console.ReadKey();
                    break;
            }

        } while (option != 6);
    }


static void ShowBooksMenu()
{
    int option = 0;

    while (option != 6)
    {
        Console.Clear();
        Console.WriteLine(" MENÚ LIBROS ");
        Console.WriteLine("1. Registrar libro");
        Console.WriteLine("2. Listar libros");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Actualizar libro");
        Console.WriteLine("5. Eliminar libro");
        Console.WriteLine("6. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                RegisterBook();
                break;

            case 2:
                ListBooksMenu();
                break;

            case 3:
                ViewBookDetail();
                break;

            case 4:
                UpdateBookMenu();
                break;

            case 5:
                DeleteBook();
                break;

            case 6:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}

static void ListBooksMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" LISTAR LIBROS ");
        Console.WriteLine("1. Listar todos");
        Console.WriteLine("2. Listar disponibles");
        Console.WriteLine("3. Listar prestados");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                ListBooksAll();
                break;

            case 2:
                ListBooksAvailable();
                break;

            case 3:
                ListBooksBorrowed();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}
static void UpdateBookMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" ACTUALIZAR LIBRO ");
        Console.WriteLine("1. Editar título");
        Console.WriteLine("2. Editar autor");
        Console.WriteLine("3. Editar año / categoría");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                EditBookTitle();
                break;

            case 2:
                EditBookAuthor();
                break;

            case 3:
                EditBookYearCategory();
                break;
        }
    }
}
static void Registrarlibro()
{
    Console.WriteLine("Función: Registrar libro");
    Console.ReadKey();
}

static void RegisterBook()
{
    Console.WriteLine("Función: Registrar libro");
    Console.ReadKey();
}


static void ListBooksAll()
{
    Console.Clear();
    Console.WriteLine("=== Listado de todos los libros ===\n");

    foreach (var libro in libroService.ObtenerLibros())
    {
        Console.WriteLine(libro.ResumenCorto());
        Console.WriteLine("------------------------");
    }

    // KPIs correctos del Service
    Console.WriteLine("\n=== KPIs ===");
    Console.WriteLine("Total: " + libroService.TotalLibros());
    Console.WriteLine("Disponibles: " + libroService.LibrosDisponibles());
    Console.WriteLine("Prestados: " + libroService.LibrosPrestados());

    Console.WriteLine("\nPresiona cualquier tecla para volver...");
    Console.ReadKey();
}
static void ListBooksAvailable()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS DISPONIBLES ===\n");

    foreach (var libro in libroService.ObtenerLibros())
    {
        if (libro.Disponible)
            Console.WriteLine(libro.ResumenCorto());
    }

    Console.ReadKey();
}

static void ListBooksBorrowed()
{
    Console.Clear();
    Console.WriteLine("=== LIBROS PRESTADOS ===\n");

    foreach (var libro in libroService.ObtenerLibros())
    {
        if (!libro.Disponible)
            Console.WriteLine(libro.ResumenCorto());
    }

    Console.ReadKey();
}

static void ViewBookDetail()
{
    Console.WriteLine("Función: Ver detalle del libro por ID/ISBN");
    Console.ReadKey();
}

static void EditBookTitle()
{
    Console.WriteLine("Función: Editar título del libro");
    Console.ReadKey();
}

static void EditBookAuthor()
{
    Console.WriteLine("Función: Editar autor del libro");
    Console.ReadKey();
}

static void EditBookYearCategory()
{
    Console.WriteLine("Función: Editar año o categoría del libro");
    Console.ReadKey();
}

static void DeleteBook()
{
    Console.WriteLine("Validar no permitir eliminar si el libro está prestado");
    Console.ReadKey();
}

static void ShowUsersMenu()
{
    int option = 0;

    while (option != 6)
    {
        Console.Clear();
        Console.WriteLine(" MENÚ USUARIOS ");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Listar usuarios");
        Console.WriteLine("3. Ver detalle");
        Console.WriteLine("4. Actualizar usuario");
        Console.WriteLine("5. Eliminar usuario");
        Console.WriteLine("6. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                RegisterUser();
                break;

            case 2:
                ListUsers();
                break;

            case 3:
                ViewUserDetail();
                break;

            case 4:
                UpdateUserMenu();
                break;

            case 5:
                DeleteUser();
                break;

            case 6:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}

static void UpdateUserMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" ACTUALIZAR USUARIO ");
        Console.WriteLine("1. Editar nombre");
        Console.WriteLine("2. Editar contacto");
        Console.WriteLine("3. Activar / Desactivar usuario");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                EditUserName();
                break;

            case 2:
                EditUserContact();
                break;

            case 3:
                ToggleUserActiveStatus();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}
static void RegisterUser()
{
    Console.Clear();

    Console.Write("Ingrese nombre: ");
    string nombre = Console.ReadLine()!;
    Console.Write("Ingrese email: ");
    string email = Console.ReadLine()!;

    int nuevoId = usuarioService.TotalUsuarios() + 1;
Usuario usuario = new Usuario(nuevoId, nombre, email);

    usuarioService.AgregarUsuario(usuario);

    Console.WriteLine("\nUsuario registrado correctamente en el sistema:");
    Console.WriteLine(usuario.DetalleCompleto());

    Console.ReadKey();
}

static void ListUsers()
{
    Console.Clear();
    Console.WriteLine(" LISTA DE USUARIOS ");

    foreach (var usuario in usuarioService.ObtenerTodos())
    {
        Console.WriteLine(usuario.DetalleCompleto());
        Console.WriteLine("---");
    }

    Console.WriteLine("\nTotal usuarios: " + usuarioService.TotalUsuarios());

    var estados = usuarioService.UsuariosPorEstado();
    Console.WriteLine($"Activos: {estados.activos} | Inactivos: {estados.inactivos}");

    Console.ReadKey();
}
static void ViewUserDetail()
{
    Console.WriteLine("Función: Ver detalle del usuario por ID/documento");
    Console.ReadKey();
}

static void EditUserName()
{
    Console.WriteLine("Función: Editar nombre del usuario");
    Console.ReadKey();
}

static void EditUserContact()
{
    Console.WriteLine("Función: Editar contacto del usuario");
    Console.ReadKey();
}

static void ToggleUserActiveStatus()
{
    Console.WriteLine("Función: Activar o desactivar usuario");
    Console.ReadKey();
}

static void DeleteUser()
{
    Console.WriteLine("Validar no permitir eliminar si tiene préstamos activos");
    Console.ReadKey();
}

static void ShowLoansMenu()
{
    int option = 0;

    while (option != 6)
    {
        Console.Clear();
        Console.WriteLine(" MENÚ PRÉSTAMOS ");
        Console.WriteLine("1. Crear préstamo");
        Console.WriteLine("2. Listar préstamos");
        Console.WriteLine("3. Ver detalle del préstamo");
        Console.WriteLine("4. Registrar devolución");
        Console.WriteLine("5. Eliminar préstamo");
        Console.WriteLine("6. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                CreateLoan();
                break;

            case 2:
                ListLoansMenu();
                break;

            case 3:
                ViewLoanDetail();
                break;

            case 4:
                RegisterReturn();
                break;

            case 5:
                DeleteLoan();
                break;

            case 6:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}
static void ListLoansMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" LISTAR PRÉSTAMOS ");
        Console.WriteLine("1. Todos");
        Console.WriteLine("2. Activos");
        Console.WriteLine("3. Cerrados");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                ListLoansAll();
                break;

            case 2:
                ListLoansActive();
                break;

            case 3:
                ListLoansClosed();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}
static void CreateLoan()
{
    Console.Clear();

    
    Libro libro = libroService.ObtenerLibros().First();
    Usuario usuario = usuarioService.ObtenerTodos().First();

    Prestamo prestamo = new Prestamo(1, libro, usuario);

    // Mostrar información
    Console.WriteLine("PRÉSTAMO CREADO:\n");
    Console.WriteLine(prestamo.ResumenCorto());

    Console.WriteLine("\nDETALLE COMPLETO:");
    Console.WriteLine(prestamo.DetalleCompleto());

    Console.WriteLine("\n¿Está vencido?: " + prestamo.EstaVencido());
    Console.WriteLine("Días transcurridos: " + prestamo.DiasTranscurridos());

    Console.ReadKey();
}
static void ListLoansAll()
{
    Console.WriteLine("Función: Listar todos los préstamos");
    Console.ReadKey();
}

static void ListLoansActive()
{
    Console.WriteLine("Función: Listar préstamos activos");
    Console.ReadKey();
}

static void ListLoansClosed()
{
    Console.WriteLine("Función: Listar préstamos cerrados");
    Console.ReadKey();
}

static void ViewLoanDetail()
{
    Console.WriteLine("Función: Ver detalle del préstamo por ID");
    Console.ReadKey();
}

static void RegisterReturn()
{
    Console.WriteLine("Función: Registrar devolución del libro");
    Console.WriteLine("Marcar préstamo como devuelto y libro disponible");
    Console.ReadKey();
}

static void DeleteLoan()
{
    Console.WriteLine("Función: Eliminar préstamo (validar reglas)");
    Console.ReadKey();
}


static void ShowSearchReportsMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" MENÚ BÚSQUEDAS Y REPORTES ");
        Console.WriteLine("1. Buscar libro");
        Console.WriteLine("2. Buscar usuario");
        Console.WriteLine("3. Reportes");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                SearchBook();
                break;

            case 2:
                SearchUser();
                break;

            case 3:
                ShowReportsMenu();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}
static void ShowReportsMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" MENÚ REPORTES ");
        Console.WriteLine("1. Reporte por usuario");
        Console.WriteLine("2. Reporte por libro");
        Console.WriteLine("3. Reporte vencidos");
        Console.WriteLine("4. Resumen general");
        Console.WriteLine("5. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                ReportByUser();
                break;

            case 2:
                ReportByBook();
                break;

            case 3:
                ReportOverdue();
                break;

            case 4:
                ReportSummary();
                break;
        }
    }
}
static void SearchBook()
{
    Console.WriteLine("Función: Buscar libro por título, autor, ID o categoría");
    Console.ReadKey();
}

static void SearchUser()
{
    Console.WriteLine("Función: Buscar usuario por nombre o ID");
    Console.ReadKey();
}

static void ReportByUser()
{
    Console.WriteLine("Función: Reporte de préstamos por usuario");
    Console.ReadKey();
}

static void ReportByBook()
{
    Console.WriteLine("Función: Reporte de préstamos por libro");
    Console.ReadKey();
}

static void ReportOverdue()
{
    Console.WriteLine("Función: Reporte de préstamos vencidos");
    Console.ReadKey();
}

static void ReportSummary()
{
    Console.WriteLine("Función: Resumen general del sistema");
    Console.ReadKey();
}
static void ShowPersistenceMenu()
{
    int option = 0;

    while (option != 4)
    {
        Console.Clear();
        Console.WriteLine(" GUARDAR / CARGAR DATOS ");
        Console.WriteLine("1. Guardar datos");
        Console.WriteLine("2. Cargar datos");
        Console.WriteLine("3. Reiniciar datos");
        Console.WriteLine("4. Volver");

        Console.Write("Seleccione una opción: ");

        int.TryParse(Console.ReadLine(), out option);

        switch (option)
        {
            case 1:
                SaveData();
                break;

            case 2:
                LoadData();
                break;

            case 3:
                ResetData();
                break;

            case 4:
                break;

            default:
                Console.WriteLine("Opción inválida");
                Console.ReadKey();
                break;
        }
    }
}

static void SaveData()
{
    Console.WriteLine("Función: Guardar datos del sistema");
    Console.ReadKey();
}

static void LoadData()
{
    Console.WriteLine("Función: Cargar datos guardados");
    Console.ReadKey();
}

static void ResetData()
{
    Console.WriteLine("¿Está seguro de reiniciar los datos? (S/N)");

    string respuesta = Console.ReadLine()!;

    if (respuesta.ToUpper() == "S")
    {
        Console.WriteLine("Datos reiniciados correctamente.");
    }
    else
    {
        Console.WriteLine("Operación cancelada.");
    }

    Console.ReadKey();
}
static void ConfirmExitAndSave()
{
    Console.Clear();
    Console.WriteLine("¿Desea guardar antes de salir? (S/N)");

    string respuesta = Console.ReadLine()!;

    if (respuesta.ToUpper() == "S")
    {
        SaveData();
        Console.WriteLine("Datos guardados correctamente.");
    }
    else if (respuesta.ToUpper() == "N")
    {
        Console.WriteLine("Saliendo del sistema...");
    }
    else
    {
        Console.WriteLine("Opción inválida.");
    }

    Console.ReadKey();
}

}
