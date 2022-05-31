
public static class FileHelpers
{
    
    //*Convierte un arreglo de rutas en una lista de Archivos
    //@param Paths: Arreglo de rutas
    //@returns: Lista de Archivos de tipo Archivo
    public static List<Archivo> ConvertToFiles(string[] Paths)
    {
        List<Archivo> Files = new List<Archivo>();

        foreach(var filePath in Paths)
        { 
            Archivo archivo = new Archivo(filePath);
            Files.Add(archivo);
        }

        return Files;
    }
}