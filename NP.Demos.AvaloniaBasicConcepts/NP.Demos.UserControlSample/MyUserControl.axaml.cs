using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using System;

namespace NP.Demos.UserControlSample
{
    public partial class MyUserControl : UserControl
    {
        private TextBox _textBox;
        private TextBlock _savedTextBlock;
        private Button _cancelButton;
        private Button _saveButton;

        private string? SavedValue
        {
            get => _savedTextBlock.Text;
            set => _savedTextBlock.Text = value;
        }

        private string? NewValue
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public MyUserControl()
        {
            InitializeComponent();

            _cancelButton = this.FindControl<Button>("CancelButton");
            _cancelButton.Click += _cancelButton_Click;

            _saveButton = this.FindControl<Button>("SaveButton");
            _saveButton.Click += _saveButton_Click;


            _savedTextBlock = this.FindControl<TextBlock>("SavedTextBlock");

            _textBox = this.FindControl<TextBox>("TheTextBox");

            NewValue = SavedValue;

            _textBox.GetObservable(TextBox.TextProperty).Subscribe(OnTextChanged);
        }

        private void _cancelButton_Click(object? sender, RoutedEventArgs e)
        {
            NewValue = SavedValue;
        }

        private void _saveButton_Click(object? sender, RoutedEventArgs e)
        {
            SavedValue = NewValue;

            OnTextChanged(null);
        }

        private void OnTextChanged(string? obj)
        {
            bool canSave = NewValue != SavedValue;
            _cancelButton.IsEnabled = canSave;
            _saveButton.IsEnabled = canSave;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
