public class LinqQueries
{
    private List<Book> librosCollection = new List<Book>();

    public LinqQueries()
    {
        using (StreamReader reader = new StreamReader("books.json"))
        {
            string json = reader.ReadToEnd();
            this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, new System.Text.Json.JsonSerializerOptions() { PropertyNameCaseInsensitive = true }) ?? Enumerable.Empty<Book>().ToList();

        }
    }

    public IEnumerable<Book> TodaLaColeccion()
    {
        return librosCollection;
    }

    public IEnumerable<Book> LibrosDespues2000()
    {
        //extension method
        //return librosCollection.Where(p=> p.PublishedDate.Year > 2000);

        //Query expresion
        return from l in librosCollection where l.PublishedDate.Year > 2000 select l;
    }

    public IEnumerable<Book> LibrosMayor250Paginas()
    {
        // extension method
        //return librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action"));

        //Query expresion
        return from l in librosCollection where l.PageCount > 250 && l.Title.Contains("in Action") select l;
    }

    public bool TodosLosLibrenContienenStatus()
    {
        return librosCollection.All(p => p.Status != string.Empty);
    }

    public bool LibrosPublicados2005()
    {
        return librosCollection.Any(p => p.PublishedDate.Year == 2005);
    }

    public IEnumerable<Book> LibrosCategoriaPython()
    {
        return librosCollection.Where(p => p.Categories.Contains("Python"));
    }

    public IEnumerable<Book> LibrosJavaNombreAscendente()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> LibrosMayor450PaginasDescendiente()
    {
        return librosCollection.Where(p => p.PageCount > 450).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TresLibrosJavaPublicadosMasRecientes()
    {
        return librosCollection.Where(p => p.Categories.Contains("Java")).OrderByDescending(p => p.PublishedDate).Take(3).take;
    }

    public IEnumerable<Book> TercerCuartoLibroMayor400Paginas()
    {
        return librosCollection.Where(p => p.PageCount > 400).Take(4).Skip(2);
    }

    public IEnumerable<Book> TresPrimeroLibrosDeLaColeccion()
    {
        return librosCollection.Take(3)
             .Select(p => new Book { Title = p.Title, PageCount = p.PageCount });
    }

    public IEnumerable<Item> TresPrimeroLibrosDeLaColeccionItem()
    {
        return librosCollection.Take(3)
        .Select(p => new Item { Title = p.Title, PageCount = p.PageCount });
    }

    public class Item
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
    }

    public int CantidadLibrosEntre200y500Paginas()
    {
        //Mala practica
        //return librosCollection.Where(p => p.PageCount >= 200 && p.PageCount <= 500).Count();
        return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
    }

    public DateTime MenorFechaPublicacionLibros()
    {
        return librosCollection.Min(p => p.PublishedDate);
    }

    public int MayorNumeroPaginasLibros()
    {
        return librosCollection.Max(p => p.PageCount);
    }

    public Book LibroMenorCantidadPaginasMayorACero()
    {
        return librosCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    public Book LibroFechaPublicacionReciente()
    {
        return librosCollection.MaxBy(p => p.PublishedDate);
    }

    public int CantidadPaginasLibrosEntre0y500()
    {
        return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
    }

    public string TituloLibrosFechaPublicacionMayor2005Concatenedos()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2015).Aggregate("", (TitulosLibros, next) =>
        {
            if (TitulosLibros != string.Empty)
                TitulosLibros += " - " + next.Title;
            else
                TitulosLibros += next.Title;
            return TitulosLibros;
        });
    }

    public double PromedioCaracteresTitulo()
    {
        return librosCollection.Average(p => p.Title.Length);
    }

    public double PromedioNumeroPaginasMayorCero()
    {
        return librosCollection.Where(p => p.PageCount > 0).Average(p => p.PageCount);
    }

    public IEnumerable<IGrouping<int, Book>> LibrosPublicados2000EnAdelanteAgrupados()
    {
        return librosCollection.Where(p => p.PublishedDate.Year > 2000).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> DiccionaiosDeLibrosPorLetra()
    {
        return librosCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> ClausulaJoinEntreLibros()
    {
        var LibrosDespues2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

        var LibrosMayorA500Paginas = librosCollection.Where(p => p.PageCount > 500);

        return LibrosDespues2005.Join(LibrosMayorA500Paginas, p => p.Title, x => x.Title, (p, x) => p);
    }
}