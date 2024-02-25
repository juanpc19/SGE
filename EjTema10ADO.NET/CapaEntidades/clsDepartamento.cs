using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsDepartamento
    {
        #region atributos
        private int id;
        private string nombreDep;
        #endregion

        #region construtores
        public clsDepartamento()
        {
            id = 0;
            nombreDep = "";
        }

        public clsDepartamento(int id, string nombreDep)
        {
            this.id = id;
            this.nombreDep = nombreDep;   
        }
        #endregion

        #region propiedades
        public int Id {  get { return id; } set { id = value; } }
        public string NombreDep { get {  return nombreDep; } set { nombreDep = value; } }
        #endregion

    }
}
