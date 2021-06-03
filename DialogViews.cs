using Terminal.Gui;
using NStack;

namespace CText {
    internal class DialogView {
        public void About() {
            MessageBox.Query(50, 12, "About CText", "CText is a console based text editor made with .NET (C#) & Terminal.Gui (gui.cs)\n\n\nAuthor: Soubik Bhui (@soubikbhuiwk007)\nLicense: MIT\n\nCheckout github.com/soubikbhuiwk007/CText", "Ok");
        }
    }
}