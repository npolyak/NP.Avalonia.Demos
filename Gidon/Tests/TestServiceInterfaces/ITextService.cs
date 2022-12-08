namespace TestServiceInterfaces
{
    public interface ITextService
    {
        public void Send(string text);

        public event Action<string> SentTextEvent;
    }
}