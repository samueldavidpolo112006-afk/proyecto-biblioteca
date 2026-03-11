using System;

class Program
{
    static void Main()
    {
        ShowMainMenu();
    }

    // ==============================
    // MENÚ PRINCIPAL
    // ==============================

    static void ShowMainMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA DE BIBLIOTECA ===");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");

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
                    Console.WriteLine("Opción inválida");
                    Console.ReadKey();
                    break;
            }

        } while (option != 6);
    }

    // ==============================
    // MENÚ LIBROS
    // ==============================

    static void ShowBooksMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ LIBROS ===");
            Console.WriteLine("1. Registrar libro");
            Console.WriteLine("2. Listar libros");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Actualizar libro");
            Console.WriteLine("5. Eliminar libro");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    static void ListBooksMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR LIBROS ===");
            Console.WriteLine("1. Listar todos");
            Console.WriteLine("2. Listar disponibles");
            Console.WriteLine("3. Listar prestados");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    static void UpdateBookMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR LIBRO ===");
            Console.WriteLine("1. Editar título");
            Console.WriteLine("2. Editar autor");
            Console.WriteLine("3. Editar año / categoría");
            Console.WriteLine("0. Volver");

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

        } while (option != 0);
    }

    // ==============================
    // MENÚ USUARIOS
    // ==============================

    static void ShowUsersMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle usuario");
            Console.WriteLine("4. Actualizar usuario");
            Console.WriteLine("5. Eliminar usuario");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    static void UpdateUserMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== ACTUALIZAR USUARIO ===");
            Console.WriteLine("1. Editar nombre");
            Console.WriteLine("2. Editar contacto");
            Console.WriteLine("3. Activar / desactivar");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    // ==============================
    // MENÚ PRÉSTAMOS
    // ==============================

    static void ShowLoansMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRÉSTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle préstamo");
            Console.WriteLine("4. Registrar devolución");
            Console.WriteLine("5. Eliminar préstamo");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    static void ListLoansMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR PRÉSTAMOS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Activos");
            Console.WriteLine("3. Cerrados");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    // ==============================
    // MENÚ BÚSQUEDAS Y REPORTES
    // ==============================

    static void ShowSearchReportsMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. Reportes");
            Console.WriteLine("0. Volver");

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
            }

        } while (option != 0);
    }

    static void ShowReportsMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== REPORTES ===");
            Console.WriteLine("1. Reporte por usuario");
            Console.WriteLine("2. Reporte por libro");
            Console.WriteLine("3. Libros vencidos");
            Console.WriteLine("4. Resumen");
            Console.WriteLine("0. Volver");

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

        } while (option != 0);
    }

    // ==============================
    // MENÚ PERSISTENCIA
    // ==============================

    static void ShowPersistenceMenu()
    {
        int option;

        do
        {
            Console.Clear();
            Console.WriteLine("=== PERSISTENCIA ===");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");

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
                    ConfirmResetData();
                    break;
            }

        } while (option != 0);
    }

    // ==============================
    // FUNCIONES STUB
    // ==============================

    static void RegisterBook() { Console.WriteLine("Registrar libro"); Console.ReadKey(); }
    static void ListBooksAll() { Console.WriteLine("Listar todos los libros"); Console.ReadKey(); }
    static void ListBooksAvailable() { Console.WriteLine("Listar libros disponibles"); Console.ReadKey(); }
    static void ListBooksBorrowed() { Console.WriteLine("Listar libros prestados"); Console.ReadKey(); }
    static void ViewBookDetail() { Console.WriteLine("Ver detalle del libro"); Console.ReadKey(); }
    static void EditBookTitle() { Console.WriteLine("Editar título del libro"); Console.ReadKey(); }
    static void EditBookAuthor() { Console.WriteLine("Editar autor del libro"); Console.ReadKey(); }
    static void EditBookYearCategory() { Console.WriteLine("Editar año o categoría"); Console.ReadKey(); }
    static void DeleteBook() { Console.WriteLine("Eliminar libro (validar si está prestado)"); Console.ReadKey(); }

    static void RegisterUser() { Console.WriteLine("Registrar usuario"); Console.ReadKey(); }
    static void ListUsers() { Console.WriteLine("Listar usuarios"); Console.ReadKey(); }
    static void ViewUserDetail() { Console.WriteLine("Ver detalle del usuario"); Console.ReadKey(); }
    static void EditUserName() { Console.WriteLine("Editar nombre"); Console.ReadKey(); }
    static void EditUserContact() { Console.WriteLine("Editar contacto"); Console.ReadKey(); }
    static void ToggleUserActiveStatus() { Console.WriteLine("Activar / desactivar usuario"); Console.ReadKey(); }
    static void DeleteUser() { Console.WriteLine("Eliminar usuario (validar préstamos activos)"); Console.ReadKey(); }

    static void CreateLoan() { Console.WriteLine("Crear préstamo (mostrar validaciones)"); Console.ReadKey(); }
    static void ListLoansAll() { Console.WriteLine("Listar todos los préstamos"); Console.ReadKey(); }
    static void ListLoansActive() { Console.WriteLine("Listar préstamos activos"); Console.ReadKey(); }
    static void ListLoansClosed() { Console.WriteLine("Listar préstamos cerrados"); Console.ReadKey(); }
    static void ViewLoanDetail() { Console.WriteLine("Ver detalle del préstamo"); Console.ReadKey(); }
    static void RegisterReturn() { Console.WriteLine("Registrar devolución"); Console.ReadKey(); }
    static void DeleteLoan() { Console.WriteLine("Eliminar préstamo"); Console.ReadKey(); }

    static void SearchBook() { Console.WriteLine("Buscar libro"); Console.ReadKey(); }
    static void SearchUser() { Console.WriteLine("Buscar usuario"); Console.ReadKey(); }
    static void ReportByUser() { Console.WriteLine("Reporte por usuario"); Console.ReadKey(); }
    static void ReportByBook() { Console.WriteLine("Reporte por libro"); Console.ReadKey(); }
    static void ReportOverdue() { Console.WriteLine("Reporte de préstamos vencidos"); Console.ReadKey(); }
    static void ReportSummary() { Console.WriteLine("Resumen del sistema"); Console.ReadKey(); }

    static void SaveData() { Console.WriteLine("Datos guardados"); Console.ReadKey(); }
    static void LoadData() { Console.WriteLine("Datos cargados"); Console.ReadKey(); }

    static void ResetData()
    {
        Console.WriteLine("Datos reiniciados");
        Console.ReadKey();
    }

    static void ConfirmResetData()
    {
        Console.WriteLine("¿Seguro que desea reiniciar los datos? (S/N)");
        string answer = Console.ReadLine();

        if (answer.ToUpper() == "S")
        {
            ResetData();
        }
    }

    static void ConfirmExitAndSave()
    {
        Console.WriteLine("¿Desea guardar antes de salir? (S/N)");
        string answer = Console.ReadLine();

        if (answer.ToUpper() == "S")
        {
            SaveData();
        }

        Console.WriteLine("Saliendo del sistema...");
        Console.ReadKey();
    }
}