using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class clsModelo
    {
        #region atributos
        private int id;
        private int idMarca;
        private string nombre;
        private double precio;
        #endregion

        #region constructores
        public clsModelo()
        {
            id = 0;
            idMarca = 0;
            nombre = string.Empty;
            precio = 0.0;
        }

        public clsModelo(int id, int idMarca, string nombre, double precio)
        {
            this.id = id;
            this.idMarca = idMarca;
            this.nombre = nombre;
            this.precio = precio;

        }
        #endregion

        #region propiedades
        public int Id { get { return id; } set { id = value; } }
        public int IdMarca { get { return idMarca; } set { idMarca = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        #endregion
    }
}
