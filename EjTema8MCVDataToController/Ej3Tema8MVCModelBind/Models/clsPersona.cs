using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        private string telefono;
		#endregion

		#region constructores
		public clsPersona()
        {
           
        }

        public clsPersona(int id, string nombre, string apellidos, string fechaNac, string direccion, string telefono)
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
        [HiddenInput(DisplayValue = false)] //lo sigue mostrando por uso de  <input type="text" id="inputId" name="Id" value="@Model.Id">
        public int Id
		{
			get { return id; }
            set { id = value; } // uso para instanciar en controller sino lo quitaria
        }

        [Required(ErrorMessage = "El campo nombre es obligatorio.")]
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

            [Required(ErrorMessage = "El campo apellidos es obligatorio.")]
            [StringLength(40, ErrorMessage = "El campo apellidos debe ser menor a 40 caracteres")]
            public string Apellidos
            {
                get { return apellidos; }
                set { apellidos = value; }
            }

        [RegularExpression(@"^\d{1,2}/\d{1,2}/\d{4}$", ErrorMessage = "Fecha nacimiento debe tener formato DD/MM/YYYY.")]
        public string FechaNac
		{
            get { return fechaNac; }
            set { fechaNac = value;}
        }

        [StringLength(200, ErrorMessage = "El campo direccion debe ser menor a 200 caracteres")]
        public string Direccion
		{
			get { return direccion; }
			set { direccion = value; }
		}

        [RegularExpression(@"^\+34.*", ErrorMessage = "El telefono debe empezar por: +34")]
        public string Telefono
		{
			get { return telefono; }
			set { telefono = value; }
		}
        #endregion

        #region funciones

        #endregion
    }
}