using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class clsModelo
    {
        #region atributos
        private int id;
        private int idMarca;
        private string nombre;
        private int precio;
        #endregion

        #region constructores 
        public clsModelo()
        {
            id = 0;
            idMarca = 0;    
            nombre = string.Empty;
            precio = 0;
        }

        public clsModelo(int id, int idMarca, string nombre, int precio)
        {
            this.id = id;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;
        }


        #endregion

        #region propiedades
        public int Id { 
            get { return id; }
            set {  id = value; } 
        }

        public int IdMarca { 
            get { return idMarca; }
            set { idMarca = value; } 
        } 

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Precio
        {
            get { return precio; }
            set { precio = value; }
        }
        #endregion
    }
}
