using NP.Utilities.Attributes;
using TestServiceInterfaces;

namespace TextService
{
    [Implements(typeof(ITextService), IsSingleton = true)]
    public class TextService : ITextService
    {
        public event Action<string>? SentTextEvent;

        public void Send(string text)
        {
            SentTextEvent?.Invoke(text);
        }
    }
}