using System;

namespace Banco
{
    public class Conta
    {
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome) {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        private void imprimeSaldo () {
            Console.WriteLine($"Saldo atual da conta de {this.Nome} é {this.Saldo}");
        }

        public bool Sacar (double valorSaque) {
            if (this.Saldo - valorSaque < (this.Credito *-1)) {
                Console.WriteLine("Saldo Insuficiente");
                return false;
            }

            this.Saldo -= valorSaque;
            this.imprimeSaldo();
            return true;
        }

        public void Depositar(double valorDeposito) {
            this.Saldo += valorDeposito;
            this.imprimeSaldo();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino) {
            if (this.Sacar(valorTransferencia)) {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + "\n";
            retorno += "Nome " + this.Nome + "\n";
            retorno += "Saldo " + this.Saldo + "\n";
            retorno += "Crédito " + this.Credito + "\n";
            return retorno;
        }

    }
}