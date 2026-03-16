namespace CaLcUlaTo;

public class CustomStack<T>
{
    private Node<T> top;

    public bool IsEmpty()
    {
        return top == null;
    }

    public void Push(T item)
    {
        Node<T> newNode = new Node<T>(item);

        newNode.Next = top;

        top = newNode;

    }

    public T Pop()
    {
        if (IsEmpty()) throw new InvalidOperationException("Стек пустий");
        
        T value = top.Value;
        
        top = top.Next;
        
        return value;
        
    }

    public T Peek()
    {
        if (IsEmpty()) throw new InvalidOperationException("У стеці немає елементів для перегляду");

        return top.Value;
    }
}