using System;

namespace E_PlayersMVC.Models
{
    public class Partida
    {
        public int IdPartida { get; set; }

        public int IdJogador1 { get; set; }

        public int IdJogador2 { get; set; }

        public DateTime Inicio { get; set; }

        public DateTime Termino { get; set; }


    }
}