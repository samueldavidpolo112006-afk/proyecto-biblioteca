using System;
using BibliotecaMenu.Models;

class Program
{
    static void Main()
    {
        ShowMainMenu();
    }

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
            Console.WriteLine("7. Probar modelos (EV07)");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowPersistenceMenu(); break;
                case 6: ConfirmExitAndSave(); break;
                case 7: TestObjects(); break;
                default:
                    Console.WriteLine("Opción inválida. Presione una tecla...");
                    Console.ReadKey();
                    break;
            }

        } while (option != 6);
    }

    static void TestObjects()
    {
        Console.Clear();
        Console.WriteLine("=== DEMOSTRACIÓN DE OBJETOS (EV07) ===\n");

        Libro l1 = new Libro(1, "C# Básico", "Autor A", 2020, "Programación");
        Libro l2 = new Libro(2, "Clean Code", "Robert C. Martin", 2008, "Ingeniería");

        Console.WriteLine("--- LIBRO 1 ---");
        Console.WriteLine(l1.ResumenCorto());
        Console.WriteLine(l1.DetalleCompleto());
        Console.WriteLine("Disponible: " + l1.Disponible);

        Console.WriteLine("\n--- LIBRO 2 ---");
        Console.WriteLine(l2.ResumenCorto());
        Console.WriteLine(l2.DetalleCompleto());
        Console.WriteLine("Disponible: " + l2.Disponible);

        Usuario u1 = new Usuario(1, "Juan Pérez", "3001234567");
        Usuario u2 = new Usuario(2, "María López", "3109876543");

        Console.WriteLine("\n--- USUARIO 1 ---");
        Console.WriteLine(u1.ResumenCorto());
        Console.WriteLine(u1.DetalleCompleto());
        Console.WriteLine("Activo: " + u1.Activo);

        Console.WriteLine("\n--- USUARIO 2 ---");
        Console.WriteLine(u2.ResumenCorto());
        Console.WriteLine(u2.DetalleCompleto());
        Console.WriteLine("Activo: " + u2.Activo);

        Prestamo p1 = new Prestamo(1, l1, u1, DateTime.Now.AddDays(-5), DateTime.Now.AddDays(5));

        Console.WriteLine("\n--- PRÉSTAMO 1 ---");
        Console.WriteLine(p1.ResumenCorto());
        Console.WriteLine(p1.DetalleCompleto());
        Console.WriteLine("Estado: "             + p1.Estado);
        Console.WriteLine("¿Está vencido?: "     + p1.EstaVencido());
        Console.WriteLine("Días transcurridos: " + p1.DiasTranscurridos());

        Console.WriteLine("\nPresione una tecla para volver...");
        Console.ReadKey();
    }

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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: RegisterBook(); break;
                case 2: ListBooksMenu(); break;
                case 3: ViewBookDetail(); break;
                case 4: UpdateBookMenu(); break;
                case 5: DeleteBook(); break;
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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ListBooksAll(); break;
                case 2: ListBooksAvailable(); break;
                case 3: ListBooksBorrowed(); break;
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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: EditBookTitle(); break;
                case 2: EditBookAuthor(); break;
                case 3: EditBookYearCategory(); break;
            }
        } while (option != 0);
    }

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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: RegisterUser(); break;
                case 2: ListUsers(); break;
                case 3: ViewUserDetail(); break;
                case 4: UpdateUserMenu(); break;
                case 5: DeleteUser(); break;
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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: EditUserName(); break;
                case 2: EditUserContact(); break;
                case 3: ToggleUserActiveStatus(); break;
            }
        } while (option != 0);
    }

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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: CreateLoan(); break;
                case 2: ListLoansMenu(); break;
                case 3: ViewLoanDetail(); break;
                case 4: RegisterReturn(); break;
                case 5: DeleteLoan(); break;
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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ListLoansAll(); break;
                case 2: ListLoansActive(); break;
                case 3: ListLoansClosed(); break;
            }
        } while (option != 0);
    }

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
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: SearchBook(); break;
                case 2: SearchUser(); break;
                case 3: ShowReportsMenu(); break;
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
            Console.WriteLine("1. Por usuario");
            Console.WriteLine("2. Por libro");
            Console.WriteLine("3. Vencidos");
            Console.WriteLine("4. Resumen");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ReportByUser(); break;
                case 2: ReportByBook(); break;
                case 3: ReportOverdue(); break;
                case 4: ReportSummary(); break;
            }
        } while (option != 0);
    }

    static void ShowPersistenceMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GUARDAR / CARGAR DATOS ===");
            Console.WriteLine("1. Guardar datos");
            Console.WriteLine("2. Cargar datos");
            Console.WriteLine("3. Reiniciar datos");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: SaveData(); break;
                case 2: LoadData(); break;
                case 3: ConfirmResetData(); break;
            }
        } while (option != 0);
    }

    static void RegisterBook()         { Console.WriteLine("Simulación: Registro de libro");            Console.ReadKey(); }
    static void ListBooksAll()         { Console.WriteLine("Simulación: Listar todos los libros");      Console.ReadKey(); }
    static void ListBooksAvailable()   { Console.WriteLine("Simulación: Libros disponibles");           Console.ReadKey(); }
    static void ListBooksBorrowed()    { Console.WriteLine("Simulación: Libros prestados");             Console.ReadKey(); }
    static void ViewBookDetail()       { Console.WriteLine("Simulación: Ver detalle de libro");         Console.ReadKey(); }
    static void EditBookTitle()        { Console.WriteLine("Simulación: Editar título");                Console.ReadKey(); }
    static void EditBookAuthor()       { Console.WriteLine("Simulación: Editar autor");                 Console.ReadKey(); }
    static void EditBookYearCategory() { Console.WriteLine("Simulación: Editar año / categoría");       Console.ReadKey(); }
    static void DeleteBook()           { Console.WriteLine("Validar: No eliminar si está prestado");    Console.ReadKey(); }

    static void RegisterUser()            { Console.WriteLine("Simulación: Registro de usuario");               Console.ReadKey(); }
    static void ListUsers()               { Console.WriteLine("Simulación: Listar usuarios");                   Console.ReadKey(); }
    static void ViewUserDetail()          { Console.WriteLine("Simulación: Ver detalle usuario");               Console.ReadKey(); }
    static void EditUserName()            { Console.WriteLine("Simulación: Editar nombre");                     Console.ReadKey(); }
    static void EditUserContact()         { Console.WriteLine("Simulación: Editar contacto");                   Console.ReadKey(); }
    static void ToggleUserActiveStatus()  { Console.WriteLine("Simulación: Activar / Desactivar usuario");      Console.ReadKey(); }
    static void DeleteUser()              { Console.WriteLine("Validar: No eliminar si tiene préstamos activos"); Console.ReadKey(); }

    static void CreateLoan()
    {
        Console.WriteLine("Simulación: Crear préstamo");
        Console.WriteLine("Validaciones: Usuario activo, Libro disponible");
        Console.ReadKey();
    }
    static void ListLoansAll()    { Console.WriteLine("Simulación: Todos los préstamos");                      Console.ReadKey(); }
    static void ListLoansActive() { Console.WriteLine("Simulación: Préstamos activos");                        Console.ReadKey(); }
    static void ListLoansClosed() { Console.WriteLine("Simulación: Préstamos cerrados");                       Console.ReadKey(); }
    static void ViewLoanDetail()  { Console.WriteLine("Simulación: Ver detalle de préstamo");                  Console.ReadKey(); }
    static void RegisterReturn()  { Console.WriteLine("Simulación: Devolución registrada - libro disponible"); Console.ReadKey(); }
    static void DeleteLoan()      { Console.WriteLine("Simulación: Eliminar préstamo");                        Console.ReadKey(); }

    static void SearchBook()    { Console.WriteLine("Simulación: Buscar libro (título/autor/id/categoría)"); Console.ReadKey(); }
    static void SearchUser()    { Console.WriteLine("Simulación: Buscar usuario (nombre/id)");              Console.ReadKey(); }
    static void ReportByUser()  { Console.WriteLine("Simulación: Reporte por usuario");                     Console.ReadKey(); }
    static void ReportByBook()  { Console.WriteLine("Simulación: Reporte por libro");                       Console.ReadKey(); }
    static void ReportOverdue() { Console.WriteLine("Simulación: Reporte de préstamos vencidos");           Console.ReadKey(); }
    static void ReportSummary() { Console.WriteLine("Simulación: Resumen general del sistema");             Console.ReadKey(); }

    static void SaveData() { Console.WriteLine("Simulación: Datos guardados"); Console.ReadKey(); }
    static void LoadData() { Console.WriteLine("Simulación: Datos cargados");  Console.ReadKey(); }
    static void ResetData(){ Console.WriteLine("Simulación: Datos reiniciados"); Console.ReadKey(); }

    static void ConfirmResetData()
    {
        Console.Write("¿Reiniciar datos? (S/N): ");
        string r = Console.ReadLine();
        if (r?.ToUpper() == "S") ResetData();
        else { Console.WriteLine("Cancelado."); Console.ReadKey(); }
    }

    static void ConfirmExitAndSave()
    {
        Console.Write("¿Guardar antes de salir? (S/N): ");
        string r = Console.ReadLine();
        if (r?.ToUpper() == "S") Console.WriteLine("Datos guardados.");
        Console.WriteLine("Saliendo...");
        Console.ReadKey();
    }
}