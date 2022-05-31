

string ruta = "";

Console.WriteLine("Escriba la ruta en la que buscar archivos repetidos:");
ruta = Console.ReadLine().ToString();

FileGestor.GetRepeatedFiles(ruta);
