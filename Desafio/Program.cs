using System.Text.Json;

Console.WriteLine("\nQuestão 1");
int indice = 13;
int soma = 0;
int k = 0;

for (int i = 0; k < indice; i++)
{
    k++;
    soma += k;
}

Console.WriteLine($"O valor de k é: {k}");


//---------------segunda questão----------------------

Console.WriteLine("\nQuestão 2");
Console.WriteLine("Criei um metodo para ficar mais facíl de se reutilizar esse codigo, mas poderia ter feito sem o metodo/função");
Console.WriteLine("Informe um número:");
int numero = int.Parse(Console.ReadLine());

if (verifica(numero))
{
    Console.WriteLine($"O numero {numero} pertence a sequência de fibonacci.");
}
else
{
    Console.WriteLine($"O numero {numero} não pertence a sequência de fibonacci.");
}


bool verifica(int numero)
{
    if (numero < 0) return false;

    int a = 0;
    int b = 1;

    while (a <= numero)
    {
        if (a == numero)
        {
            return true;
        }

        int x = a;
        a = b;
        b = x + b;
    }
    return false;
}


//---------------terceira questão---------------------------
Console.WriteLine("\nQuestão 3");

string json = @"[
            { ""dia"": 1, ""valor"": 22174.1664 },
            { ""dia"": 2, ""valor"": 24537.6698 },
            { ""dia"": 3, ""valor"": 26139.6134 },
            { ""dia"": 4, ""valor"": 0.0 },
            { ""dia"": 5, ""valor"": 0.0 },
            { ""dia"": 6, ""valor"": 26742.6612 },
            { ""dia"": 7, ""valor"": 0.0 },
            { ""dia"": 8, ""valor"": 42889.2258 },
            { ""dia"": 9, ""valor"": 46251.174 },
            { ""dia"": 10, ""valor"": 11191.4722 },
            { ""dia"": 11, ""valor"": 0.0 },
            { ""dia"": 12, ""valor"": 0.0 },
            { ""dia"": 13, ""valor"": 3847.4823 },
            { ""dia"": 14, ""valor"": 373.7838 },
            { ""dia"": 15, ""valor"": 2659.7563 },
            { ""dia"": 16, ""valor"": 48924.2448 },
            { ""dia"": 17, ""valor"": 18419.2614 },
            { ""dia"": 18, ""valor"": 0.0 },
            { ""dia"": 19, ""valor"": 0.0 },
            { ""dia"": 20, ""valor"": 35240.1826 },
            { ""dia"": 21, ""valor"": 43829.1667 },
            { ""dia"": 22, ""valor"": 18235.6852 },
            { ""dia"": 23, ""valor"": 4355.0662 },
            { ""dia"": 24, ""valor"": 13327.1025 },
            { ""dia"": 25, ""valor"": 0.0 },
            { ""dia"": 26, ""valor"": 0.0 },
            { ""dia"": 27, ""valor"": 25681.8318 },
            { ""dia"": 28, ""valor"": 1718.1221 },
            { ""dia"": 29, ""valor"": 0.0 },
            { ""dia"": 30, ""valor"": 0.0 }
        ]";

var faturamentoMensal = JsonSerializer.Deserialize<Faturamento[]>(json);

var faturamentosMaiorZero = faturamentoMensal.Where(f => f.Valor > 0).Select(f => f.Valor);
var mediaFaturamento = faturamentosMaiorZero.Average();

Console.WriteLine("Menor valor de faturamento: " + faturamentoMensal.Where(f => f.Valor > 0).Min(f => f.Valor));
Console.WriteLine("Maior valor de faturamento: " + faturamentoMensal.Max(f => f.Valor));
Console.WriteLine("Número de dias com faturamento acima da média: " + faturamentoMensal.Where(f => f.Valor > mediaFaturamento).Count());


////-------------quarta questão-------------------------

Console.WriteLine("\nQuestão 4");
double valorFaturamentoTotal = 0;

var faturamentoEstado = new Dictionary<string, double>()
{
     {"SP", 67836.43},
     {"RJ", 36678.66},
     {"MG", 29229.88},
     {"ES", 27165.48},
     {"Outros", 19849.53}
};

foreach (var valorEstado in faturamentoEstado.Values)
{
    valorFaturamentoTotal += valorEstado;
}

foreach (var estado in faturamentoEstado)
{
    double percentual = (estado.Value / valorFaturamentoTotal) * 100;
    Console.WriteLine($"O percentual no estado de {estado.Key} é de: {percentual}%"); //eu poderia ter colocado menos casas decimas, porém escolhi deixar todas, para mudar eu porederia ter feito isso: {percentual:F2}
}


////------------------------------quinta questão-----------------------------

Console.WriteLine("\nQuestão 5");
Console.WriteLine("Digite uma palavra");
string palavra = Console.ReadLine();

string palavraInveritda = "";

for (int i = palavra.Length - 1; i >= 0; i--)
{
    palavraInveritda += palavra[i];
}

Console.WriteLine($"palavra invertida: {palavraInveritda}");



class Faturamento
{
    [System.Text.Json.Serialization.JsonPropertyName("dia")]// Não vou negar, essa anotação tive que pegar no chatGpt pois eu não estava conseguindo linkar os dados do json com essa classe.
    public int Dia { get; set; }

    [System.Text.Json.Serialization.JsonPropertyName("valor")]
    public double Valor { get; set; }
}


