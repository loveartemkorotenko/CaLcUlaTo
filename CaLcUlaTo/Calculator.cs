namespace CaLcUlaTo;

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
                double right = double.Parse(stack.Pull().Value);
                
                double left = double.Parse(stack.Pull().Value);

                double result = 0;

                switch (token.Value)
                {
                    case "+": 
                        result = left + right; 
                        break;
                    
                    case "-": 
                        result = left - right; 
                        break;
                    
                    case "*": 
                        result = left * right; 
                        break;
                    
                    case "/":
                        if (right == 0) throw new DivideByZeroException("На нуль ділити не можна");
                        result = left / right;
                        break;
                    
                    case "^":
                        result = Math.Pow(left, right);
                        break;
                    
                    default:
                        throw new ArgumentException($"Unknown operator: {token.Value}");
                }
                stack.Push(new Token(result.ToString(), TokenType.Number));
            }
        }
        Token finalToken = stack.Pull();
        return double.Parse(finalToken.Value);
    }
}