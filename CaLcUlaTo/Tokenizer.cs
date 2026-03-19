namespace CaLcUlaTo;

public class Tokenizer
{
    public static CustomQueue Tokenize(string expression)
    {
        CustomQueue tokens = new CustomQueue();
        string buffer = "";

        foreach (var c in expression)
        {
            if (char.IsLetterOrDigit(c))
            {
                buffer += c;
            }
            else if (char.IsWhiteSpace(c))
            {
                if (buffer != "")
                {
                    tokens.Enqueue(new Token(buffer, TokenType.Number));
                    buffer = "";
                }
            }
            else
            {
                if (buffer != "")
                {
                    tokens.Enqueue(new Token(buffer, TokenType.Number));
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
            tokens.Enqueue(new Token(buffer, TokenType.Number));
        }

        return tokens;
    }
}