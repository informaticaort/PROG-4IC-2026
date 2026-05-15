namespace EjemploMVC4C.Models;

public class Alumno{

    private int Id;
    private string Nombre;
    private int Edad;
    private string Curso;
    private string Email;


    public Alumno(int id, string nombre, int edad, string curso, string email){
        this.Id = id;
        this.Nombre = nombre;
        this.Edad = edad;
        this.Curso = curso;
        this.Email = email;
    }

    public string ObtenerNombre()
    {
        return this.Nombre;
    }


    public int ObtenerId()
    {
        return this.Id;
    }

    public string ObtenerCurso()
    {
        return this.Curso;
    }

    public string ObtenerEmail()
    {
        return this.Email;
    }

    public int ObtenerEdad()
    {
        return this.Edad;
    }


}