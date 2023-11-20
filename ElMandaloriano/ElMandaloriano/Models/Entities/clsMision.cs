namespace ElMandaloriano.Models.Entities
{
    public class clsMision
    {

        #region atributos
        private string tituloMision;
        private string descripcionMision;
        private string recompensa;
        #endregion

        #region constructores
        /// <summary>
        /// constructor sin param entrada con valores default = empty
        /// </summary>
        public clsMision() {
            this.tituloMision = "";
            this.descripcionMision = "";
			this.recompensa = "";
		}
        #endregion

        /// <summary>
        /// constructor con param entrada
        /// </summary>
        /// <param name="tituloMision"></param>
        /// <param name="descripcionMision"></param>
        /// <param name="recompensa"></param>
        public clsMision(string tituloMision, string descripcionMision, string recompensa)
        {
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.recompensa = recompensa;
        }

        #region propiedades
        public string TituloMision
        {
            get { return tituloMision;}
        }

        public string DescripcionMision
        {
            get { return descripcionMision; }
        }

        public string Recompensa
        {
            get { return recompensa; }
        }
        #endregion
    }
}
