using System;
using System.Collections.Generic;
using DIO.Produtos.Interfaces;

namespace DIO.Produtos
{

	public class ProdutoRepositorio : IRepositorio<Produtos>
	{
        private List<Produtos> listaProdutos = new List<Produtos>();
		public void AtualizaProduto(int id, Produtos objeto)
		{
			listaProdutos[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaProdutos[id].Excluir();
		}

		public void Insere(Produtos objeto)
		{
			listaProdutos.Add(objeto);
		}

		public List<Produtos> Lista()
		{
			return listaProdutos;
		}

		public int ProximoId()
		{
			return listaProdutos.Count;
		}

		public Produtos RetornaPorId(int id)
		{
			return listaProdutos[id];
		}
	}
}