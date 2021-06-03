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
                    }),
                    new MenuItem("_Open", "Open a File", () => {
                        files.Open(opt.Textview);
                    }),
                    new MenuItem("_Save", "Save a File", () => {
                        if(Program.FilePath == "") {
                            files.SaveAs(opt.Textview);
                        } else {
                            files.Write(opt.Textview);
                        }
                    }),
                    new MenuItem("_Save As", "Save as", () => {
                        files.SaveAs(opt.Textview);
                    }),
                    new MenuItem("_Exit", "Quit", () => { 
                        if (Exit()) {
                            top.Running = false;
                        }
                    })
                }),
                new MenuBarItem("_Edit", new MenuItem[] {
                    new MenuItem("_Copy", "Copy the selected text", () => {
                        opt.Textview.Copy();
                    }),
                    new MenuItem("_Cut", "Cut the selected text", () => {
                        opt.Textview.Cut();
                    }),
                    new MenuItem("_Paste", "Paste", () => {
                        opt.Textview.Paste();
                    }),
                    new MenuItem("_Select All", "Select All text", () => {
                        opt.Textview.SelectAll();
                    }),
                }),
                new MenuBarItem("_Help", new MenuItem[] {
                    new MenuItem("_About", "About CText", () => {
                        dialogView.About();
                    }),
                    new MenuItem("_GitHub", "Open CText in GitHub", () => { 
                        OpenUrl("https://github.com/soubikbhuiwk007/CText"); 
                    }),
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