using Terminal.Gui;
using NStack;

namespace CText {
    internal class DialogView {
        public void About() {
            MessageBox.Query(50, 12, "About CText", "CText is a console based text editor made with .NET (C#) & Terminal.Gui (gui.cs)\n\n\nAuthor: Soubik Bhui (@soubikbhuiwk007)\nLicense: MIT\n\nCheckout github.com/soubikbhuiwk007/CText", "Ok");
        }

        public void Shortcut() {
            MessageBox.Query("ShortCut Keys", "Shift+N     New File\nShift+O     Open File\nShift+S     Save File\nShift+E     Save As\nShift+Q     Exit\nShift+C     Copy selected text\nShift+X     Cut selected text\nShift+V     Paste a pre-copied text\nShift+A     Select All\nShift+I     About\nShift+K     Show shortcut keys\nShift+G     View in Github\n", "Ok");
        }
    }
}