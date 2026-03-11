using System;

class Program
{
    static void Main(string[] args)
    {
        ShowMainMenu();
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
        Console.WriteLine("Menu de libros");
        Console.ReadKey();
    }

    static void ShowUsersMenu()
    {
        Console.WriteLine("Menu de usuarios");
        Console.ReadKey();
    }

    static void ShowLoansMenu()
    {
        Console.WriteLine("Menu de prestamos");
        Console.ReadKey();
    }

    static void ShowSearchReportsMenu()
    {
        Console.WriteLine("Menu de busquedas y reportes");
        Console.ReadKey();
    }

    static void ShowPersistenceMenu()
    {
        Console.WriteLine("Menu de guardar y cargar datos");
        Console.ReadKey();
    }

    static void ConfirmExitAndSave()
    {
        Console.WriteLine("¿Desea guardar antes de salir? (S/N)");
        Console.ReadKey();
    }
}