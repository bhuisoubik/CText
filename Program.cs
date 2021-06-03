using Terminal.Gui;
using NStack;

namespace CText
{
    class Program
    {
        public static string FilePath = "";

        static void Main(string[] args)
        {
            Application.Init();
            var top = Application.Top;

            if(args.Length > 0) {
                FilePath = args[0];
            }
            
            var win = new WinFrame();
            var window = win.Render();
            top.Add(window);

            var ml = new MenuList();

            var textBox = new TextBox();
            var textboxview = textBox.Render(new TextBoxOption{
                FilePath=FilePath,
            });

            top.Add(ml.RenderAll(new MenuOption{
                Top = top,
                Textview = textboxview,
            }));

            var bar = new Bar();
            top.Add(bar.Render(textboxview, top));
            window.Add(textboxview);
            Application.Run();
        }

    }
}
