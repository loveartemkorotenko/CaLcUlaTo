namespace CaLcUlaTo;

public class Tokenizer
{
    public static CustomQueue Tokenize(string expression)
    {
        CustomQueue tokens = new CustomQueue();
        string buffer = "";

        foreach (var c in expression)
        {
            if (char.IsLetterOrDigit(c) || c == '.' || c == ',')
            {
                buffer += c;          
            }
            else if (char.IsWhiteSpace(c))
            {
                if (buffer != "")
                {
                    AddBufferToQueue(buffer, tokens);
                    buffer = "";                
                }
            }
            else
            {
                if (buffer != "")
                {
                    AddBufferToQueue(buffer, tokens); 
                    
                    buffer = "";               
                }
                
                if (c == '(' )
                {
                    tokens.Enqueue(new Token(c.ToString(), TokenType.LeftParenthesis));
                }
                else if (c == ')' )
                {
                    tokens.Enqueue(new Token(c.ToString(), TokenType.RightParenthesis));
                }
                else
                {
                    tokens.Enqueue(new Token(c.ToString(), TokenType.Operator));
                }
            }
        } 
        if (buffer != "")
        {
            AddBufferToQueue(buffer, tokens);
        }

        return tokens;
    }

    private static void AddBufferToQueue(string buffer, CustomQueue tokens)
    {
        if (char.IsLetter(buffer[0]))
        {
            tokens.Enqueue(new Token(buffer, TokenType.Function));
        }
        else
        {
            tokens.Enqueue(new Token(buffer, TokenType.Number));
        }
    }
}