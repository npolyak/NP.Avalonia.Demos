using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace NP.Demos.BindingInCodeSample
{
    public partial class MainWindow : Window
    {
        TextBox _textBox;
        TextBlock _textBlock;
        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
            _textBox = this.FindControl<TextBox>("TheTextBox");
            _textBlock = this.FindControl<TextBlock>("TheTextBlock");

            Button bindButton = this.FindControl<Button>("BindButton");
            bindButton.Click += BindButton_Click;

            Button unbindButton = this.FindControl<Button>("UnbindButton");
            unbindButton.Click += UnbindButton_Click;
        }

        IDisposable? _bindingSubscription;
        private void BindButton_Click(object? sender, RoutedEventArgs e)
        {
            if (_bindingSubscription == null)
            {
                _bindingSubscription =
                    _textBlock.Bind(TextBlock.TextProperty, new Binding { Source = _textBox, Path = "Text" });

                // The following line will also do the trick, but you won't be able to unbind.
                //_textBlock[!TextBlock.TextProperty] = _textBox[!TextBox.TextProperty];
            }
        }

        private void UnbindButton_Click(object? sender, RoutedEventArgs e)
        {
            _bindingSubscription?.Dispose();
            _bindingSubscription = null;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
