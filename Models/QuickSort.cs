
public static class QuickSort<TList> where TList : Archivo
{
    
    //* Metodo recursivo que realizara la particion en la izquierda y derecha de la lista
    //*y luego en las sublistas hata tener la lista ordenada
    //Todo:Aumentar la eficiencia del QuickSort quitando itercaciones finales innecesarias
    //@param pInicio: Inicio de la lista o sublista
    //@param pFin: Fin de la lista o sublista
    //@param lista: lista que vamos a ordenar
    public static void QuickSorts(int pInicio, int pFin, ref List<TList> lista, Func<int,double> listaValor)
    {
        //Creamos un stack donde vamos a trabajar
	    Stack<(int izquierda, int derecha)> workStack = new Stack<(int derecha, int izquierda)>();

	    workStack.Push((0, lista.Count - 1));

	    int index = 0;

	    while(workStack.Count > 0) //Mientras que el stack tenga elementos
	    {
		    //Asignamos el primer elemento del stack y lo eliminamos
		    var tramo = workStack.Pop();

		    index = Particion(tramo.izquierda, tramo.derecha, ref lista, listaValor);

		    if(index < tramo.derecha)
		    {
			    workStack.Push((index, tramo.derecha));
		    }
		    if(tramo.izquierda < index - 1)
		    {
			    workStack.Push((tramo.izquierda, index-1));
		    }
	    }

        IsSorter(lista);
    }

    //*Se obtendra una lista o sublista desde pInicio hasta pFin y todos los valores de esa sublista
    //*se pondran alrededor del valor lista[pivote] donde pivote = pFin los valores de la lista menores que lista[pivote}
    //*se pondran a la izquierda y los mayores a la derecha
    //@param pInicio: Inicio de la sublista
    //@param pFin: Fin de la sublista
    //@param lista: lista con la que se va a trabajar
    //@returns: Retorna el indice del pivote
    static int Particion(int pInicio, int pFin, ref List<TList> lista, Func<int,double> ListaValor)
    {
        int pivote = pFin;
        int indicePivote = pInicio;
        int n = pInicio;

        for(; n < pFin; n++)
        {
            //Si el valor actual de la lista es menor que el pivote
            if(ListaValor(n) <= ListaValor(pivote))
            {
                //Se intercambia con el indice pivote
                Intercambiar(indicePivote, n, ref lista);
                indicePivote++;
            }

        }

        Intercambiar(indicePivote, pivote, ref lista);

        return indicePivote;

    }
  
    //*Intercambiara la pasicion de dos elementos de una lista basandose en su indice
    //@param indice1: Indice del primer elemento de la lista
    //@param indice2: Indice del segundo elemento de la lista
    //@param Lista: Lista de elementos en que se realizara la operacion
    static void Intercambiar(int indice1, int indice2, ref List<TList> Lista)
    {
        TList valor1 = Lista[indice1];
        TList valor2 = Lista[indice2];

        Lista[indice1] = valor2;
        Lista[indice2] = valor1;
    }

    //*Comprueba que todos los elementos esten ordenados
    static bool IsSorter(List<TList> List)
    {
        double value = 0;
        int iterationes = 0;

        foreach(var item in List)
        {
            iterationes++;

            if(item.Size < value)
            {
                Console.WriteLine("Uffffff");
            }

            value = item.Size;
        }

        return true;
    }
}

