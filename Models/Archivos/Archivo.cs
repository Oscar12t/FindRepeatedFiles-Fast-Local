
public class Archivo
{
    #region Properties --------------------------------

    public string Name { get; set; }
    public string Extencion{ get; set; }
    public string FilePath { get; set; }
    public double Size { get; set; }
    public double DetalledSize { get; set;}

    //Hacer una propiedad que muestre el Tammano del archivo redondeado

    #endregion

    #region Constructor --------------------------------

    public Archivo(string filePath)
    {
        this.FilePath = filePath;

        FileInfo FileSize = new FileInfo(this.FilePath);

        this.Name = Path.GetFileName(this.FilePath);
        this.Extencion = Path.GetExtension(this.FilePath);
        this.DetalledSize = byteToMegaByte(FileSize.Length);
        this.Size = reducirDecimales(Convert.ToDouble(byteToMegaByte(FileSize.Length)));

    }

    #endregion

    #region Helpers --------------------------------

    //*Convertira el tammano de Bytes a Megabytes
    //@param byte: Tamanno en Bytes
    public double byteToMegaByte(long bytes)
    {
        return bytes * 1.0 / 1048576 * 1.0;
    }

    //*Reducira los decimales del Tamano del archivo para que sea mas legible
    //*@param size: Tammano del archivo al que se le reduciran los decimales
    public double reducirDecimales(double size)
    { 
        if(size == 0.0000) return 0;

        string num = size.ToString();

        int cantidadDecimales = num.Length - num.IndexOf(".");

        if(cantidadDecimales >= 4)
        {
            num = num.Substring(0, num.IndexOf(".") + 4);
        }
        else
        {
            return size;
        }

        return Convert.ToDouble(num);
    }

    #endregion
}