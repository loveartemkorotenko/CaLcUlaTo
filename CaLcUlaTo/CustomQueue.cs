namespace CaLcUlaTo;

public class CustomQueue<T>
{
    private Node<T> _tail;

    private Node<T> _head;

    public bool IsEmpty()
    {
        return _head == null;
    }

    public void Enqueue(T item)
    {
        Node<T> newNode = new Node<T>(item);

        if (_tail == null)
        {
            _head = _tail = newNode;
            return;
        }

        _tail.Next = newNode;

        _tail = newNode;
    }

    public T Dequeue()
    {
        if (IsEmpty())
            throw new ArgumentException("Черга пуста, не можна прибрати елемент із черги");

        T value = _head.Value;
        
        _head = _head.Next;

        if (_head == null)
        {
            _tail = null;
        }

        return value;
    }
}