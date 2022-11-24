using Gtk;

namespace LinuxApp
{
    public class MainWindow : Window
    {
        private const string vmKey = "VM";
        ClickCounterViewModel _vm = new ClickCounterViewModel();
        Gtk.Label _label = new Gtk.Label();

        Gtk.Button _button;

        public Button TheButton { get; }

        public MainWindow() : base(WindowType.Toplevel)
        {
            Gtk.Grid grid = new Gtk.Grid();

            grid.Visible = true;
            this.Add(grid);

            VBox box = new VBox()
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            box.Visible = true;

            grid.Add(box);

            _vm.PropertyChanged += _vm_PropertyChanged;

            _label.Data[vmKey] = _vm;
            _label.Text = _vm.NumberClicksStr;
            _label.Hexpand = true;
            _label.Halign = Align.Center;
            _label.Vexpand = true;
            _label.Valign = Align.Center;
            _label.Visible = true;
            _label.Margin = 20;

            box.Add(_label);

            TheButton = new Gtk.Button("ClickMe!");
            TheButton.Hexpand = true;
            TheButton.Halign = Align.Center;
            TheButton.Vexpand = true;
            TheButton.Valign = Align.Center;
            TheButton.Visible = true;

            box.Add(TheButton);

            TheButton.Clicked += Button_Clicked;

            this.Show();
        }


        private void _vm_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _label.Text = _vm.NumberClicksStr;
        }

        private void Button_Clicked(object? sender, EventArgs e)
        {
            _vm.IncreaseNumberClicks();
        }
    }
}
