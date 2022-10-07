using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;

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
        int targetFramerate;
        float previousTime;

        Window window = null;
        Thread gameLoopThread = null;
        Thread inputThread = null;

        Color backgroundColor = Color.Black;

        public Vector2 cameraPosition = new Vector2();

        static List<GameObject> registeredGameObject = new List<GameObject>();
        public static void RegisterGameObject(GameObject sprite) => registeredGameObject.Add(sprite);
        public static void UnRegisterGameObject(GameObject sprite) => registeredGameObject.Remove(sprite);

        public Influence(int width, int height, string title = "")
        {
            this.width = width;
            this.height = height;

            if (title == "")
                title = "New Project";

            this.title = title;
            this.targetFramerate = 60;

            InitializeGame();
        }
        public Influence(Vector2Int dimensions, string title = "")
        {
            Debug.Info("Developing Game Window...");

            this.width = dimensions.x;
            this.height = dimensions.y;

            if (title == "")
                title = "New Project";

            this.title = title;
            this.targetFramerate = 60;

            InitializeGame();
        }

        void InitializeGame()
        {
            Debug.Info("Initializing Game Window..");

            window = new Window();
            window.Size = new Size(width, height);
            window.Text = title;
            window.Paint += Renderer;

            inputThread = new Thread(InputLoop);
            inputThread.Start();

            gameLoopThread = new Thread(Run);
            gameLoopThread.Start();

            Application.Run(window);
        }

        #region GameLoop

        void Run()
        {
            Debug.Info("Starting game loop");

            Initialize();

            Awake();

            Start();

            while(gameLoopThread.IsAlive)
            {
                Time.deltaTime = Time.time - previousTime;

                Update();
                
                if((Time.time - Time.fixedTime) > (1f / 30f))
                {
                    Time.fixedDeltaTime = Time.time - Time.fixedTime;
                    Time.fixedTime = Time.time;

                    FixedUpdate();
                }

                window.BeginInvoke((MethodInvoker)delegate { window.Refresh(); });

                LateUpdate();
                Input.ClearAll();

                float passedTime = 1f / targetFramerate;

                previousTime = Time.time;
                Time.time += passedTime;
                Thread.Sleep((int)(passedTime * 100));
            }
        }

        void InputLoop()
        {
            window.KeyDown += KeyDown;
            window.KeyUp += KeyUp;
            window.MouseDown += MouseDown;
            window.MouseUp += MouseUp;
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(backgroundColor);

            graphics.TranslateTransform(cameraPosition.x, cameraPosition.y);

            for (int i = 0; i < registeredGameObject.Count; i++)
            {
                for(int j = 0; j < registeredGameObject[i].Components.Count; j++)
                {
                    registeredGameObject[i].Components[j].Render(graphics);
                }
            }


        }

        private void KeyDown(object sender, KeyEventArgs e)
        {
            if(!Input.keyDownInputs.Contains(e.KeyCode))
                Input.keyDownInputs.Add(e.KeyCode);
        }

        private void KeyUp(object sender, KeyEventArgs e)
        {
            if (Input.keyDownInputs.Contains(e.KeyCode))
                Input.keyDownInputs.Remove(e.KeyCode);

            if(!Input.keyUpInputs.Contains(e.KeyCode))
                Input.keyUpInputs.Add(e.KeyCode);
        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            if(!Input.mouseDownInputs.Contains(e.Button))
                Input.mouseDownInputs.Add(e.Button);
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            if (Input.mouseDownInputs.Contains(e.Button))
                Input.mouseDownInputs.Remove(e.Button);

            if (!Input.mouseUpInputs.Contains(e.Button))
                Input.mouseUpInputs.Add(e.Button);
        }


        protected abstract void Initialize();
        protected abstract void Awake();
        protected abstract void Start();

        protected abstract void Update();

        protected abstract void FixedUpdate();
        protected abstract void LateUpdate();


        #endregion
    }
}
