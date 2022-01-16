using System;

namespace DIO.Produtos
{
    public class Produtos : EntidadeBase
    {
        // Atributos
		private Classificacao Classificacao { get; set; }
		private string Descricao { get; set; }
		private string Cor { get; set; }
		private int Tamanho { get; set; }
        private bool Excluido {get; set;}

        // Métodos
		public Produtos(int id, Classificacao classificacao, string descricao, string cor, int tamanho)
		{
			this.Id = id;
			this.Classificacao = classificacao;
			this.Descricao = descricao;
			this.Cor = cor;
			this.Tamanho = tamanho;
            this.Excluido = false;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Classificação: " + this.Descricao + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Cor: " + this.Cor + Environment.NewLine;
            retorno += "Tamanho: " + this.Tamanho + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			return retorno;
		}

        public string retornaDescricao()
		{
			return this.Descricao;
		}

		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}