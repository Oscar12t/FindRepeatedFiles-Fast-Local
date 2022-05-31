

public class FileGestor
{

    #region Properties

    private static List<string> registredPath = new List<string>(); //Lista de rutas registradas para no tener archivos duplicados

    #endregion

    #region  Public functions

    //*Obtiene todos los archivos repetidos dentro de la ruta especificada y los imprime en consola
    //@param path: ruta especificada
    public static void GetRepeatedFiles(string path)
    {
        //Obtenemos los archivos
        Console.WriteLine("Obteniendo los archivos...");
        List<Archivo> Files = GetAllFiles(path); 
        
        //Los ordenamos por tamano
        Console.WriteLine("Ordenando los archivos por tammano...");
        QuickSort<Archivo>.QuickSorts(0, Files.Count - 1, ref Files, num => 
        {
            return Files[num].Size;
        });

        //Verificamos cuales archivos estan repetidos
        Console.WriteLine("Buscando los archivos repetidos...");
        BuscarArchivosRepetidos(Files);

    }

    //*Obtiene todos los archivos encontrados a partir de la ruta especificada
    //@param path: Ruta de la que va a obtener los archivos
    //@returns: Los archivos obtenidos en tipo archivo
    public static List<Archivo> GetAllFiles(string path)
    {
        //Opciones de Busqueda
        EnumerationOptions findOptions = new EnumerationOptions();
        findOptions.IgnoreInaccessible = true;
        findOptions.RecurseSubdirectories = true;

        //Obtenemos los archivos
        string[] files = Directory.GetFiles(path,"*", findOptions);

        //Los convertimos a tipo archivo
        return FileHelpers.ConvertToFiles(files);
    }

    #endregion

    #region Private Funcions
   
    
    //*Obtiene los archivos repetidos de una lista de archivos
    //Todo: Hacer que devuelva una lista<(Archivo file1, Archivo file2)> donde esten los archivos repetidos
    //Todo: para despues devolverlos por consola
    //@param Files: Lista de archivos
    private static void BuscarArchivosRepetidos(List<Archivo> Files)
    {
        int cont = 0;
        double space = 0; //Espacio que van a ocupar el total de archivos repetidos

        List<(Archivo file1, Archivo file2)> archivosRepetidos = new List<(Archivo file1, Archivo file2)>();
        for(int i = 0; i < Files.Count; i++)
        {
            if(i + 1 != Files.Count)
            {
                if(IsRepeatedFile(Files[i], Files[i + 1]))
                {
                    Console.WriteLine($"Archivo: {Files[i].Name} {Files[i].Size}MB {Files[i].FilePath}");
                    Console.WriteLine($"Archivo: {Files[i + 1].Name} {Files[i + 1].Size}MB {Files[i + 1].FilePath}");
                    Console.WriteLine("");

                    space += Files[i + 1].Size;
                    //archivosRepetidos.Add((Files[i], Files[i + 1]));
                    cont++;
                }
            }
        }

        if(cont == 0) Console.WriteLine("No hay archivos repetidos");
        else
        {
            Console.WriteLine($"Se encontraron {cont} archivos repetidos");
            Console.WriteLine($"Se puede ahorrar {space} MB");
        }
    }

    #endregion

    #region Helpers

    //*Compara 2 archivos y dice si esta repetido
    //Todo: Hacer que en la parte donde compara el nombre verifique si el nombre es pararecido
    //Todo: Crear un metodo que pueda verificar si una palabra es parecida a otra
    //@param file: Archivo 1 para comparar
    //@param file2: Archivo 2 para comparar
    //@returns: False o true dependiendo de si el archivo esta repetido o no
    private static bool IsRepeatedFile(Archivo file, Archivo file2)
    {
        if(file.Size < 5 && file2.Size < 5) return false;
        else if(file.Name == "" || file2.Name == "") return false;
        else if((file.Name == file2.Name && file.Size == file.Size && file.FilePath != file2.FilePath && !IsRegistred(file.FilePath)))
        {
            registredPath.Add(file2.FilePath);
            return true;
        }

        return false;
    }

    //*Comprueba si la ruta y fue registrada
    //@param FilePath: Ruta a revisar
    private static bool IsRegistred(string FilePath)
    {
        foreach(string path in registredPath) if(path == FilePath) return true;
        return false;
    }

    #endregion
}