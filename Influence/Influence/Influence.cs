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

        Color backgroundColor = Color.Black;

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

                float passedTime = 1f / targetFramerate;

                previousTime = Time.time;
                Time.time += passedTime;
                Thread.Sleep((int)(passedTime * 100));
            }
        }

        protected abstract void Initialize();
        protected abstract void Awake();
        protected abstract void Start();

        private void Renderer(object Sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(backgroundColor);

            for (int i = 0; i < registeredGameObject.Count; i++)
            {
                if(registeredGameObject [i] is Shape sprite)
                {
                    graphics.FillRectangle(new SolidBrush(sprite.color),
                        sprite.transform.position.x, sprite.transform.position.y,
                        sprite.size.x * sprite.transform.scale.x, sprite.size.y * sprite.transform.scale.y);
                }
                
            }
        }
        protected abstract void Update();
        protected abstract void FixedUpdate();
        protected abstract void LateUpdate();

        #endregion
    }
}
