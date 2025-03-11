using System.Net;
using System.Runtime.Serialization;
using Gtk;
using MyGtkApp;

class Program
{

    static Button Button_for_exclusions(){
        Button button = new("+")
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Halign = Align.Center,
        };
        
        button.Clicked += Widgets.OnExclusionsButtonPress;

        return button;
    }

    static Button Button_for_start(){
        Button button = new("+")
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Halign = Align.Center,
        };
        
        button.Clicked += Widgets.Onstartpress;

        return button;
    }

    static Button Main_Run(){
        Button runner = new("Start")
        {
            WidthRequest = 50,
            HeightRequest = 50,
            Halign = Align.Center,
        };
        
        runner.Clicked += Widgets.OnExclusionsButtonPress;
        return runner;
    }
    


    static void Main(string[] args)
{
    Application.Init();

    // Create a new window
    Gtk.Window window = Widgets.CreateWindow();

    Box vbox_main = new(Orientation.Vertical, 10);

    // Create a vertical box layout
    Box vbox_exclusions = new(Orientation.Vertical, 10)
    {
        Halign = Align.Start,
        Valign = Align.End
    };
    // Create a horizontal box layout for buttons
    Box hbox_exclusions = new(Orientation.Horizontal, 10)
    {
        Halign = Align.Start,
        Valign = Align.End
    };

    Box Main_scanner_hbox = new(Orientation.Horizontal, 10)
    {
        Halign = Align.Center,
        Valign = Align.Start
    };

    Box Main_scanner_vbox = new(Orientation.Vertical, 10)
    {
        Halign = Align.Center,
        Valign = Align.Start
    };

    // Create buttons
    Button buttonIgnore = Button_for_exclusions();
    Button Scanner = Widgets.Scan();
    Button buttonstart = Button_for_start();

    // Add buttons to the horizontal layout
    hbox_exclusions.PackStart(buttonIgnore, false, false, 5);
    Main_scanner_vbox.PackStart(Scanner, false, false, 5);

    ScrolledWindow Exclusions = Widgets.Exclusions();
    ScrolledWindow Scanner_start = Widgets.ScanMainFolder();

    // Add the horizontal box to the vertical box
    vbox_exclusions.PackStart(hbox_exclusions, false, false, 10);

    // Add TreeView

    vbox_exclusions.PackStart(Exclusions, false, true, 10);
    Main_scanner_hbox.PackStart(Scanner_start, false, true, 10);
    Main_scanner_hbox.PackStart(buttonstart, false, false, 10);


    Main_scanner_vbox.PackStart(Main_scanner_hbox, false, false, 10);
    vbox_main.PackStart(Main_scanner_vbox, false, false, 10);
    vbox_main.PackStart(vbox_exclusions, false, false, 10);

    // Add the layout to the window
    window.Add(vbox_main);

    // Show all widgets
    window.ShowAll();
    Application.Run();
}

}   

    

