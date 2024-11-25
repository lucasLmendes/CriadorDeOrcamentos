
List<string> pecasAdicionadas = new List<string>();
List<string> servicosAdicionados = new List<string>();

string continuar = "";

string pecaOuServico = "";  
double totalOrcamento = 0;

System.Console.WriteLine("Digite o nome do cliente para o qual o orçamento será feito: ");
string nomeCliente = Console.ReadLine();

System.Console.WriteLine("Insira a marca e o modelo do carro: ");
string carro = Console.ReadLine();

Console.WriteLine("Agora digite a placa do carro: ");
string placaCarro = Console.ReadLine();

do
{

    System.Console.WriteLine("Digite 1 para adicionar peças, 2 para adicionar serviços, ou 0 para imprimir o orçamento: ");
    pecaOuServico = Console.ReadLine(); 
    if (pecaOuServico != "1" && pecaOuServico != "2" && pecaOuServico != "0") {
        Console.WriteLine("Por favor, insira uma opção válida. Números 1, 2 ou 0.");
    }
    

    if (pecaOuServico == "1")
    {
        do
        {
            Console.WriteLine("Descrimine a peça que deseja adicionar: ");
            string nomeDaPeca = Console.ReadLine() ?? "Peça em branco";

            System.Console.WriteLine("Quantas unidades deseja adicionar?");
            double quantidadeDePecas;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out quantidadeDePecas) && quantidadeDePecas > 0) {
                    break;
                }
                else {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            System.Console.WriteLine("Qual o valor unitário da peça?");
            double valorUnitario;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out valorUnitario) && valorUnitario > 0) {
                    break;
                }
                else {
                    System.Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            double valorTotal = valorUnitario * quantidadeDePecas;  

            totalOrcamento += valorTotal;

            string pecaAdicionada = $"{quantidadeDePecas}\t\t{nomeDaPeca}\t\t\t{valorUnitario:C2}\t\t\t{valorTotal:C2}";

            System.Console.WriteLine(pecaAdicionada);

            pecasAdicionadas.Add(pecaAdicionada);
            System.Console.WriteLine("Peça adicionada com sucesso. Insira 1 para adicionar mais uma peça ou 2 para terminar: ");
            continuar = Console.ReadLine() ?? "1";

        } while (continuar != "2");
    }
    else if (pecaOuServico == "2")
    {
        do
        {
            Console.WriteLine("Descrimine o serviço que deseja adicionar: ");
            string servico = Console.ReadLine() ?? "Não especificado";
            
            Console.WriteLine("Quantas unidades do serviço?");
            int quantidadeDeServico = 0;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out quantidadeDeServico) && quantidadeDeServico >= 0) {
                    break;
                }
                else {
                    Console.WriteLine("Por favor, insira um número válido.");
                }
            }

            Console.WriteLine("Qual o valor unitário do serviço?");
            double valorServico = 0;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out valorServico) && valorServico >= 0) {
                    break;
                }
                else {
                    System.Console.WriteLine("Por favor, insira um valor válido.");
                }
            } 

            double valorTotal = valorServico * quantidadeDeServico;

            totalOrcamento += valorTotal;

            string servicoAdicionado = $"{quantidadeDeServico}\t{servico}\t\t{valorServico:C2}\t\t{valorTotal:C2}";

            servicosAdicionados.Add(servicoAdicionado);

            System.Console.WriteLine("Serviço adicionado com sucesso. Insira 1 para adicionar mais um serviço ou 2 para terminar.");
            continuar = Console.ReadLine() ?? "1";

        } while (continuar != "2");
    }
} while (pecaOuServico  != "0");

Console.WriteLine($"Orçamento\nCliente: {nomeCliente}\nVeículo: {carro}\tPlaca: {placaCarro}");
Console.WriteLine("Produtos:");
Console.WriteLine("Quantidade\tProduto\t\t\tPreço Unitário\t\t\tTotal");
foreach (string peca in pecasAdicionadas)
{
    Console.WriteLine(peca);
}
Console.WriteLine("Serviços: ");
Console.WriteLine("Quantidade\tServiço\tPreço Unitário\tTotal");
foreach (string servico in servicosAdicionados)
{
    Console.WriteLine(servico);
}
Console.WriteLine($"Valor total do orçamento: {totalOrcamento}");