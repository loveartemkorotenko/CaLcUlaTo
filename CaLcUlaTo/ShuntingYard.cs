namespace CaLcUlaTo;

public class ShuntingYard
{
    private static int Priorities(string op)
    {
        switch (op)
        {
            case "^":
                return 3;
            case "*":
            case "/":
                return 2;
            case "+":
            case "-":
                return 1;
            default:
                return 0;
        }
    }
    private static bool IsRightAssociative(string op)
    {
        return op == "^";
    }

    public static CustomQueue InfixToPostfix(CustomQueue infixTokens)
    {
        CustomQueue postfixQueue = new CustomQueue();

        CustomStack operatorStack = new CustomStack();

        while (!infixTokens.IsEmpty)
        {
            Token token = infixTokens.Dequeue();

            if (token.Type == TokenType.Number)
            {
                postfixQueue.Enqueue(token);
            }
            else if (token.Type == TokenType.Function)
            {
                operatorStack.Push(token);
            }
            else if (token.Type == TokenType.LeftParenthesis)
            {
                operatorStack.Push(token);
            }
            else if (token.Type == TokenType.RightParenthesis)
            {
                while (!operatorStack.IsEmpty && operatorStack.Peek().Type != TokenType.LeftParenthesis)
                {
                    postfixQueue.Enqueue(operatorStack.Pull());
                }

                if (!operatorStack.IsEmpty && operatorStack.Peek().Type == TokenType.LeftParenthesis)
                {
                    operatorStack.Pull();
                }
                if (!operatorStack.IsEmpty && operatorStack.Peek().Type == TokenType.Function)
                {
                    postfixQueue.Enqueue(operatorStack.Pull());
                }
            }
            else if (token.Type == TokenType.Operator)
            {
                while (!operatorStack.IsEmpty && operatorStack.Peek().Type == TokenType.Operator)
                {
                    Token topOperator = operatorStack.Peek();
                    
                    int precedenceToken = Priorities(token.Value);
                    
                    int precedenceTop = Priorities(topOperator.Value);  
                    
                    if (precedenceTop > precedenceToken || precedenceTop == precedenceToken && !IsRightAssociative(token.Value))
                    {

                        postfixQueue.Enqueue(operatorStack.Pull());
                    }
                    else
                    {
                        break; 
                    }
                }
                
                operatorStack.Push(token);
            }
        }
        
        while (!operatorStack.IsEmpty)
        {
            postfixQueue.Enqueue(operatorStack.Pull());
        }

        return postfixQueue;
    }
}
    