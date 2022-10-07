using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Influence
{
    static class Input
    {
        public static List<Keys> keyDownInputs = new List<Keys>();
        public static List<Keys> keyUpInputs = new List<Keys>();

        public static List<MouseButtons> mouseDownInputs = new List<MouseButtons>();
        public static List<MouseButtons> mouseUpInputs = new List<MouseButtons>();

        public static bool GetKeyDown(Keys key) => keyDownInputs.Contains(key); 

        public static bool GetKeyUp(Keys key) => keyUpInputs.Contains(key);

        public static bool GetMouseDown(MouseButtons button) => mouseDownInputs.Contains(button);

        public static bool GetMouseUp(MouseButtons button) => mouseUpInputs.Contains(button);

        public static void ClearAll()
        {
            keyUpInputs.Clear();

            mouseUpInputs.Clear();
        }

    }
}
