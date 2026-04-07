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
    static PrestamoService prestamoService = new PrestamoService();

    static List<Libro> LibrosPrueba = new List<Libro>(); 


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

 CompararArrayVsList();

        ShowMainMenu();
    }


    
    static void InicializarObjetosPrueba()
{
    LibrosPrueba.Add(new Libro(1, "Cien años de soledad", "Gabriel García Márquez"));
    LibrosPrueba.Add(new Libro(2, "El principito", "Antoine de Saint-Exupéry") { Disponible = false });

    usuarioService.AgregarUsuario(new Usuario(1, "María López", "maria@correo.com"));
    usuarioService.AgregarUsuario(new Usuario(2, "Juan Pérez", "juan@correo.com"));

    // préstamo de prueba
    var usuario = usuarioService.ObtenerTodos().First(u => u.Id == 2);

    var prestamo = new Prestamo(1, LibrosPrueba[1], usuario);
    prestamoService.AgregarPrestamo(prestamo);
}
static void CompararArrayVsList()
{
    Console.Clear();

    Console.WriteLine("=== COMPARACIÓN ARRAY vs LIST ===\n");

    // ARRAY
    string[] librosArray = new string[2];
    librosArray[0] = "Cien años de soledad";
    librosArray[1] = "El principito";

    Console.WriteLine("ARRAY:");
    foreach (var libro in librosArray)
    {
        Console.WriteLine(libro);
    }

    // LIST
    List<string> librosList = new List<string>();
    librosList.Add("Cien años de soledad");
    librosList.Add("El principito");
    librosList.Add("Don Quijote");

    Console.WriteLine("\nLIST:");
    foreach (var libro in librosList)
    {
        Console.WriteLine(libro);
    }

    Console.WriteLine("\nDIFERENCIA:");
    Console.WriteLine("- Array: tamaño fijo");
    Console.WriteLine("- List: tamaño dinámico");

    Console.ReadKey();
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
    Console.Clear();

    Console.Write("Ingrese título: ");
    string titulo = Console.ReadLine()!;

    Console.Write("Ingrese autor: ");
    string autor = Console.ReadLine()!;

    int id = libroService.TotalLibros() + 1;

    Libro libro = new Libro(id, titulo, autor);

    libroService.AgregarLibro(libro);

    Console.WriteLine("\nLibro registrado correctamente:");
    Console.WriteLine(libro.ResumenCorto());

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
    Console.Clear();

    Console.Write("Ingrese ID del libro: ");
    int id = int.Parse(Console.ReadLine()!);

    var libro = libroService.BuscarPorId(id);

    if (libro == null)
    {
        Console.WriteLine("Libro no encontrado.");
    }
    else
    {
        Console.WriteLine("Título actual: " + libro.Titulo);

        Console.Write("Nuevo título: ");
        string nuevoTitulo = Console.ReadLine()!;

        libro.Titulo = nuevoTitulo;

        Console.WriteLine("Título actualizado correctamente.");
    }

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
    Console.Clear();

    Console.Write("Ingrese ID del libro a eliminar: ");
    int id = int.Parse(Console.ReadLine()!);

    var libro = libroService.BuscarPorId(id);

    if (libro == null)
    {
        Console.WriteLine("El libro no existe.");
    }
    else if (!libro.Disponible)
    {
        Console.WriteLine("No se puede eliminar porque el libro está prestado.");
    }
    else
    {
        libroService.EliminarLibro(id);
        Console.WriteLine("Libro eliminado correctamente.");
    }

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

    Console.Write("Ingrese documento: ");
    string documento = Console.ReadLine()!;

    Console.Write("Ingrese nombre: ");
    string nombre = Console.ReadLine()!;

    Console.Write("Ingrese email: ");
    string email = Console.ReadLine()!;

    int nuevoId = usuarioService.TotalUsuarios() + 1;

    Usuario usuario = new Usuario(nuevoId, nombre, email);
    usuario.Documento = documento;

    usuarioService.AgregarUsuario(usuario);

    Console.WriteLine("\nUsuario registrado correctamente:");
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
    Console.Clear();

    Console.Write("Ingrese documento del usuario: ");
    string documento = Console.ReadLine()!;

    var usuario = usuarioService.BuscarPorDocumento(documento);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado.");
    }
    else
    {
        Console.WriteLine("Nombre actual: " + usuario.Nombre);

        Console.Write("Nuevo nombre: ");
        string nuevoNombre = Console.ReadLine()!;

        usuario.Nombre = nuevoNombre;

        Console.WriteLine("Nombre actualizado correctamente.");
    }

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
    Console.Clear();

    Console.Write("Ingrese ID del usuario a eliminar: ");
    int id = int.Parse(Console.ReadLine()!);

    var usuario = usuarioService.ObtenerTodos()
        .FirstOrDefault(u => u.Id == id);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no encontrado.");
    }
    else
    {
        var prestamosActivos = prestamoService.ObtenerTodos()
            .Any(p => p.Usuario.Id == id && p.Estado.ToString() == "Activo");

        if (prestamosActivos)
        {
            Console.WriteLine("No se puede eliminar, tiene préstamos activos.");
        }
        else
        {
            usuarioService.EliminarUsuario(usuario.Documento); // o por ID si lo cambias
            Console.WriteLine("Usuario eliminado correctamente.");
        }
    }

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

    Console.WriteLine("=== CREAR PRÉSTAMO ===");

    Console.Write("ID del libro: ");
    int libroId = int.Parse(Console.ReadLine()!);

    var libro = libroService.BuscarPorId(libroId);

    if (libro == null || !libro.Disponible)
    {
        Console.WriteLine("Libro no disponible.");
        Console.ReadKey();
        return;
    }

    Console.Write("ID del usuario: ");
    int usuarioId = int.Parse(Console.ReadLine()!);

    var usuario = usuarioService.ObtenerTodos()
        .FirstOrDefault(u => u.Id == usuarioId);

    if (usuario == null)
    {
        Console.WriteLine("Usuario no existe.");
        Console.ReadKey();
        return;
    }

    int nuevoId = prestamoService.TotalPrestamos() + 1;

    Prestamo prestamo = new Prestamo(nuevoId, libro, usuario);

    prestamoService.AgregarPrestamo(prestamo);

    libro.Disponible = false;

    Console.WriteLine("\nPréstamo creado correctamente:");
    Console.WriteLine(prestamo.ResumenCorto());

    Console.ReadKey();
}
static void ListLoansAll()
{
    Console.Clear();
    Console.WriteLine(" LISTADO DE PRÉSTAMOS ");

    var prestamos = prestamoService.ObtenerTodos();

    foreach (var prestamo in prestamos)
    {
        Console.WriteLine(prestamo.ResumenCorto());
        Console.WriteLine("");
    }

    Console.WriteLine("\nTotal préstamos: " + prestamoService.TotalPrestamos());

    Console.ReadKey();
}

