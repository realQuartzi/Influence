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

        static List<Sprite> registeredSprites = new List<Sprite>();
        public static void RegisterSprite(Sprite sprite) => registeredSprites.Add(sprite);
        public static void UnRegisterSprite(Sprite sprite) => registeredSprites.Remove(sprite);

        public Influence(int width, int height, string title)
        {
            this.width = width;
            this.height = height;
            this.title = title;
            this.targetFramerate = 60;

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

            for (int i = 0; i < registeredSprites.Count; i++)
            {
                graphics.FillRectangle(new SolidBrush(Color.Red), registeredSprites[i].position.x, registeredSprites[i].position.y, registeredSprites[i].scale.x, registeredSprites[i].scale.y);
            }
        }
        protected abstract void Update();
        protected abstract void FixedUpdate();
        protected abstract void LateUpdate();

        #endregion
    }
}
