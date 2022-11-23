using System;
using Gtk;

namespace LinuxApp;

public static class Program
{
    public static Application App;
    public static Window Win;


    [STAThread]
    public static void Main(string[] args)
    {
        Application.Init();

        App = new Application("NP.Demos", GLib.ApplicationFlags.None);
        App.Register(GLib.Cancellable.Current);

        Win = new MainWindow();
        App.AddWindow(Win);


        Win.Show();


        Application.Run();
    }
}