using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Gtk;
using MyGtkApp;
using System;

public static class Widgets{

    [DllImport("File_structure.so")]
    private static extern void main_file_grabber();
public static class GlobalState{
    public static List<string> ignore_list = new();
    public static ListStore? listStore;

    
    public static ListStore start_folder = new ListStore(typeof(string));

}
public static Window CreateWindow(){
        Window window = new("Hello, C#");
        window.SetDefaultSize(800, 600);
        window.SetPosition(WindowPosition.Center);
        window.DeleteEvent += delegate { Application.Quit(); };
        return window;
    }


public static void OnExclusionsButtonPress(object? sender, EventArgs e)
    {
        string? result = FileOpener.place_path_in_ignore();
        // Action to take when the button is clicked
        MessageDialog already_selected = new(
            null,
            DialogFlags.Modal,
            MessageType.Info,
            ButtonsType.Ok,
            "That path has already been selected"
        );
        MessageDialog starter = new(
            null,
            DialogFlags.Modal,
            MessageType.Info,
            ButtonsType.Ok,
            "That path is your starting folder"
        );
        if (!string.IsNullOrEmpty(result)){
            if (GlobalState.ignore_list.Contains(result)){
                already_selected.Run();
                already_selected.Destroy();
                return;
            }
            else if (GetStartFolder() == result){
                starter.Run();
                starter.Destroy();
                return;
            }
            GlobalState.ignore_list.Add(result);
            GlobalState.listStore?.AppendValues(result);
        }
    }
public static string? GetStartFolder()
{
    if (GlobalState.start_folder.GetIterFirst(out TreeIter iter)) // Check if there's a value
    {
        return (string)GlobalState.start_folder.GetValue(iter, 0); // Get the first column value
    }
    return null; // If no value exists, return null
}

public static void Onstartpress(object? sender, EventArgs e)
    {
        string? result = FileOpener.place_path_in_start();
        // Action to take when the button is clicked
        MessageDialog in_exclusions = new(
            null,
            DialogFlags.Modal,
            MessageType.Info,
            ButtonsType.Ok,
            "That path has been excluded already."
        );
        if (!string.IsNullOrEmpty(result)){
            if (GlobalState.ignore_list.Contains(result)){
                in_exclusions.Run();
                in_exclusions.Destroy();
                return;
            }
            else{
                GlobalState.start_folder.Clear();
                GlobalState.start_folder.AppendValues(result);
                return;
            }
            
            
        }
    }
public static ScrolledWindow Exclusions(){
        ScrolledWindow scrolledWindow = new()
        {
            WidthRequest = 400,
            HeightRequest = 250,
            Halign = Align.Start,
        };
        
        TreeView treeView = new();
        GlobalState.listStore = new ListStore(typeof(string), typeof(string)); // Two columns of string type
        
        
        // Add columns to the TreeView
        TreeViewColumn column1 = new() { Title = "Exclusions: " };
        
        // Create cell renderers for each column
        CellRendererText cell1 = new();

        column1.PackStart(cell1, true);
        
        // Bind cell renderers to data in the ListStore
        column1.AddAttribute(cell1, "text", 0);
        
        // Add columns to the TreeView
        treeView.AppendColumn(column1);

        // Set the model for the TreeView
        treeView.Model = GlobalState.listStore;

        // Add the TreeView to the scrolled window
        scrolledWindow.Add(treeView);

        return scrolledWindow;
    }

public static Button Scan(){
        Button scan = new("Scan")
        {
            WidthRequest = 100,
            HeightRequest = 50,
            Halign = Align.Center,
        };


        return scan;
    }
public static ScrolledWindow ScanMainFolder(){
        ScrolledWindow scrolledWindow = new()
        {
            WidthRequest = 200,
            HeightRequest = 50,
            Halign = Align.Start,
        };
        
        TreeView treeView = new();
        
        GlobalState.start_folder = new ListStore(typeof(string), typeof(string)); // Two columns of string type
        
        // Add columns to the TreeView
        TreeViewColumn column1 = new() { Title = "Start Folder: " };
        
        // Create cell renderers for each column
        CellRendererText cell1 = new();
        column1.PackStart(cell1, true);
        
        // Bind cell renderers to data in the ListStore
        column1.AddAttribute(cell1, "text", 0);
        
        // Add columns to the TreeView
        treeView.AppendColumn(column1);

        // Set the model for the TreeView
        treeView.Model = GlobalState.start_folder;

        // Add the TreeView to the scrolled window
        scrolledWindow.Add(treeView);

        return scrolledWindow;
    }
}

