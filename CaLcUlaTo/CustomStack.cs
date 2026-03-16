namespace CaLcUlaTo;

public class CustomStack<T>
{
    private Node<T> _top;

    public bool IsEmpty()
    {
        return _top == null;
    }

    public void Push(T item)
    {
        Node<T> newNode = new Node<T>(item);

        newNode.Next = _top;

        _top = newNode;

    }

    public T Pop()
    {
        if (IsEmpty()) 
            throw new InvalidOperationException("Стек пустий");
        
        T value = _top.Value;
        
        _top = _top.Next;
        
        return value;
        
    }

    public T Peek()
    {
        if (IsEmpty()) 
            throw new InvalidOperationException("У стеці немає елементів для перегляду");

        return _top.Value;
    }
}