using System;
using System.Collections.Generic;

namespace Banco
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") {
                switch (opcaoUsuario) {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }
                opcaoUsuario = ObterOpcaoUsuario();
            }


        }

        private static void Transferir()
        {
            Console.WriteLine("Transferir");
            Console.WriteLine("Digite o número da conta de origem: ");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o número da conta de destino: ");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia: valorTransferencia,
                                                    contaDestino: listContas[indiceContaDestino]);
        }

        private static void Depositar()
        {
            Console.WriteLine("Depositar");
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.WriteLine("Sacar");
            Console.WriteLine("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0) {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for (int i = 0; i < listContas.Count; i++) {
                Conta conta = listContas[i];
                Console.WriteLine($"#{i} - ");
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova Conta");
            Console.WriteLine("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());
            
            Console.WriteLine("Digite o Credito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta c = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                saldo: entradaSaldo,
                                credito: entradaCredito,
                                nome: entradaNome);

            listContas.Add(c);
            
        }

        private static string ObterOpcaoUsuario() {
            
            Console.WriteLine();
            Console.WriteLine("Banco 1 Real");
            Console.WriteLine("Informe a Opção Desejada");
            Console.WriteLine("1 - Listar Contas");
            Console.WriteLine("2 - Inserir Nova Conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();

            return opcaoUsuario;

        }
    }
}
