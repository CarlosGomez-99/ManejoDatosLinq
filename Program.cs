using System;
using System.Collections.Generic;
using System.Linq;

LinqQueries queries = new LinqQueries();

//Toda la colección
// ImprimirValores(queries.TodaLaColeccion());


//Libros despues del 2000
//ImprimirValores(queries.LibrosDespues2000());


//Libros mayores a 250 paginas y contengan las palabras in Action
//ImprimirValores(queries.LibrosMayor250Paginas());


//Todos los libros tienen status
//Console.WriteLine(queries.TodosLosLibrenContienenStatus());


//Algun libro fue publicado en 2005
//Console.WriteLine(queries.LibrosPublicados2005());


//Libros categoria python
//ImprimirValores(queries.LibrosCategoriaPython());


//Libros ascendente por nombre
// ImprimirValores(queries.LibrosJavaNombreAscendente());


//Libros mayor de 450 paginas ordenados descendentemente
//ImprimirValores(queries.LibrosMayor450PaginasDescendiente());


//3 libros Java publicados; más recientes
// ImprimirValores(queries.TresLibrosJavaPublicadosMasRecientes());


//Tercer y Cuarto libro que mayores a 400 paginas
// ImprimirValores(queries.TercerCuartoLibroMayor400Paginas());


//Tres primeros libros filtrados con Select
// ImprimirValores(queries.TresPrimeroLibrosDeLaColeccion());


//Tres primeros libros filtrados con Select con la clase item
// ImprimirValores(queries.TresPrimeroLibrosDeLaColeccionItem());


//Cantidad de libros entre 200 y 500 paginas
// Console.WriteLine(queries.CantidadLibrosEntre200y500Paginas());


//Menor fecha de publicacion de los libros
// Console.WriteLine(queries.MenorFechaPublicacionLibros().ToLongDateString());


//Mayor cantidad de paginas de todos los libros
// Console.WriteLine(queries.MayorNumeroPaginasLibros());

//Libro de menor paginas mayor a CERO
// var libroMenorPagina = queries.LibroMenorCantidadPaginasMayorACero();
// Console.WriteLine(libroMenorPagina.Title + " - " + libroMenorPagina.PageCount);


//Libro fecha de publicacion más reciente
// var libroFechaReciente = queries.LibroFechaPublicacionReciente();
// Console.WriteLine(libroFechaReciente.Title + " - " + libroFechaReciente.PublishedDate.ToShortDateString());

//Cantidad de paginas de libros entre 0 y 500 paginas
// Console.WriteLine(queries.CantidadPaginasLibrosEntre0y500());

//Libros publicados despues del 2015
//Console.WriteLine(queries.TituloLibrosFechaPublicacionMayor2005Concatenedos());

//Promedio caracteres titulos libros
// Console.WriteLine(queries.PromedioCaracteresTitulo());


//Promedio de paginas libros mayor a cero
// Console.WriteLine(queries.PromedioNumeroPaginasMayorCero());

//Libros publicados a partir el año 2000 agrupados por AÑO
// ImprimirGrupo(queries.LibrosPublicados2000EnAdelanteAgrupados());


//Diccionario de libros agrupados por primera letra del titulos
// var diccionarios = queries.DiccionaiosDeLibrosPorLetra();
// ImprimirDiccionario(diccionarios, 'A');

// Libros filtrados con JOIN
ImprimirValores(queries.ClausulaJoinEntreLibros());

void ImprimirValores(IEnumerable<Book> listadelibros)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in listadelibros)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }
}
void ImprimirGrupo(IEnumerable<IGrouping<int, Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
        }
    }
}

void ImprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
    foreach (var item in ListadeLibros[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.Date.ToShortDateString());
    }
}