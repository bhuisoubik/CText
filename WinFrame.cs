using Terminal.Gui;

namespace CText {
    internal class WinFrame {
        public Window Render() {
            string app_name = "CText";
            var w = new Window(app_name){
                X = 0,
                Y = 1,

                Width = Dim.Fill(),
                Height = Dim.Fill(),
            };
            return w;
        }
    }
}