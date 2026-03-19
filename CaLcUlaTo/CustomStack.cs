namespace CaLcUlaTo;

public class CustomStack
{
    private const int Capacity = 50;
    
    private Token[] _array = new Token[Capacity];
    
    private int _pointer;
    
    public void Push(Token value)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Stack overflowed");
        }

        _array[_pointer] = value;
        
        _pointer++;
    }
    
    public Token Pull()
    {
        if (_pointer == 0) return null;

        _pointer--;
        
        Token value = _array[_pointer];
        
        _array[_pointer] = null;
            
        return value;
    }

    public Token Peek()
    {
        if (_pointer == 0) return null;
        
        return _array[_pointer - 1];
    }

    public bool IsEmpty => _pointer == 0;
}