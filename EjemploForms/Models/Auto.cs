namespace EjemploForms.Models;

public class Auto{
    private string Patente;
    private string Marca;
    private string Modelo;
    private string Color;
    private int Año;

    public Auto(string patente, string marca, string modelo, string color, int año){
        this.Patente = patente;
        this.Marca = marca;
        this.Modelo = modelo;
        this.Color = color;
        this.Año = año;
    }

    public string obtenerInfo(){
        return (Marca + " - " + Modelo + " - "+ Color +  " - " + Año );
    }

    public string obtenerPatente(){
        return Patente;
    }
}