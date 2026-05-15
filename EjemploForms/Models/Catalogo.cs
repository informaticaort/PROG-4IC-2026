namespace EjemploForms.Models;

public static class Catalogo{
    private static List<Auto> autos = new List<Auto>();


    public static List<Auto> obtenerAutos(){
        return autos;
    }

    public static void agregarAuto(string patente, string marca, string modelo, string color, int año){
        Auto autoNuevo = new Auto(patente, marca, modelo, color, año);
        autos.Add(autoNuevo);
    }

    public static bool ExisteAuto(string patente){
        int i = 0;
        while(i < autos.Count && patente != autos[i].obtenerPatente()){
            i++;
        }

        if(i == autos.Count){
            return false;
        }else{
            return true;
        }
    }
}