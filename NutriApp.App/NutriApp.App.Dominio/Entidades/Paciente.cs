namespace NutriApp.App.Dominio{
    public class Paciente:Persona{
        public string Direccion {get;set;}
        public Nutricionista Nutricionista {get;set;}
        public Coach Coach {get;set;}
        public Historial Historial {get;set;}
    }
}