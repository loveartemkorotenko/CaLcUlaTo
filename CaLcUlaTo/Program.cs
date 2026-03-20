namespace CaLcUlaTo;

class Program
{
    static void Main(string[] args)
    {
        string expression = "";
        
        if (args.Length > 0)
        {
            expression = string.Join(" ", args);
        }
        else
        {
            Console.WriteLine("Введіть арифметичний вираз:");
            expression = Console.ReadLine();
        }
        
        if (string.IsNullOrWhiteSpace(expression))
        {
            Console.WriteLine("Вираз не може бути порожнім");
            return;
        }
        expression = expression.Replace(" ", ""); 
        
        expression = expression.Replace("(-", "(0-"); 
        
        if (expression.StartsWith("-"))
        {
            expression = "0" + expression;
        }

        try
        {
            CustomQueue tokens = Tokenizer.Tokenize(expression);
            
            CustomQueue postfixQueue = ShuntingYard.InfixToPostfix(tokens);
            
            double result = Calculator.Evaluate(postfixQueue);
            
            Console.WriteLine($"Результат: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка під час обчислення: {ex.Message}");
        }
    }
}