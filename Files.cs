using System.IO;
using Terminal.Gui;

namespace CText
{
    internal class FileS
    {
        public void Write(TextView tb)
        {
            if (Program.FilePath != "")
            {
                File.WriteAllText(Program.FilePath, tb.Text.ToString());
            }
        }

        public void Open(TextView tb)
        {
            var dialog = new OpenDialog("Open", "Open a File")
            {
                FilePath = Program.FilePath,
                AllowedFileTypes = null
            };
            Application.Run(dialog);
            if(dialog.FilePaths.ToString() != null) {
                Program.FilePath = dialog.FilePath.ToString();
                tb.Text = File.ReadAllText(Program.FilePath);    
            }
        }

        public void SaveAs(TextView tb)
        {
            var dialog = new SaveDialog("Save", "Save a File") 
            {
                FilePath = Program.FilePath,
                AllowedFileTypes = null
            };
            Application.Run(dialog);
            if(dialog.FileName != null) {
                Program.FilePath = dialog.FileName.ToString();
                Write(tb);
            }
        }
    }
}