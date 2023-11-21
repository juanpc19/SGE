namespace ElMandaloriano.Models.Entities
{
    public class clsMision
    {

        #region atributos
        private int id;
        private string tituloMision;
        private string descripcionMision;
        private string recompensa;
        #endregion

        #region constructores
        /// <summary>
        /// constructor sin param entrada
        /// </summary>
        public clsMision() {
		
		}
		/// <summary>
		///    /// constructor con param entrada
		/// </summary>
		/// <param name="id"></param>
		/// <param name="tituloMision"></param>
		/// <param name="descripcionMision"></param>
		/// <param name="recompensa"></param>
		public clsMision(int id, string tituloMision, string descripcionMision, string recompensa)
        {
            this.id = id;
            this.tituloMision = tituloMision;
            this.descripcionMision = descripcionMision;
            this.recompensa = recompensa;
        }
        #endregion

        #region propiedades

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string TituloMision
        {
            get { return tituloMision;}
            set { tituloMision = value; }
        }

        public string DescripcionMision
        {
            get { return descripcionMision; }
            set {  descripcionMision = value; }
        }

        public string Recompensa
        {
            get { return recompensa; }
            set { recompensa = value; }
        }
        #endregion
    }
}
