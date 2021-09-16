using Godot;
using System;

public class GDebug : Node
{

    public Label _label;

    public static GDebug Instance;
    
    public override void _Ready()
    {
        Instance = this;
        _label = this.GetNodeInChildren<Label>();
    }

    public void SetLabelText(string text)
    {
        _label.Text = text;
    }
    
    public static void Print(string text)
    {
        Instance.SetLabelText(text);
    }

}
