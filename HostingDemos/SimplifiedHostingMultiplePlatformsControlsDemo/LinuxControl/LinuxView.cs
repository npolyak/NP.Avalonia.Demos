using Avalonia.Controls.Platform;
using Avalonia.Platform;
using Avalonia.X11.Interop;
using Gtk;
using PolyFills;
using System;
using ViewModels;

namespace LinuxControl
{
    public class LinuxView : Grid
    {
        private const string vmKey = "VM";
        ClickCounterViewModel _vm = new ClickCounterViewModel();
        Gtk.Label _label = new Gtk.Label();

        Gtk.Button _button;

        public LinuxView() : base() 
        {
            this.Visible = true;

            VBox box = new VBox()
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            box.Visible = true;

            this.Add(box);

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

            _button = new Gtk.Button("ClickMe!");
            _button.Hexpand = true;
            _button.Halign = Align.Center;
            _button.Vexpand = true;
            _button.Valign = Align.Center;
            _button.Visible = true;

            box.Add(_button);

            _button.Clicked += Button_Clicked;
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
