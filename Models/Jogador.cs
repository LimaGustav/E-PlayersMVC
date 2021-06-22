using System;
using System.Collections.Generic;
using System.IO;
using E_PlayersMVC.Interfaces;

namespace E_PlayersMVC.Models
{
    public class Jogador : EPlayersBase, IJogador
    {
        public int IdJogador { get; set; }

        public string NomeJogador { get; set; }
        
        public int IdEquipe { get; set; }

        private const string CAMINHO = "Database/jogador.csv";
        
        public Jogador() {
            CriarPastaEArquivo(CAMINHO);
        }

        public string PrepararJogador(Jogador j) {
            return $"{j.IdEquipe};{j.NomeJogador};{j.IdEquipe}";
        }
        public void Criar(Jogador j)
        {
            string[] linha = {PrepararJogador(j)};
            File.AppendAllLines(CAMINHO,linha);
        }

        public List<Jogador> LerTodos()
        {
            List<Jogador> jogadores = new List<Jogador>();

            string[] linhas = File.ReadAllLines(CAMINHO);
            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Jogador jogador = new Jogador();
                jogador.IdJogador = Int32.Parse(linha[0]);
                jogador.NomeJogador = linha[1];
                jogador.IdEquipe = Int32.Parse(linha[2]);

                jogadores.Add(jogador);

            }

            return jogadores;
        }

        public void Alterar(Jogador j)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == j.IdJogador.ToString());
            linhas.Add(PrepararJogador(j));

            ReescreverCSV(CAMINHO,linhas);

        }

        public void Deletar(int id)
        {
            List<string> linhas = LerTodasLinhasCSV(CAMINHO);
            linhas.RemoveAll(x => x.Split(";")[0] == id.ToString());

            ReescreverCSV(CAMINHO,linhas);
        }
    }
}