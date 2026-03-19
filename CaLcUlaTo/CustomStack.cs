namespace CaLcUlaTo;

public class CustomStack
{
    private const int Capacity = 50;

    private string[] _array = new string[Capacity];

    private int _pointer;

    public void Push(string value)
    {
        if (_pointer == _array.Length)
        {
            throw new Exception("Stack is full");
        }

        _array[_pointer] = value;

        _pointer++;
        
    }

    public string Pop()
    {
        if (_pointer == 0)
        {
            return null;
        }

        _pointer--;

        var value = _array[_pointer];

        _array[_pointer] = null;

        return value;
        
    }

    public string Peek()
    {
        if (_pointer == 0)
        {
            return null;
        }

        return _array[_pointer - 1];

    }
    public bool IsEmpty => _pointer == 0;
    
    public int Count()
    {
        return _pointer;
    }
}