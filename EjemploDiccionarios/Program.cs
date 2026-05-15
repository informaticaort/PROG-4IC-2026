namespace EjemploDiccionarios;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, Producto> dicProductos = new Dictionary<string,Producto>();
        Producto producto1 = new Producto("Oreos", 1450.5);
        dicProductos.Add("12e5t6y", producto1);

        mostrarProductos(dicProductos);

        Console.WriteLine("ELIMINANDO PRODUCTO...");
        dicProductos.Remove("12e5t6y");

        mostrarProductos(dicProductos);
    }

    static void mostrarProductos(Dictionary<string,Producto> dicProductos)
    {
        Console.WriteLine("Los productos que tengo son...");
        foreach(string clave in dicProductos.Keys){
            Console.WriteLine(clave + " - " + dicProductos[clave].obtenerDatos());
        }
    }
}
