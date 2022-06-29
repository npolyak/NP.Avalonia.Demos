using NP.Utilities;
using NP.Utilities.Attributes;
using NP.Utilities.PluginUtils;
using TestServiceInterfaces;

namespace EnterTextViewModelPlugin;

[Implements(typeof(IPlugin), partKey: nameof(EnterTextViewModel), isSingleton: true)]
public class EnterTextViewModel : VMBase, IPlugin
{
    // ITextService implementation
    [Part(typeof(ITextService))]
    public ITextService? TheTextService { get; private set; }

    #region Text Property
    private string? _text;

    // notifiable property
    public string? Text
    {
        get
        {
            return this._text;
        }
        set
        {
            if (this._text == value)
            {
                return;
            }

            this._text = value;
            this.OnPropertyChanged(nameof(Text));
            this.OnPropertyChanged(nameof(CanSendText));
        }
    }
    #endregion Text Property

    // change notified the Text changes
    public bool CanSendText => !string.IsNullOrWhiteSpace(this._text);

    // method to send the text via TextService
    public void SendText()
    {
        if (!CanSendText)
        {
            throw new Exception("Cannost send text, this method should not have been called.");
        }

        TheTextService!.Send(Text!);
    }
}
