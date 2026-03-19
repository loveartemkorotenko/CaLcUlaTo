namespace CaLcUlaTo;

public class CustomQueue
{
    private string[] _array = new string[10];

    private int _pointer = 0;

    public void Enqueue(string element)
    {
        if (_pointer == _array.Length)
        {
            var extendedArray = new string[_array.Length * 2];

            for (var i = 0; i < _array.Length; i++)
            {
                extendedArray[i] = _array[i];
            }

            _array = extendedArray;
        }

        _array[_pointer] = element;

        _pointer += 1;
    }

    public string Dequeue()
    {
        if (_pointer == 0)
        {
            return null;
        }

        string value = _array[0];

        for (var j = 0; j < _pointer - 1; j++)
        {
            _array[j] = _array[j + 1];
        }

        _pointer -= 1;
        
        _array[_pointer] = null;
        
        return value;
    }

    public string Peek()
    {
        if (_pointer == 0)
        {
            return null;
        }

        return _array[0];
    }

    public bool IsEmpty => _pointer == 0;

    public int Count()
    {
        return _pointer;
    }

}    
