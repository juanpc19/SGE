using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class clsMarca

    {
        #region atributos

        private int id;
        private string nombre;

        #endregion

        #region constructores
        public clsMarca() {
            id = 0;
            nombre = string.Empty;
        }
        public clsMarca(int id, string nombre) { 
            this.id = id;   
            this.nombre = nombre;   
        }
        #endregion

        #region propiedades
        public int Id { get { return id; } set { id = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        #endregion
    }
}
