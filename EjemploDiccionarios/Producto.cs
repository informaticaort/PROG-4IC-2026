namespace EjemploDiccionarios;

public class Producto{
    string nombre;
    double precio;

    public Producto(string nombre, double precio){
        this.nombre = nombre;
        this.precio = precio;
    }

    public string obtenerDatos()
    {
        return "Nombre producto: " + nombre + " Precio producto: " + precio;
    }
}