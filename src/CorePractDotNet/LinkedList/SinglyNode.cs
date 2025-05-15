namespace LinkedList
{
    public class SinglyNode<T>(T data)
    {
        public T Data { get; } = data;
        public SinglyNode<T> Next { get; set; } = null;
    }
}
