using System.Diagnostics;
using System.Runtime.InteropServices;
using Terminal.Gui;

struct MenuOption {
    public Toplevel Top;
    public TextView Textview;

}

namespace CText
{

    internal class MenuList
    {
        public MenuBar RenderAll(MenuOption opt)
        {
            var top = opt.Top;
            var dialogView = new DialogView();
            var files = new FileS();
            return new MenuBar(new MenuBarItem[] {
                new MenuBarItem ("_File", new MenuItem[] {
                    new MenuItem("_New", "New File", () => {
                        var n = MessageBox.Query("New File", "This will remove all local changes. Are you sure you want to continue ?", "Yes", "No");
                        if(n == 0) {
                            Program.FilePath = "";
                            opt.Textview.Text = "";    
                        }
                    }, shortcut: Key.N),
                    new MenuItem("_Open", "Open a File", () => {
                        files.Open(opt.Textview);
                    }, shortcut: Key.O),
                    new MenuItem("_Save", "Save a File", () => {
                        if(Program.FilePath == "") {
                            files.SaveAs(opt.Textview);
                        } else {
                            files.Write(opt.Textview);
                        }
                    }, shortcut: Key.S),
                    new MenuItem("_Save As", "Save as", () => {
                        files.SaveAs(opt.Textview);
                    }, shortcut: Key.E),
                    new MenuItem("_Exit", "Quit", () => { 
                        if (Exit()) {
                            top.Running = false;
                        }
                    }, shortcut: Key.Q)
                }),
                new MenuBarItem("_Edit", new MenuItem[] {
                    new MenuItem("_Copy", "Copy the selected text", () => {
                        opt.Textview.Copy();
                    }, shortcut: Key.C),
                    new MenuItem("_Cut", "Cut the selected text", () => {
                        opt.Textview.Cut();
                    }, shortcut: Key.X),
                    new MenuItem("_Paste", "Paste", () => {
                        opt.Textview.Paste();
                    }, shortcut: Key.V),
                    new MenuItem("_Select All", "Select All text", () => {
                        opt.Textview.SelectAll();
                    }, shortcut: Key.A),
                }),
                new MenuBarItem("_Help", new MenuItem[] {
                    new MenuItem("_About", "About CText", () => {
                        dialogView.About();
                    }, shortcut:Key.I),
                    new MenuItem("_Shortcut Keys", "Show all shortcut keys", () => {
                        dialogView.Shortcut();
                    }, shortcut: Key.K),
                    new MenuItem("_GitHub", "Open CText in GitHub", () => { 
                        OpenUrl("https://github.com/soubikbhuiwk007/CText"); 
                    }, shortcut:Key.G),
                }),
            });
        }

        static bool Exit()
        {
            var n = MessageBox.Query(50, 7, "Exit CText", "Are you sure you want to exit ?", "Yes", "No");
            return n == 0;
        }

        private void OpenUrl(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }
    }
}