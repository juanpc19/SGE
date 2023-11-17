namespace Ej3Tema8MVCModelBind.Models
{
    public class clsPersona
    {
        #region atributos
        private int id;
        private string nombre;
        private string apellidos;
        private string fechaNac;
        private string direccion;
        private int telefono;
		#endregion

		#region constructores
		public clsPersona()
        {
            id = 1;
            nombre = "Juan";
            apellidos = "Pérez Caballero";
            fechaNac = "03/05/1994";
            direccion = "Calle Florencia";
            telefono = 656656656;
        }

        public clsPersona(int id, string nombre, string apellidos, string fechaNac, string direccion, int telefono)
		{
			this.id = id;
			this.nombre = nombre;
			this.apellidos = apellidos;
			this.fechaNac = fechaNac;
			this.direccion = direccion;
			this.telefono = telefono;
		}

		#endregion

		#region propiedades

		public int Id
		{
			get { return id; }

		}

		public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public string FechaNac
		{
            get { return fechaNac; }
            set { fechaNac = value;}
        }

		public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}

		public int Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}


        #endregion

        #region funciones
    
        #endregion
    }
}