static void ListLoansActive()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS ACTIVOS ===\n");

    var activos = prestamoService.ObtenerTodos()
        .Where(p => p.Estado.ToString() == "Activo");

    foreach (var p in activos)
    {
        Console.WriteLine(p.ResumenCorto());
        Console.WriteLine("---");
    }

    Console.ReadKey();
}

static void ListLoansClosed()
{
    Console.Clear();
    Console.WriteLine("=== PRÉSTAMOS DEVUELTOS ===\n");

    var cerrados = prestamoService.ObtenerTodos()
        .Where(p => p.Estado.ToString() == "Devuelto");

    foreach (var p in cerrados)
    {
        Console.WriteLine(p.ResumenCorto());
        Console.WriteLine("---");
    }

    Console.ReadKey();
}

static void ViewLoanDetail()
{
    Console.Clear();

    Console.Write("Ingrese ID del préstamo: ");
    int id = int.Parse(Console.ReadLine()!);

    var prestamo = prestamoService.BuscarPorId(id);

    if (prestamo == null)
    {
        Console.WriteLine("Préstamo no encontrado.");
    }
    else
    {
        Console.WriteLine("\n=== DETALLE ===");
        Console.WriteLine(prestamo.DetalleCompleto());
    }

    Console.ReadKey();
}

static void RegisterReturn()
{
    Console.Clear();

    Console.Write("ID del préstamo: ");
    int id = int.Parse(Console.ReadLine()!);

    var prestamo = prestamoService.BuscarPorId(id);

    if (prestamo == null)
    {
        Console.WriteLine("Préstamo no existe.");
    }
    else
    {
        prestamo.Estado = EstadoPrestamo.Devuelto;
        prestamo.LibroPrestado.Disponible = true;

        Console.WriteLine("Devolución registrada correctamente.");
    }

    Console.ReadKey();
}

static void DeleteLoan()
{
    Console.Clear();

    Console.Write("Ingrese ID del préstamo a eliminar: ");
    int id = int.Parse(Console.ReadLine()!);

    var prestamo = prestamoService.BuscarPorId(id);

    if (prestamo == null)
    {
        Console.WriteLine("No existe.");
    }
    else if (prestamo.Estado.ToString() == "Activo")
    {
        Console.WriteLine("No se puede eliminar un préstamo activo.");
    }
    else
    {
        prestamoService.EliminarPrestamo(id);
        Console.WriteLine("Préstamo eliminado.");
    }

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

    while (option != 5)
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
    Console.Clear();

    Console.Write("Ingrese título a buscar: ");
    string titulo = Console.ReadLine()!;

    var resultados = libroService.ObtenerLibros()
        .Where(l => l.Titulo.ToLower().Contains(titulo.ToLower()))
        .ToList();

    if (resultados.Count == 0)
    {
        Console.WriteLine("No se encontraron libros.");
    }
    else
    {
        foreach (var libro in resultados)
        {
            Console.WriteLine(libro.ResumenCorto());
        }
    }

    Console.ReadKey();
}

static void SearchUser()
{
    Console.Clear();

    Console.Write("Ingrese nombre: ");
    string nombre = Console.ReadLine()!;

    var usuarios = usuarioService.BuscarPorNombre(nombre);

    foreach (var u in usuarios)
    {
        Console.WriteLine(u.DetalleCompleto());
    }

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
    Console.Clear();

    Console.WriteLine("=== RESUMEN DEL SISTEMA ===\n");

    Console.WriteLine("LIBROS:");
    Console.WriteLine("Total: " + libroService.TotalLibros());
    Console.WriteLine("Disponibles: " + libroService.LibrosDisponibles());
    Console.WriteLine("Prestados: " + libroService.LibrosPrestados());

    Console.WriteLine("\nUSUARIOS:");
    Console.WriteLine("Total: " + usuarioService.TotalUsuarios());
    var estados = usuarioService.UsuariosPorEstado();
    Console.WriteLine($"Activos: {estados.activos}");
    Console.WriteLine($"Inactivos: {estados.inactivos}");

    Console.WriteLine("\nPRÉSTAMOS:");
    Console.WriteLine("Total: " + prestamoService.TotalPrestamos());
    Console.WriteLine("Activos: " + prestamoService.PrestamosActivos());
    Console.WriteLine("Devueltos: " + prestamoService.PrestamosDevueltos());
    Console.WriteLine("Promedio días: " + prestamoService.PromedioDiasPrestamo());

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
