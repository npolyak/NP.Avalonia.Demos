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

        // saved value is retrieved from and saved to
        // the _savedTextBlock
        private string? SavedValue
        {
            get => _savedTextBlock.Text;
            set => _savedTextBlock.Text = value;
        }

        // NewValue is retrieved from and saved to
        // the _textBox
        private string? NewValue
        {
            get => _textBox.Text;
            set => _textBox.Text = value;
        }

        public MyUserControl()
        {
            InitializeComponent();

            // set _cancelButton and its Click event handler
            _cancelButton = this.FindControl<Button>("CancelButton");
            _cancelButton.Click += OnCancelButtonClick;

            // set _saveButton and its Click event handler
            _saveButton = this.FindControl<Button>("SaveButton");
            _saveButton.Click += OnSaveButtonClick;

            // set the TextBlock that contains the Saved text
            _savedTextBlock = this.FindControl<TextBlock>("SavedTextBlock");

            // set the TextBox that contains the new text
            _textBox = this.FindControl<TextBox>("TheTextBox");

            // initial New and Saved values should be the same
            NewValue = SavedValue;

            // every time the text changes, we should check if
            // Save and Cancel buttons should be enabled or not
            _textBox.GetObservable(TextBox.TextProperty).Subscribe(OnTextChanged);
        }

        // On Cancel, the TextBox value should become the same as SavedValue
        private void OnCancelButtonClick(object? sender, RoutedEventArgs e)
        {
            NewValue = SavedValue;
        }

        // On Save, the Saved Value should become the same as the TextBox Value
        private void OnSaveButtonClick(object? sender, RoutedEventArgs e)
        {
            SavedValue = NewValue;

            // also we should reset the IsEnabled states of the buttons
            OnTextChanged(null);
        }


        private void OnTextChanged(string? obj)
        {
            bool canSave = NewValue != SavedValue;

            // _cancelButton as _saveButton are enabled if TextBox'es value
            // is not the same as saved value and disabled otherwise.
            _cancelButton.IsEnabled = canSave;
            _saveButton.IsEnabled = canSave;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
