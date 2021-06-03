using Terminal.Gui;

namespace CText {
    internal class Bar {
        public StatusBar Render(TextView view, Toplevel top) {
            var files = new FileS();
            var item1 = new StatusItem(Key.N | Key.CtrlMask, "~CTRL-N~ New File", () => {
                var n = MessageBox.Query("New File", "This will remove all local changes. Are you sure you want to continue ?", "Yes", "No");
                if(n == 0) {
                    Program.FilePath = "";
                    view.Text = "";    
                }
            });
            var item2 = new StatusItem(Key.O | Key.CtrlMask, "~CTRL-O~ Open File", () => {
                files.Open(view);
            });
            var item3 = new StatusItem(Key.S | Key.CtrlMask, "~CTRL-S~ Save File", () => {
                if(Program.FilePath == "") {
                    files.SaveAs(view);
                } else {
                    files.Write(view);
                }
            });
            var item4 = new StatusItem(Key.O | Key.CtrlMask, "~CTRL-Q~ Quit", () => {
                var n = MessageBox.Query(50, 7, "Exit CText", "Are you sure you want to exit ?", "Yes", "No");
                if(n == 0) {
                    top.Running = false;
                }
            });
            return new StatusBar(new StatusItem[] {
                item1,
                item2,
                item3,
                item4,
            }){Visible=true,};
        }
    }
}