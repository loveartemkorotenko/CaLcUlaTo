namespace CaLcUlaTo;

public class Tokenizer()
{
    public enum TokenType {Number, Operator, Parenthesis}

    public struct Token
    {
        public TokenType Type;
        public string Value;
        public override string ToString() => $"{Type}: {Value}";
    }
    
    
}