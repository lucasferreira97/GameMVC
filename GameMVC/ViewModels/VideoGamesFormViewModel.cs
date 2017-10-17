using GameMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameMVC.ViewModels
{
    public class VideoGamesFormViewModel
    {
        public VideoGame VideoGame { get; set; }
        public string Title
        {
            get
            {
                if (VideoGame != null && VideoGame.Id != 0)
                    return "Editar Video Game";

                return "Novo Video Game";
            }
        }
    }
}