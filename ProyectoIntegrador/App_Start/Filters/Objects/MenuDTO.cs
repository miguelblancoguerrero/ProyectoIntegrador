using ProyectoIntegrador.Models.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoIntegrador.App_Start.Filters.Objects
{
    public class MenuDTO
    {
        public Menu Datos { get; set; }
        public bool EsPadre { get; set; }
        public List<MenuDTO> Hijos { get; set; }

        public MenuDTO(Menu datos)
        {
            if (datos.Padre == null)
            {
                this.EsPadre = true;
                this.Hijos = new List<MenuDTO>();
            }
            this.Datos = datos;
        }
    }
}