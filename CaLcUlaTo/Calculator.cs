using System.Globalization;

namespace CaLcUlaTo;

using System;

public class Calculator
{
    public static double Evaluate(CustomQueue postfixQueue)
    {
        CustomStack stack = new CustomStack();

        while (!postfixQueue.IsEmpty)
        {
            Token token = postfixQueue.Dequeue();

            if (token.Type == TokenType.Number)
            {
                stack.Push(token);
            }
            else if (token.Type == TokenType.Operator)
            {
                Token rightToken = stack.Pull();
                
                Token leftToken = stack.Pull();
                
                if (rightToken == null || leftToken == null)
                    throw new Exception($"Не вистачає чисел для оператора {token.Value}");

                double right = double.Parse(rightToken.Value.Replace(',', '.'), CultureInfo.InvariantCulture);
                
                double left = double.Parse(leftToken.Value.Replace(',', '.'), CultureInfo.InvariantCulture);   
                
                double result = 0;

                switch (token.Value)
                {
                    case "+": result = left + right; break;
                    
                    case "-": result = left - right; break;
                    
                    case "*": result = left * right; break;
                    
                    case "/":
                        if (right == 0) throw new DivideByZeroException("На нуль ділити не можна");
                        result = left / right;
                        break;
                    
                    case "^": result = Math.Pow(left, right); break;
                    
                    default: throw new ArgumentException($"Unknown operator: {token.Value}");
                }
                
                stack.Push(new Token(result.ToString(), TokenType.Number));
            }
            else if (token.Type == TokenType.Function)
            {
                Token argToken = stack.Pull();
                
                if (argToken == null)
                    throw new Exception($"Не вистачає аргументу для функції {token.Value}");

                double arg = double.Parse(argToken.Value);
                
                double result = 0;

                switch (token.Value.ToLower())
                {
                    case "sin": result = Math.Sin(arg); break;
                    
                    case "cos": result = Math.Cos(arg); break;
                    
                    case "tan": result = Math.Tan(arg); break;
                    
                    default: throw new ArgumentException($"Unknown function: {token.Value}");
                }
                
                stack.Push(new Token(result.ToString(), TokenType.Number));
            }
        }
        
        Token finalToken = stack.Pull();
        if (finalToken == null) return 0;
        
        return double.Parse(finalToken.Value, CultureInfo.InvariantCulture);
    }
}