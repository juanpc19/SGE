using BibliotecaDeClases;
using Ej5tema9MVVM.Models.DAL;
using EjTema10MVVMCommands.ViewModels.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjTema10MVVMCommands.ViewModels
{
    internal class MainPageVM : clsVMBase
    {
        #region atributos
        private DelegateCommand buscarCommand;
        private DelegateCommand eliminarCommand;
        private List<clsPersona> listaPersonas;
        private clsPersona personaSeleccionada;
        private string textoBusqueda;
        #endregion


        #region Constructores

        public MainPageVM()
        {
            listaPersonas = clsListaPersonasFalsa.getListaFalsa();
            buscarCommand = new DelegateCommand(buscarCommandExecute);
            eliminarCommand = new DelegateCommand(eliminarCommandExecute);


        }

        private bool eliminarCommandCanExecute()
        {
            bool habilitadoEliminar = false;

            if (personaSeleccionada != null )
            {
                habilitadoEliminar = true;
            }
            return habilitadoEliminar;
        }

        private void eliminarCommandExecute()
        {
            listaPersonas.Remove(personaSeleccionada);
            NotifyPropertyChanged("ListaPersonas");
        }

        private void buscarCommandExecute()
        {
            throw new NotImplementedException();
        }
        #endregion


        #region propiedades
        public DelegateCommand BuscarCommand 
        { get { return buscarCommand; } }

        public DelegateCommand DelegateCommand 
        { get { return eliminarCommand; } }

        public List <clsPersona> ListaPersonas
        { get { return listaPersonas; } }

        public clsPersona PersonaSeleccionada
        {  get { return personaSeleccionada; } }

        public string TextoBusqueda
        { get { return textoBusqueda; } }


        #endregion

        #region comandos

        #endregion

        #region Metodos y funciones

        #endregion
    }
}
