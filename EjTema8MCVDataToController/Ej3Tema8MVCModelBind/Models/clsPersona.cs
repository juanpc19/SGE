namespace Ej3Tema8MVCModelBind.Models
{
    public class clsPersona
    {
        #region atributos
        private int id;
        private string nombre;
        private string apellidos;
        private DateTime fechaNac;
        private string direccion;
        private int telefono;
		#endregion

		#region constructores
		public clsPersona()
        {
            id = 0;
            nombre = "";
            apellidos = "";
            fechaNac = DateTime.Now;
            direccion = "";
            telefono = 0;
        }

        public clsPersona(int id, string nombre, string apellidos, DateTime fechaNac, string direccion, int telefono)
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

        public int FechaNac
		{
            get { return FechaNac; }
            set { FechaNac = value;}
        }

		public int Direccion
		{
			get { return Direccion; }
			set { Direccion = value; }
		}

		public int Telefono
		{
			get { return Telefono; }
			set { Telefono = value; }
		}


		public string NombreCompleto
        {
            get { return nombre + " " + apellidos + " "; }
        }
        #endregion

        #region funciones
        /// <summary>
        /// Es una función que devuelve el nombre completo
        /// Precondiciones: El nombre y el apellido deben de empezar por mayuscula
        /// Poscondiciones: Ninguna
        /// </summary>
        /// <returns>String con nombre y apellidos completo</returns>
        public string FuncionNombreCompleto()
        {
            return $"El nombre completo es {nombre} {apellidos}";
        }
        #endregion
    }
}