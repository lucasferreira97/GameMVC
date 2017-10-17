using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMVC.ViewModels
{
    public class GamesFormViewModel
    {
        public Game Game { get; set; }
        public string Title
        {
            get
            {
                if (Game != null && Game.Id != 0)
                    return "Editar Game";

                return "Novo Game";
            }
        }
    }
}