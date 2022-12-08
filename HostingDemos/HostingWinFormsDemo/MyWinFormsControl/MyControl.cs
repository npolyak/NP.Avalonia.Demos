using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MyWinFormsControl
{
    public partial class MyControl: UserControl
    {
        // the view model.
        ClickCounterViewModel _viewModel = new ClickCounterViewModel();

        public MyControl()
        {
            InitializeComponent();

            // call _viewModel.IncreaseNumberClicks();
            // on a button click
            MyButton.Click += MyButton_Click!;
            
            // set the initial value for the label
            SetLabel();

            // trigger the label change on NumberClicks change within the view model
            _viewModel.PropertyChanged += _viewModel_PropertyChanged!;
        }

        // calls SetLabel (to set the Label) when NumberClickStr property changes 
        // on the view model
        private void _viewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ClickCounterViewModel.NumberClicksStr))
            {
                SetLabel();
            }
        }

        // sets the ClickCounter label's text from the NumberClicksStr property
        private void SetLabel()
        {
            this.ClickCounter.Text = _viewModel.NumberClicksStr;
        }

        // button click handler that calls IncreaseNumberClicks on the view model
        private void MyButton_Click(object sender, EventArgs e)
        {
            _viewModel.IncreaseNumberClicks();
        }
    }
}
