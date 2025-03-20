﻿using System;

class Lanchonete
{
    static string[] produtos = { "X-Burguer", "Refrigerante", "Sorvete" };
    static double[] precos = { 15.0, 5.0, 7.0 };
    static int[] quantidades = new int[produtos.Length];

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            ExibirMenu();
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("\nEntrada inválida. Pressione Enter para continuar.");
                Console.ReadLine();
                continue;
            }

            switch (opcao)
            {
                case 1:
                    ListarProdutos();
                    break;
                case 2:
                    AdicionarProduto();
                    break;
                case 3:
                    RemoverProduto();
                    break;
                case 4:
                    VisualizarPedido();
                    break;
                case 5:
                    FinalizarPedido();
                    return;
                default:
                    Console.WriteLine("\nOpção inválida. Pressione Enter para continuar.");
                    Console.ReadLine();
                    break;
            }
        } while (opcao != 5);
    }

    static void ExibirMenu()
    {
        Console.Clear();
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Listar produtos disponíveis");
        Console.WriteLine("2. Adicionar produto ao pedido");
        Console.WriteLine("3. Remover produto do pedido");
        Console.WriteLine("4. Visualizar pedido atual");
        Console.WriteLine("5. Finalizar pedido e sair");
        Console.Write("Escolha uma opção: ");
    }

    static void ListarProdutos()
    {
        Console.WriteLine("\nProdutos Disponíveis:");
        for (int i = 0; i < produtos.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {produtos[i]} - R$ {precos[i]:F2}");
        }
        Console.WriteLine("\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    static void AdicionarProduto()
    {
        ListarProdutos();

        Console.Write("Digite o número do produto que deseja adicionar: ");
        if (!int.TryParse(Console.ReadLine(), out int produtoIndex) || produtoIndex < 1 || produtoIndex > produtos.Length)
        {
            Console.WriteLine("\nProduto inválido. Pressione Enter para continuar.");
            Console.ReadLine();
            return;
        }

        Console.Write("Digite a quantidade: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("\nQuantidade inválida. Pressione Enter para continuar.");
            Console.ReadLine();
            return;
        }

        quantidades[produtoIndex - 1] += quantidade;
        Console.WriteLine($"Produto {produtos[produtoIndex - 1]} adicionado ao pedido.\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    static void RemoverProduto()
    {
        Console.WriteLine("\nPedido Atual:");
        bool pedidoVazio = true;

        for (int i = 0; i < produtos.Length; i++)
        {
            if (quantidades[i] > 0)
            {
                Console.WriteLine($"{i + 1}. {produtos[i]} x {quantidades[i]} - R$ {precos[i] * quantidades[i]:F2}");
                pedidoVazio = false;
            }
        }

        if (pedidoVazio)
        {
            Console.WriteLine("Nenhum produto no pedido.");
            Console.WriteLine("\nPressione Enter para continuar.");
            Console.ReadLine();
            return;
        }

        Console.Write("\nDigite o número do produto que deseja remover: ");
        if (!int.TryParse(Console.ReadLine(), out int produtoIndex) || produtoIndex < 1 || produtoIndex > produtos.Length || quantidades[produtoIndex - 1] == 0)
        {
            Console.WriteLine("Produto inválido ou não adicionado ao pedido. Pressione Enter para continuar.");
            Console.ReadLine();
            return;
        }

        Console.Write("Digite a quantidade a ser removida: ");
        if (!int.TryParse(Console.ReadLine(), out int quantidade) || quantidade <= 0)
        {
            Console.WriteLine("\nQuantidade inválida. Pressione Enter para continuar.");
            Console.ReadLine();
            return;
        }

        int index = produtoIndex - 1;
        if (quantidades[index] >= quantidade)
        {
            quantidades[index] -= quantidade;
            Console.WriteLine($"Produto {produtos[index]} removido do pedido.");
        }
        else
        {
            Console.WriteLine("Quantidade insuficiente no pedido.");
        }
        Console.WriteLine("\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    static void VisualizarPedido()
    {
        Console.WriteLine("\nPedido Atual:");
        double totalBruto = 0;
        bool pedidoVazio = true;

        for (int i = 0; i < produtos.Length; i++)
        {
            if (quantidades[i] > 0)
            {
                Console.WriteLine($"{i + 1}. {produtos[i]} x {quantidades[i]} - R$ {precos[i] * quantidades[i]:F2}");
                totalBruto += precos[i] * quantidades[i];
                pedidoVazio = false;
            }
        }

        if (pedidoVazio)
        {
            Console.WriteLine("Nenhum produto no pedido.");
        }

        Console.WriteLine($"Total Bruto: R$ {totalBruto:F2}\nPressione Enter para continuar.");
        Console.ReadLine();
    }

    static void FinalizarPedido()
    {
        double totalBruto = 0;
        int totalItens = 0;

        for (int i = 0; i < produtos.Length; i++)
        {
            if (quantidades[i] > 0)
            {
                totalItens += quantidades[i];
                totalBruto += precos[i] * quantidades[i];
            }
        }

        double desconto = totalBruto > 100 ? totalBruto * 0.10 : 0;
        double valorFinal = totalBruto - desconto;

        Console.WriteLine("\nResumo do Pedido:");
        Console.WriteLine($"Total de Itens: {totalItens}");
        Console.WriteLine($"Valor Bruto: R$ {totalBruto:F2}");
        Console.WriteLine($"Desconto: R$ {desconto:F2}");
        Console.WriteLine($"Valor Final a Pagar: R$ {valorFinal:F2}");
        Console.WriteLine("\nPedido finalizado! Obrigado pela compra.");
    }
}
