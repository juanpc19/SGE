namespace Ej1Tema7.Models.Entidades
{
    public class clsPersona
    {
        #region atributos
        private string nombre;
        private string apellidos;
        private int departamentoAsociado;
        #endregion

        #region constructores
        public clsPersona()
        {
            nombre = "";
            apellidos = "";
            departamentoAsociado = 0;
        }

        public clsPersona(string nombre, string apellidos)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
        }

        public clsPersona(string nombre, string apellidos, int idDepartamento)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.departamentoAsociado = idDepartamento;
        }
        #endregion

        #region propiedades
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

        public int DepartamentoAsociado
        {
            get { return departamentoAsociado;}
            set { departamentoAsociado = value;}
        }


        public string NombreCompleto
        {
            get { return nombre + " " + apellidos + " " + departamentoAsociado; }
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