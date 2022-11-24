using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyWinFormsControl
{
    public partial class MyControl: UserControl
    {
        ClickCounterViewModel _viewModel = new ClickCounterViewModel();

        public MyControl()
        {
            InitializeComponent();

            MyButton.Click += MyButton_Click;

            SetLabel();
            _viewModel.PropertyChanged += _viewModel_PropertyChanged;
        }

        private void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClickCounterViewModel.NumberClicksStr))
            {
                SetLabel();
            }
        }

        private void SetLabel()
        {
            this.ClickCounter.Text = _viewModel.NumberClicksStr;
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            _viewModel.IncreaseNumberClicks();
        }
    }
}
