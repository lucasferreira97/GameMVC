using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMVC.ViewModels
{
    public class ComputadoresFormViewModel
    {
        public Computador Computador { get; set; }
        public string Title
        {
            get
            {
                if (Computador != null && Computador.Id != 0)
                    return "Editar Computador";

                return "Novo Computador";
            }
        }
    }
}