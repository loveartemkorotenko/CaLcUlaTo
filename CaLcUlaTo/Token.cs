namespace CaLcUlaTo;

public enum TokenType
{
    Number,
    Operator,
    LeftParenthesis,
    RightParenthesis,
    Function,
    ArgumentSeparator
}


public class Token
{
    public string Value;
    public TokenType Type;

    public Token(string value, TokenType type)
    {
        Value = value;
        
        Type = type;
    }
    
    public override string ToString()
    {
        return $"[{Type}: {Value}]";
    }
}