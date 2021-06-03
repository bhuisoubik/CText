using System.IO;
using Terminal.Gui;

struct TextBoxOption {
    public string FilePath;
}


namespace CText {
    internal class TextBox {
        public TextView Render(TextBoxOption opt) {
            var tv = new TextView(){
                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            if(opt.FilePath != ""){
                tv.Text = File.ReadAllText(opt.FilePath);
            }
            
            return tv;
        }
    }
}