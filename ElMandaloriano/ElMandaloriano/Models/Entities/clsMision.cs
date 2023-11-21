namespace ElMandaloriano.Models.Entities
{
    public class clsMision
    {

        #region atributos
        private string id;
        private string tituloMision;
        private string descripcionMision;
        private string recompensa;
        #endregion

        #region constructores
        /// <summary>
        /// constructor sin param entrada con valores default = empty
        /// </summary>
        public clsMision() {
            
		}

        /// <summary>
        /// constructor con param entrada
        /// </summary>
        /// <param name="tituloMision"></param>
        /// <param name="descripcionMision"></param>
        /// <param name="recompensa"></param>
        public clsMision(string id, string tituloMision, string descripcionMision, string recompensa)
        {
            this.id = id;
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.recompensa = recompensa;
        }
        #endregion

        #region propiedades

        public string Id
        {
            get { return id; }
        }

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
