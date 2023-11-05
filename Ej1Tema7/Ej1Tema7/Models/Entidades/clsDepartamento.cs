namespace Ej1Tema7.Models.Entidades
{
    public class clsDepartamento
    {

        #region atributos
        private int idDepartamento;
        private string nombreDepartamento;
        #endregion atributos

        #region constructores
        public clsDepartamento() { 
            idDepartamento = 0;
            nombreDepartamento = "";
        }

        public clsDepartamento(int idDepartamento, string nombreDepartamento) { 
            this.idDepartamento=idDepartamento;
            this.nombreDepartamento=nombreDepartamento;
        }
        #endregion

        #region propiedades
        public int IdDepartamento
        {
            get { return idDepartamento; }
            set { idDepartamento = value;}
        }  

        public string NombreDepartamento
        {
            get { return nombreDepartamento;}
            set { nombreDepartamento = value;}
        }
        #endregion




    }
}
