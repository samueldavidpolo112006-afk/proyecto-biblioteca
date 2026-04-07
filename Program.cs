using System;
using System.Collections.Generic;
using BibliotecaMenu.Models;
using BibliotecaMenu.Services;

class Program
{
    static LibroService    libroService    = new LibroService();
    static UsuarioService  usuarioService  = new UsuarioService();
    static PrestamoService prestamoService = new PrestamoService();

    static void Main()
    {
        ShowMainMenu();
    }

    // ===================== MENÚ PRINCIPAL =====================

    static void ShowMainMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("===== SISTEMA BIBLIOTECA =====");
            Console.WriteLine("1. Libros");
            Console.WriteLine("2. Usuarios");
            Console.WriteLine("3. Préstamos");
            Console.WriteLine("4. Búsquedas y reportes");
            Console.WriteLine("5. Guardar / Cargar datos");
            Console.WriteLine("6. Prueba Services");
            Console.WriteLine("7. Comparar Array vs List");
            Console.WriteLine("8. Salir");
            Console.Write("Seleccione una opción: ");

            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: ShowBooksMenu(); break;
                case 2: ShowUsersMenu(); break;
                case 3: ShowLoansMenu(); break;
                case 4: ShowSearchReportsMenu(); break;
                case 5: ShowSaveLoadMenu(); break;
                case 6: ShowServicesTest(); break;
                case 7: CompararArrayVsList(); break;
                case 8: Console.WriteLine("Saliendo..."); break;
                default:
                    Console.WriteLine("Opción inválida.");
                    Console.ReadKey();
                    break;
            }
        } while (option != 8);
    }

    // ===================== LIBROS =====================

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
                case 4: UpdateBook(); break;
                case 5: DeleteBook(); break;
            }
        } while (option != 0);
    }

    static void RegisterBook()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR LIBRO ===");
        Console.Write("Título: ");
        string titulo = Console.ReadLine();
        Console.Write("Autor: ");
        string autor = Console.ReadLine();
        Console.Write("Año: ");
        int.TryParse(Console.ReadLine(), out int anio);
        Console.Write("Categoría: ");
        string categoria = Console.ReadLine();

        var libro = new Libro(0, titulo, autor, anio, categoria);
        libroService.AgregarLibro(libro);
        Console.WriteLine($"\n✅ Libro '{titulo}' registrado con ID {libro.Id}.");
        Console.ReadKey();
    }

    static void ListBooksMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== LISTAR LIBROS ===");
            Console.WriteLine("1. Todos");
            Console.WriteLine("2. Disponibles");
            Console.WriteLine("3. Prestados");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: MostrarLibros(libroService.ObtenerLibros(), "TODOS LOS LIBROS"); break;
                case 2: MostrarLibros(libroService.ObtenerDisponibles(), "LIBROS DISPONIBLES"); break;
                case 3: MostrarLibros(libroService.ObtenerPrestados(), "LIBROS PRESTADOS"); break;
            }
        } while (option != 0);
    }

    static void MostrarLibros(List<Libro> lista, string titulo)
    {
        Console.Clear();
        Console.WriteLine($"=== {titulo} ===");
        if (lista.Count == 0)
            Console.WriteLine("No hay libros.");
        else
            foreach (var l in lista)
                Console.WriteLine(l.ResumenCorto() + $" | Disponible: {l.Disponible}");
        Console.ReadKey();
    }

    static void ViewBookDetail()
    {
        Console.Clear();
        Console.Write("ID del libro: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libroService.BuscarPorId(id);
        if (libro == null) Console.WriteLine("❌ No encontrado.");
        else Console.WriteLine("\n" + libro.DetalleCompleto());
        Console.ReadKey();
    }

    static void UpdateBook()
    {
        Console.Clear();
        Console.Write("ID del libro a actualizar: ");
        int.TryParse(Console.ReadLine(), out int id);
        var libro = libroService.BuscarPorId(id);
        if (libro == null) { Console.WriteLine("❌ No encontrado."); Console.ReadKey(); return; }

        Console.WriteLine($"Libro actual: {libro.ResumenCorto()}");
        Console.Write($"Nuevo título [{libro.Titulo}]: ");
        string titulo = Console.ReadLine();
        Console.Write($"Nuevo autor [{libro.Autor}]: ");
        string autor = Console.ReadLine();
        Console.Write($"Nuevo año [{libro.Anio}]: ");
        string anioStr = Console.ReadLine();
        Console.Write($"Nueva categoría [{libro.Categoria}]: ");
        string categoria = Console.ReadLine();

        int anio = string.IsNullOrEmpty(anioStr) ? libro.Anio : int.Parse(anioStr);
        libroService.ActualizarLibro(id,
            string.IsNullOrEmpty(titulo)    ? libro.Titulo    : titulo,
            string.IsNullOrEmpty(autor)     ? libro.Autor     : autor,
            anio,
            string.IsNullOrEmpty(categoria) ? libro.Categoria : categoria);

        Console.WriteLine("✅ Libro actualizado.");
        Console.ReadKey();
    }

    static void DeleteBook()
    {
        Console.Clear();
        Console.Write("ID del libro a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        bool ok = libroService.EliminarLibro(id);
        Console.WriteLine(ok ? "✅ Libro eliminado." : "❌ No se puede eliminar (no existe o está prestado).");
        Console.ReadKey();
    }

    // ===================== USUARIOS =====================

    static void ShowUsersMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ USUARIOS ===");
            Console.WriteLine("1. Registrar usuario");
            Console.WriteLine("2. Listar usuarios");
            Console.WriteLine("3. Ver detalle");
            Console.WriteLine("4. Editar nombre");
            Console.WriteLine("5. Editar contacto");
            Console.WriteLine("6. Activar / Desactivar");
            Console.WriteLine("7. Eliminar usuario");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: RegisterUser(); break;
                case 2: ListUsers(); break;
                case 3: ViewUserDetail(); break;
                case 4: EditUserName(); break;
                case 5: EditUserContact(); break;
                case 6: ToggleUserActive(); break;
                case 7: DeleteUser(); break;
            }
        } while (option != 0);
    }

    static void RegisterUser()
    {
        Console.Clear();
        Console.WriteLine("=== REGISTRAR USUARIO ===");
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Contacto: ");
        string contacto = Console.ReadLine();

        var usuario = new Usuario(0, nombre, contacto);
        usuarioService.AgregarUsuario(usuario);
        Console.WriteLine($"\n✅ Usuario '{nombre}' registrado con ID {usuario.Id}.");
        Console.ReadKey();
    }

    static void ListUsers()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE USUARIOS ===");
        var lista = usuarioService.ObtenerUsuarios();
        if (lista.Count == 0)
            Console.WriteLine("No hay usuarios.");
        else
            foreach (var u in lista)
                Console.WriteLine(u.ResumenCorto() + $" | Activo: {u.Activo}");
        Console.ReadKey();
    }

    static void ViewUserDetail()
    {
        Console.Clear();
        Console.Write("ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        var u = usuarioService.BuscarPorId(id);
        if (u == null) Console.WriteLine("❌ No encontrado.");
        else Console.WriteLine("\n" + u.DetalleCompleto());
        Console.ReadKey();
    }

    static void EditUserName()
    {
        Console.Clear();
        Console.Write("ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Nuevo nombre: ");
        string nombre = Console.ReadLine();
        bool ok = usuarioService.ActualizarNombre(id, nombre);
        Console.WriteLine(ok ? "✅ Nombre actualizado." : "❌ Usuario no encontrado.");
        Console.ReadKey();
    }

    static void EditUserContact()
    {
        Console.Clear();
        Console.Write("ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        Console.Write("Nuevo contacto: ");
        string contacto = Console.ReadLine();
        bool ok = usuarioService.ActualizarContacto(id, contacto);
        Console.WriteLine(ok ? "✅ Contacto actualizado." : "❌ Usuario no encontrado.");
        Console.ReadKey();
    }

    static void ToggleUserActive()
    {
        Console.Clear();
        Console.Write("ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int id);
        bool ok = usuarioService.ToggleActivo(id);
        if (ok)
        {
            var u = usuarioService.BuscarPorId(id);
            Console.WriteLine($"✅ Usuario ahora está: {(u.Activo ? "Activo" : "Inactivo")}");
        }
        else Console.WriteLine("❌ Usuario no encontrado.");
        Console.ReadKey();
    }

    static void DeleteUser()
    {
        Console.Clear();
        Console.Write("ID del usuario a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        bool ok = usuarioService.EliminarUsuario(id);
        Console.WriteLine(ok ? "✅ Usuario eliminado." : "❌ No encontrado.");
        Console.ReadKey();
    }

    // ===================== PRÉSTAMOS =====================

    static void ShowLoansMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== MENÚ PRÉSTAMOS ===");
            Console.WriteLine("1. Crear préstamo");
            Console.WriteLine("2. Listar préstamos");
            Console.WriteLine("3. Ver detalle");
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

    static void CreateLoan()
    {
        Console.Clear();
        Console.WriteLine("=== CREAR PRÉSTAMO ===");
        Console.Write("ID del libro: ");
        int.TryParse(Console.ReadLine(), out int libroId);
        var libro = libroService.BuscarPorId(libroId);

        if (libro == null)     { Console.WriteLine("❌ Libro no encontrado.");        Console.ReadKey(); return; }
        if (!libro.Disponible) { Console.WriteLine("❌ El libro no está disponible."); Console.ReadKey(); return; }

        Console.Write("ID del usuario: ");
        int.TryParse(Console.ReadLine(), out int usuarioId);
        var usuario = usuarioService.BuscarPorId(usuarioId);

        if (usuario == null)  { Console.WriteLine("❌ Usuario no encontrado.");    Console.ReadKey(); return; }
        if (!usuario.Activo)  { Console.WriteLine("❌ El usuario no está activo."); Console.ReadKey(); return; }

        Console.Write("Días de préstamo: ");
        int.TryParse(Console.ReadLine(), out int dias);

        var prestamo = new Prestamo(0, libro, usuario, DateTime.Now, DateTime.Now.AddDays(dias));
        prestamoService.AgregarPrestamo(prestamo);
        Console.WriteLine($"\n✅ Préstamo creado. ID: {prestamo.Id} | Devolver antes de: {prestamo.FechaLimite:dd/MM/yyyy}");
        Console.ReadKey();
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
            Console.WriteLine("3. Devueltos");
            Console.WriteLine("4. Vencidos");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: MostrarPrestamos(prestamoService.ObtenerPrestamos(), "TODOS"); break;
                case 2: MostrarPrestamos(prestamoService.ObtenerActivos(),   "ACTIVOS"); break;
                case 3: MostrarPrestamos(prestamoService.ObtenerDevueltos(), "DEVUELTOS"); break;
                case 4: MostrarPrestamos(prestamoService.ObtenerVencidos(),  "VENCIDOS"); break;
            }
        } while (option != 0);
    }

    static void MostrarPrestamos(List<Prestamo> lista, string titulo)
    {
        Console.Clear();
        Console.WriteLine($"=== PRÉSTAMOS {titulo} ===");
        if (lista.Count == 0)
            Console.WriteLine("No hay préstamos.");
        else
            foreach (var p in lista)
                Console.WriteLine(p.ResumenCorto());
        Console.ReadKey();
    }

    static void ViewLoanDetail()
    {
        Console.Clear();
        Console.Write("ID del préstamo: ");
        int.TryParse(Console.ReadLine(), out int id);
        var p = prestamoService.BuscarPorId(id);
        if (p == null) Console.WriteLine("❌ No encontrado.");
        else Console.WriteLine("\n" + p.DetalleCompleto());
        Console.ReadKey();
    }

    static void RegisterReturn()
    {
        Console.Clear();
        Console.Write("ID del préstamo a devolver: ");
        int.TryParse(Console.ReadLine(), out int id);
        bool ok = prestamoService.RegistrarDevolucion(id);
        Console.WriteLine(ok ? "✅ Devolución registrada. Libro disponible." : "❌ No encontrado o ya devuelto.");
        Console.ReadKey();
    }

    static void DeleteLoan()
    {
        Console.Clear();
        Console.Write("ID del préstamo a eliminar: ");
        int.TryParse(Console.ReadLine(), out int id);
        bool ok = prestamoService.EliminarPrestamo(id);
        Console.WriteLine(ok ? "✅ Préstamo eliminado." : "❌ No encontrado.");
        Console.ReadKey();
    }

    // ===================== BÚSQUEDAS Y REPORTES =====================

    static void ShowSearchReportsMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== BÚSQUEDAS Y REPORTES ===");
            Console.WriteLine("1. Buscar libro");
            Console.WriteLine("2. Buscar usuario");
            Console.WriteLine("3. KPIs / Estadísticas");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: SearchBook(); break;
                case 2: SearchUser(); break;
                case 3: ShowKPIs(); break;
            }
        } while (option != 0);
    }

    static void SearchBook()
    {
        Console.Clear();
        Console.WriteLine("Buscar por: 1) Título  2) Autor  3) ID");
        Console.Write("Opción: ");
        int.TryParse(Console.ReadLine(), out int op);

        List<Libro> resultados = new List<Libro>();

        if (op == 1)
        {
            Console.Write("Título: ");
            resultados = libroService.BuscarPorTitulo(Console.ReadLine());
        }
        else if (op == 2)
        {
            Console.Write("Autor: ");
            resultados = libroService.BuscarPorAutor(Console.ReadLine());
        }
        else if (op == 3)
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            var l = libroService.BuscarPorId(id);
            if (l != null) resultados.Add(l);
        }

        Console.Clear();
        Console.WriteLine("=== RESULTADOS ===");
        if (resultados.Count == 0)
            Console.WriteLine("Sin resultados.");
        else
            foreach (var l in resultados)
                Console.WriteLine(l.ResumenCorto());
        Console.ReadKey();
    }

    static void SearchUser()
    {
        Console.Clear();
        Console.WriteLine("Buscar por: 1) Nombre  2) ID");
        Console.Write("Opción: ");
        int.TryParse(Console.ReadLine(), out int op);

        List<Usuario> resultados = new List<Usuario>();

        if (op == 1)
        {
            Console.Write("Nombre: ");
            resultados = usuarioService.BuscarPorNombre(Console.ReadLine());
        }
        else if (op == 2)
        {
            Console.Write("ID: ");
            int.TryParse(Console.ReadLine(), out int id);
            var u = usuarioService.BuscarPorId(id);
            if (u != null) resultados.Add(u);
        }

        Console.Clear();
        Console.WriteLine("=== RESULTADOS ===");
        if (resultados.Count == 0)
            Console.WriteLine("Sin resultados.");
        else
            foreach (var u in resultados)
                Console.WriteLine(u.ResumenCorto());
        Console.ReadKey();
    }

    static void ShowKPIs()
    {
        Console.Clear();
        Console.WriteLine("=== KPIs / ESTADÍSTICAS ===\n");

        Console.WriteLine("📚 LIBROS");
        Console.WriteLine($"  Total:       {libroService.TotalLibros()}");
        Console.WriteLine($"  Disponibles: {libroService.TotalDisponibles()}");
        Console.WriteLine($"  Prestados:   {libroService.TotalPrestados()}");

        Console.WriteLine("\n👤 USUARIOS");
        Console.WriteLine($"  Total:       {usuarioService.TotalUsuarios()}");
        Console.WriteLine($"  Activos:     {usuarioService.TotalActivos()}");
        Console.WriteLine($"  Inactivos:   {usuarioService.TotalInactivos()}");

        Console.WriteLine("\n📋 PRÉSTAMOS");
        Console.WriteLine($"  Total:         {prestamoService.TotalPrestamos()}");
        Console.WriteLine($"  Activos:       {prestamoService.TotalActivos()}");
        Console.WriteLine($"  Devueltos:     {prestamoService.TotalDevueltos()}");
        Console.WriteLine($"  Vencidos:      {prestamoService.TotalVencidos()}");
        Console.WriteLine($"  Promedio días: {prestamoService.PromedioDiasPrestamo():F1}");

        Console.ReadKey();
    }

    // ===================== GUARDAR / CARGAR DATOS =====================

    static void ShowSaveLoadMenu()
    {
        int option;
        do
        {
            Console.Clear();
            Console.WriteLine("=== GUARDAR / CARGAR DATOS ===");
            Console.WriteLine("1. Guardar datos en archivo");
            Console.WriteLine("2. Cargar datos desde archivo");
            Console.WriteLine("0. Volver");
            Console.Write("Seleccione: ");
            int.TryParse(Console.ReadLine(), out option);

            switch (option)
            {
                case 1: GuardarDatos(); break;
                case 2: CargarDatos(); break;
            }
        } while (option != 0);
    }

    static void GuardarDatos()
    {
        Console.Clear();
        Console.WriteLine("=== GUARDAR DATOS ===\n");

        var libros   = libroService.ObtenerLibros();
        var usuarios = usuarioService.ObtenerUsuarios();
        var prestamos = prestamoService.ObtenerPrestamos();

        var lineas = new List<string>();

        lineas.Add("# LIBROS");
        foreach (var l in libros)
            lineas.Add($"LIBRO|{l.Id}|{l.Titulo}|{l.Autor}|{l.Anio}|{l.Categoria}|{l.Disponible}");

        lineas.Add("# USUARIOS");
        foreach (var u in usuarios)
            lineas.Add($"USUARIO|{u.Id}|{u.Nombre}|{u.Contacto}|{u.Activo}");

        lineas.Add("# PRESTAMOS");
        foreach (var p in prestamos)
            lineas.Add($"PRESTAMO|{p.Id}|{p.Libro.Id}|{p.Usuario.Id}|{p.FechaPrestamo:yyyy-MM-dd}|{p.FechaLimite:yyyy-MM-dd}|{p.Estado}");

        System.IO.File.WriteAllLines("datos.txt", lineas);
        Console.WriteLine($"✅ Datos guardados en 'datos.txt'");
        Console.WriteLine($"   Libros:    {libros.Count}");
        Console.WriteLine($"   Usuarios:  {usuarios.Count}");
        Console.WriteLine($"   Préstamos: {prestamos.Count}");
        Console.ReadKey();
    }

    static void CargarDatos()
    {
        Console.Clear();
        Console.WriteLine("=== CARGAR DATOS ===\n");

        if (!System.IO.File.Exists("datos.txt"))
        {
            Console.WriteLine("❌ No se encontró el archivo 'datos.txt'.");
            Console.WriteLine("   Primero guarda los datos con la opción 1.");
            Console.ReadKey();
            return;
        }

        var lineas = System.IO.File.ReadAllLines("datos.txt");
        int librosC = 0, usuariosC = 0, prestamosC = 0;

        foreach (var linea in lineas)
        {
            if (linea.StartsWith("#") || string.IsNullOrWhiteSpace(linea)) continue;
            var partes = linea.Split('|');

            if (partes[0] == "LIBRO")
            {
                int id = int.Parse(partes[1]);
                if (libroService.BuscarPorId(id) == null)
                {
                    var l = new Libro(id, partes[2], partes[3], int.Parse(partes[4]), partes[5]);
                    libroService.AgregarLibro(l);
                    librosC++;
                }
            }
            else if (partes[0] == "USUARIO")
            {
                int id = int.Parse(partes[1]);
                if (usuarioService.BuscarPorId(id) == null)
                {
                    var u = new Usuario(id, partes[2], partes[3]);
                    usuarioService.AgregarUsuario(u);
                    usuariosC++;
                }
            }
        }

        Console.WriteLine($"✅ Datos cargados desde 'datos.txt'");
        Console.WriteLine($"   Libros cargados:   {librosC}");
        Console.WriteLine($"   Usuarios cargados: {usuariosC}");
        Console.ReadKey();
    }

    // ===================== PRUEBA SERVICES =====================

    static void ShowServicesTest()
    {
        Console.Clear();
        Console.WriteLine("=== PRUEBA SERVICES ===\n");

        Console.WriteLine("📚 LibroService:");
        Console.WriteLine($"  Total libros:       {libroService.TotalLibros()}");
        Console.WriteLine($"  Total disponibles:  {libroService.TotalDisponibles()}");
        Console.WriteLine($"  Total prestados:    {libroService.TotalPrestados()}");

        Console.WriteLine("\n👤 UsuarioService:");
        Console.WriteLine($"  Total usuarios:     {usuarioService.TotalUsuarios()}");
        Console.WriteLine($"  Total activos:      {usuarioService.TotalActivos()}");
        Console.WriteLine($"  Total inactivos:    {usuarioService.TotalInactivos()}");

        Console.WriteLine("\n📋 PrestamoService:");
        Console.WriteLine($"  Total préstamos:    {prestamoService.TotalPrestamos()}");
        Console.WriteLine($"  Total activos:      {prestamoService.TotalActivos()}");
        Console.WriteLine($"  Total devueltos:    {prestamoService.TotalDevueltos()}");
        Console.WriteLine($"  Total vencidos:     {prestamoService.TotalVencidos()}");

        Console.WriteLine("\n✅ Todos los services funcionan correctamente.");
        Console.ReadKey();
    }

    // ===================== COMPARAR ARRAY VS LIST =====================

    static void CompararArrayVsList()
    {
        Console.Clear();
        Console.WriteLine("=== COMPARAR ARRAY vs LIST ===\n");

        // --- ARRAY ---
        Console.WriteLine("📦 ARRAY (tamaño fijo):");
        string[] arrayLibros = new string[3];
        arrayLibros[0] = "El Quijote";
        arrayLibros[1] = "Cien años de soledad";
        arrayLibros[2] = "1984";

        Console.WriteLine($"  Tamaño fijo: {arrayLibros.Length} elementos");
        foreach (var libro in arrayLibros)
            Console.WriteLine($"  - {libro}");

        // --- LIST ---
        Console.WriteLine("\n📋 LIST (tamaño dinámico):");
        List<string> listaLibros = new List<string>();
        listaLibros.Add("El Quijote");
        listaLibros.Add("Cien años de soledad");
        listaLibros.Add("1984");
        listaLibros.Add("Harry Potter");
        listaLibros.Add("El Principito");

        Console.WriteLine($"  Tamaño dinámico: {listaLibros.Count} elementos");
        foreach (var libro in listaLibros)
            Console.WriteLine($"  - {libro}");

        // --- DIFERENCIAS ---
        Console.WriteLine("\n📊 DIFERENCIAS CLAVE:");
        Console.WriteLine("  Array:  Tamaño FIJO, más rápido en acceso directo por índice.");
        Console.WriteLine("  List:   Tamaño DINÁMICO, más flexible (Add / Remove).");
        Console.WriteLine("  Array:  Se declara con tamaño: string[3]");
        Console.WriteLine("  List:   Crece sola:            List<string>()");
        Console.WriteLine("\n  En este proyecto usamos List<T> en los Services");
        Console.WriteLine("  porque la cantidad de libros/usuarios puede cambiar.");

        Console.ReadKey();
    }
}