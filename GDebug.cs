using Godot;

namespace StateMachineDemo
{
    public class GDebug : Node
    {

        private Label _label;

        private static GDebug _instance;
    
        public override void _Ready()
        {
            _instance = this;
            _label = this.GetNodeInChildren<Label>();
        }

        private void SetLabelText(string text)
        {
            _label.Text = text;
        }
    
        public static void Print(string text)
        {
            _instance.SetLabelText(text);
        }

    }
}
