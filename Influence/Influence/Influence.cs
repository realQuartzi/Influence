using System.Windows.Forms;
using System.Drawing;

namespace Influence
{
    class Window : Form
    {
        public Window()
        {
            this.DoubleBuffered = true;
        }
    }

    public abstract class Influence
    {
        int width;
        int height;
        string title;

        Window window = null;

        public Influence(int width, int height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;

            window = new Window();
            window.Size = new Size(width, height);
            window.Text = title;

            Application.Run(window);
        }
    }
}
