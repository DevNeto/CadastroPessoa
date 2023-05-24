using Microsoft.VisualBasic;
using System;
using System.Data.Common;

namespace Pessoa
{
    internal class Program
    {
        // Método = ação
        // String = texto
        // var - declaração de variaveis
        static void Main(string[] args)
        {
            Console.WriteLine("Digite o nome da pessoa:");
            var nomePessoa = Console.ReadLine();

            Console.WriteLine("Digite seu ano de nascimento:");
            var dataNascimentoPessoa = Console.ReadLine();
            var dataNascimento = Convert.ToDateTime(dataNascimentoPessoa);

            var anoAtual = DateTime.Now.Year;
            var idade = anoAtual - dataNascimento.Year;

            Console.WriteLine("Digite a altura:");
            var altura = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Digite o peso:");
            var peso = Convert.ToDecimal(Console.ReadLine());

            var imc = Math.Round(peso / (altura * altura), 2);
            var classificacao = "";

            // Operadores
            // e = &&
            // ou = ||
            if (imc < (decimal)18.55)
            {
                classificacao = "abaixo do peso, coma mais, proveite a melhor coisa da vida";
            }
            else if (imc >= (decimal)18.55 && imc <= (decimal)24.99)
            {
                classificacao = "de parabéns. Você está com o peso ideal";
            }
            else if (imc > (decimal)24.99 && imc <= (decimal)29.99)
            {
                classificacao = "com sobrepeso, cuidado!!!. Faça mais exercicios e experimente fazer uma dietas";
            }
            else if (imc > (decimal)29.99 && imc <= (decimal)34.99)
            {
                classificacao = "sofrendo de obesidade (grau 1). Procure um nutricionista para te ajudar";
            }
               else if (imc > (decimal)34.99 && imc <= (decimal)39.99)
            {
                classificacao = "sofrendo de obesidade (grau 2). Procure um médico com urgência para te avaliar";
            }
                    else if (imc > (decimal)39.99)
                classificacao = "sofrendo de obesidade (grau 3). Procure um médico com urgência para te avaliar";

            
            
            Console.WriteLine("Digite o sálario bruto da pessoa");
            var salario = Convert.ToDouble(Console.ReadLine());
            var aliquota = 0.0;

            if (salario <= 1045.00)
            {
                aliquota = 7.5;
            }
            else if (salario > 1045.00 && salario <= 2089.60)
            {
                aliquota = 9;
            }
            else if (salario > 2089.60 && salario <= 3134.40)
            {
                aliquota = 12;
            }
            else
            {
                aliquota = 14;
            }

            var inss = (salario * aliquota) / 100;

            var salarioLiquido = salario - inss;

            var saldoDolar = Math.Round(salarioLiquido / 5.14, 2);

            Console.WriteLine("O nome e da pessoa é: " + nomePessoa);
            Console.WriteLine("A idade da pessoa " + nomePessoa + " é " + idade);
            Console.WriteLine("A porcentagem da alíquota para recolhimento ao INSS é: " + aliquota + ". O desconto do inss é: " + inss + ". Seu salário liquido é de: " + salarioLiquido + " e o seu salário em dolar é de: " + saldoDolar );
            Console.WriteLine("O imc da pessoa é: " + imc + ". E ela está " + classificacao);
           
            

        }

    }
}
