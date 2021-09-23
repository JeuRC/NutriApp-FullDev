using System.Collections.Generic;
using System.Linq;
using NutriApp.App.Dominio;

namespace NutriApp.App.Persistencia{
    public class RepositoryNutricionista : IRepositoryNutricionista{
        private readonly AppContext _appContext;
        public RepositoryNutricionista(AppContext appContext){
            _appContext=appContext;
        }

        Nutricionista IRepositoryNutricionista.AddNutricionista(Nutricionista nutricionista){
            var nutricionistaAdicionado = _appContext.Nutricionistas.Add(nutricionista);
            _appContext.SaveChanges();
            return nutricionistaAdicionado.Entity;
        }
        
        void IRepositoryNutricionista.RemoveNutricionista(int idNutricionista){
            var nutricionistaEncontrado = _appContext.Nutricionistas.FirstOrDefault(c=>c.Id == idNutricionista);
            if(nutricionistaEncontrado == null)return ;

            _appContext.Nutricionistas.Remove(nutricionistaEncontrado);
            _appContext.SaveChanges();
        }

        Nutricionista IRepositoryNutricionista.UpdateNutricionista(Nutricionista nutricionista){
            var nutricionistaEncontrado = _appContext.Nutricionistas.FirstOrDefault(c=>c.Id == nutricionista.Id);

            if(nutricionistaEncontrado != null){
                nutricionistaEncontrado.Nombre = nutricionista.Nombre;
                nutricionistaEncontrado.FechaNacimiento = nutricionista.FechaNacimiento;
                nutricionistaEncontrado.Telefono = nutricionista.Telefono;
                nutricionistaEncontrado.Correo = nutricionista.Correo;
                nutricionistaEncontrado.Password = nutricionista.Password;
                nutricionistaEncontrado.Especializacion = nutricionista.Especializacion;
                nutricionistaEncontrado.TarjetaProfesional = nutricionista.TarjetaProfesional;
                _appContext.SaveChanges();
            }
                return nutricionistaEncontrado;
        }

        Nutricionista IRepositoryNutricionista.GetNutricionista(int idNutricionista){
            return _appContext.Nutricionistas.FirstOrDefault(c=>c.Id == idNutricionista);
        }

        IEnumerable<Nutricionista> IRepositoryNutricionista.GetAllNutricionistas(){
            return _appContext.Nutricionistas;
        }
    }

}