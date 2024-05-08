class Calculadora
{
    public static double DoOperation(double num1, double num2, string op)
    {
        // Valor padrão para não número
        double resultado = double.NaN;

        switch (op)
        {
            case "a":
                resultado = num1 + num2;
                break;
            case "s":
                resultado = num1 - num2;
                break;
            case "m":
                resultado = num1 * num2;
                break;
            case "d":
                // Perguntar ao usuário para digitar um valor diferente de zero(0)
                if (num2 != 0)
                {
                    resultado = num1 / num2;
                }
                break;

            default:
                break;
        }
        return resultado;
    } 
}

class Programa
{
    static void Main(string[] args)
    {
        bool encerrar_app =false;

        // Exibir nome do programa
        Console.WriteLine("Calculadora de Console em C#\r");
        Console.WriteLine("------------------------\n");

        while (!encerrar_app) {

            // Declarar as variáveis e iniciá-las com vazias
            string numInput1 = "";
            string numInput2 = "";
            double resultado = 0;

            // Perguntar ao usuário para digitar o primeiro número
            Console.Write("Digite um número, após pressione Enter: ");
            numInput1 = Console.ReadLine();


            double cleanNum1 = 0;
            while (!double.TryParse(numInput1, out cleanNum1))
            {
                Console.Write("Esse não é um número válido, por favor: ");
                numInput1 = Console.ReadLine();
            }

            // Perguntar ao usuário para digitar o segundo número
            Console.Write("Digite um número, após pressione Enter: ");
            numInput2 = Console.ReadLine();

            double cleanNum2 = 0;
            while (!double.TryParse(numInput2, out cleanNum2))
            {
                Console.Write("Esse não é um número válido, por favor: ");
                numInput2 = Console.ReadLine();
            }

            // Perguntar ao usuário para escolher uma operação
            Console.WriteLine("Escolhe a operação que deseja executar:");
            Console.WriteLine("\ta - Soma");
            Console.WriteLine("\ts - Subtração");
            Console.WriteLine("\tm - Multiplicação");
            Console.WriteLine("\td - Divisão");
            Console.Write("Sua escolha? ");

            string op = Console.ReadLine();

              try
            {
                resultado = Calculadora.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(resultado))
                {
                    Console.WriteLine("Essa operação resultará em um erro matemático.\n");
                }
                else Console.WriteLine("Seu resultado: {0:0.##}\n", resultado);
            }
            catch (Exception e)
            {
                Console.WriteLine("Aconteceu uma exceção ao executar a operação.\n - Detalhes: " + e.Message);
            }

            Console.WriteLine("------------------------\n");

            // Wait for the user to respond before closing.
            Console.Write("Digite 'n' e Enter para fechar o programa, ou pressione a tecla Enter para continuar: ");
            if (Console.ReadLine() == "n") encerrar_app = true;

            Console.WriteLine("\n"); // Fechamento de linha
        }
    }
}