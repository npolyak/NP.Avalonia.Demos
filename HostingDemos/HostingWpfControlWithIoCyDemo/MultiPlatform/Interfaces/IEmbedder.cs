using Avalonia.Controls;

namespace Interfaces
{
    public interface IEmbedder : IControl
    {
        public object NativeObject { set; }
    }
}