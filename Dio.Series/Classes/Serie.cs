using Dio.Series.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dio.Series.Classes
{
    class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie (int id, Genero genero, string titulo, string descricao, int ano) 
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }
        public string RetornaTitulo()
        {
            return this.Titulo;
        }
        public int RetornaId()
        {
            return this.Id;
        }
        public void Excluir()
        {
            this.Excluido = true;
        }
        public bool IsExcluido()
        {
            return this.Excluido;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno = retorno + "Gênero: " + this.Genero + Environment.NewLine;
            retorno = retorno + "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Lançamento: " + this.Ano;

            return retorno;
        }
    }
}
