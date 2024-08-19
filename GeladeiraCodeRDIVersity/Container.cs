﻿using Domain;

namespace GeladeiraCodeRDIVersity
{
    public class Container : IContainer
    {

        private const int limiteItens = 4;
        private readonly List<Item> _itens;

        public int NumeroDeContainer { get; private set; }

        public Container(int numeroContainer, int capacidade = limiteItens)
        {
            NumeroDeContainer = numeroContainer;
            _itens = new List<Item?>(new Item?[capacidade]);
        }

        public void RemoverItemDoConatiner(int posicao)
        {
            if (posicao < 0 || posicao >= limiteItens)
            {
                Console.WriteLine("Posição incorreta");
                return;
            }
            if (_itens[posicao] == null || _itens[posicao].Id == null)
            {
                Console.WriteLine($"Essa posição {posicao} vazia");
                return;
            }
            _itens[posicao] = null;
            Console.WriteLine($"Item removido da posição {posicao}");
        }

        public void AdicionarItem(int posicao, Item item)
        {
            if (posicao < 0 || posicao >= limiteItens)
            {
                Console.WriteLine("Posição inválida.");
                return;
            }
            if (item == null)
            {
                Console.WriteLine("Item inválido.");
                return;
            }
            if (_itens[posicao] != null)
            {
                Console.WriteLine($"A posição {posicao} já está ocupada.");
                return;
            }
            _itens[posicao] = item;
            Console.WriteLine($"Item adicionado à posição {posicao}.");
        }

        public void AdicionarItens(List<Item> itens)
        {
            foreach (var item in itens)
            {
                for (int i = 0; i < _itens.Count; i++)
                {
                    if (_itens[i] == null)
                    {
                        _itens[i] = item;
                        break;
                    }
                }
            }
        }

        public void ExibirItens()
        {
            Console.WriteLine($"Container {NumeroDeContainer}:");
            for (int posicao = 0; posicao < limiteItens; posicao++)
            {
                var item = _itens[posicao];
                if (item != null)
                {
                    Console.WriteLine($"Posição {posicao}: {item.Classificacao}");
                }
            }
        }

        public bool EstaCheio()
        {
            return _itens.All(item => item != null && item.Id != null);
        }

        public bool EstaVazio()
        {
            return _itens.All(item => item == null || item.Id == null);
        }

        public void EsvaziarGeladeira()
        {
            _itens.Clear();
            Console.WriteLine($"Itens removidos dos containers.");
        }

    }
}

//controla a lista de itens