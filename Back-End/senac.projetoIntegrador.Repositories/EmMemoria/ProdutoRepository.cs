﻿using senac.projetoIntegrador.Domain.Models;
using senac.projetoIntegrador.Domain.Repositories;

namespace senac.projetoIntegrador.Repositories.EmMemoria
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static List<Produto> _bancoDeDados = new List<Produto>
        {
            new Produto
            {
                Id = 1,
                Nome = "Classic Burguer",
                Descricao = "Um hambúrguer de carne grelhada, alface, tomate e queijo cheddar.",
                Preco = 9.99M,
                CaminhoImagem = "https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger5.png?raw=true",
                PalavrasChave = "alface, tomate, cheddar"
            },
            new Produto
            {
                Id = 2,
                Nome = "Cheesebuguer",
                Descricao = "Hambúrguer de carne, queijo, alface, tomate e maionese em um pão de hambúrguer.",
                Preco = 8.99M,
                CaminhoImagem = "https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger1.png?raw=true",
                PalavrasChave = "alface, tomate, maionese"
            },
            new Produto
            {
                Id = 3,
                Nome = "Bacon Burguer",
                Descricao = "Hambúrguer de carne coberto com bacon crocante, queijo, alface, tomate e maionese, servido em um pão de hambúrguer.",
                Preco = 9.99M,
                CaminhoImagem = "https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger2.png?raw=true",
                PalavrasChave = "bacon, queijo, alface, tomate"
            },
            new Produto
            {
                Id = 4,
                Nome = "Veggie Burguer",
                Descricao = "Hambúrguer vegetariano à base de vegetais, acompanhado de queijo, alface, tomate e maionese em um pão de hambúrguer.",
                Preco = 6.99M,
                CaminhoImagem = "https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger6.png?raw=true",
                PalavrasChave = "vegetais, queijo, alface, tomate"
            },
            new Produto
            {
                Id = 5,
                Nome = "Double Cheeseburger",
                Descricao = "Dois hambúrgueres de carne, dupla porção de queijo, alface, tomate e maionese, servidos em um pão de hambúrguer.",
                Preco = 10.99M,
                CaminhoImagem = "https://github.com/ruanwillians/senacProjeto/blob/main/Front-End/src/assets/burger4.png?raw=true"
            }
        };

        public int Create(Produto produto)
        {
            int maxId = _bancoDeDados.Max(t => t.Id);

            produto.Id = maxId + 1;
            _bancoDeDados.Add(produto);

            return produto.Id;
        }

        public void Delete(int id)
        {
            Produto produto = _bancoDeDados.FirstOrDefault(t => t.Id == id);
            _bancoDeDados.Remove(produto);
        }

        public List<Produto> List()
        {
            return _bancoDeDados;
        }

        public List<Produto> ListByKeyword(string palavraChave)
        {
            return _bancoDeDados
                .Where
                (
                    t => t.PalavrasChave != null && 
                    t.PalavrasChave.ToLower().Contains(palavraChave.ToLower())
                )
                .ToList();   
        }
    }
}