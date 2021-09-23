using System.Collections.Generic;
using System.Linq;
using NutriApp.App.Dominio;

namespace NutriApp.App.Persistencia{
    public class RepositoryPaciente : IRepositoryPaciente{
        private readonly AppContext _appContext;
        public RepositoryPaciente(AppContext appContext){
            _appContext=appContext;
        }

        Paciente IRepositoryPaciente.AddPaciente(Paciente paciente){
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity;
        }
        
        void IRepositoryPaciente.RemovePaciente(int idPaciente){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id == idPaciente);
            if(pacienteEncontrado == null)return ;

            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();

        }

        Paciente IRepositoryPaciente.UpdatePaciente(Paciente paciente){
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p=>p.Id == paciente.Id);

            if(pacienteEncontrado != null){
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Telefono = paciente.Telefono;
                pacienteEncontrado.Correo = paciente.Correo;
                pacienteEncontrado.Password = paciente.Password;
                pacienteEncontrado.Direccion = paciente.Direccion;
                pacienteEncontrado.Nutricionista = paciente.Nutricionista;
                pacienteEncontrado.Coach = paciente.Coach;
                pacienteEncontrado.Historial = paciente.Historial;
                _appContext.SaveChanges();
            }
                return pacienteEncontrado;
        }

        Paciente IRepositoryPaciente.GetPaciente(int idPaciente){
            return _appContext.Pacientes.FirstOrDefault(p=>p.Id == idPaciente);
        }

        IEnumerable<Paciente> IRepositoryPaciente.GetAllPacientes(){
            return _appContext.Pacientes;
        }
    }

}