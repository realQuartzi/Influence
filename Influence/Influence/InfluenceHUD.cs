using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace Influence
{
    class HUD : Form
    {
        public HUD(bool doubleBuffered)
        {
            this.DoubleBuffered = doubleBuffered;
        }
    }

    public abstract class InfluenceHUD
    {
        int originalWidth;
        int originalHeight;

        public Vector2Int originalScreenSize => new Vector2Int(originalWidth, originalHeight);

        public int targetFramerate;
        float previousTime;

        HUD hud = null;
        public Form mainWindow => hud;

        public Vector2Int screenSize => new Vector2Int(mainWindow.Size.Width, mainWindow.Size.Height);
        public string Title => mainWindow.Text;

        Thread gameLoopThread = null;
        Thread inputThread = null;

        public Vector2 cameraPosition = new Vector2();

        static List<GameObject> registeredGameObject = new List<GameObject>();
        public static void RegisterGameObject(GameObject sprite) => registeredGameObject.Add(sprite);
        public static void UnRegisterGameObject(GameObject sprite) => registeredGameObject.Remove(sprite);

        static List<Collider> registeredCollider = new List<Collider>();
        public static List<Collider> RegisteredCollider => registeredCollider;
        public static void RegisterCollider(Collider collider) => registeredCollider.Add(collider);
        public static void UnRegisterCollider(Collider collider) => registeredCollider.Remove(collider);

        public InfluenceHUD()
        {
            Debug.Info("Developing Application HUD...");

            this.originalWidth = Screen.PrimaryScreen.WorkingArea.Size.Width;
            this.originalHeight = Screen.PrimaryScreen.WorkingArea.Size.Height;

            this.targetFramerate = 60;

            InitializeHUDApplication();
        }

        void InitializeHUDApplication()
        {
            Debug.Info("Initializing Application HUD...");

            hud = new HUD(false);

            hud.BackColor = hudColorKey;
            hud.Size = Screen.PrimaryScreen.WorkingArea.Size;
            hud.Location = new Point(0, 0);
            hud.TopMost = true;
            hud.AllowTransparency = true;
            hud.BackColor = hudColorKey;
            hud.TransparencyKey = hudColorKey;

            hud.ShowIcon = false;
            hud.ShowInTaskbar = false;
            hud.FormBorderStyle = FormBorderStyle.None;

            originalWindowStyle = (IntPtr)((long)((ulong)GetWindowLong(mainWindow.Handle, -20)));
            passThroughWindowStyle = (IntPtr)((long)((ulong)(GetWindowLong(mainWindow.Handle, -20) | 0x80000 | 0x20)));
            SetWindowPassthrough(true);

            hud.Paint += Renderer;
            hud.FormClosing += OnQuit;

            inputThread = new Thread(InputLoop);
            inputThread.Start();

            gameLoopThread = new Thread(Run);
            gameLoopThread.Start();

            Application.EnableVisualStyles();
            Application.Run(hud);
        }

        #region ApplicationLoop

        void Run()
        {
            Debug.Info("Starting Application Loop...");

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

                hud.BeginInvoke((MethodInvoker)delegate { hud.Refresh(); });

                LateUpdate();
                Input.ClearAll();

                float passedTime = 1f / targetFramerate;

                previousTime = Time.time;
                Time.time += passedTime;
                Thread.Sleep((int)(passedTime * 1000));
            }
        }

        void InputLoop()
        {
            hud.KeyDown += KeyDown;
            hud.KeyUp += KeyUp;
            hud.MouseDown += MouseDown;
            hud.MouseUp += MouseUp;
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(hudColorKey);

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

        private void OnQuit(object sender, FormClosingEventArgs e)
        {
            Debug.Info("Aborting Application Threads...");

            inputThread.Abort();
            gameLoopThread.Abort();
        }


        protected abstract void Initialize();
        protected abstract void Awake();
        protected abstract void Start();

        protected abstract void Update();
        protected abstract void FixedUpdate();
        protected abstract void LateUpdate();

        #endregion


        #region HUD Stuff

        static IntPtr originalWindowStyle;
        static IntPtr passThroughWindowStyle;

        static Color hudColorKey = Color.Coral;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern uint SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        void SetWindowPassthrough(bool passThrough)
        {
            if(passThrough)
            {
                SetWindowLong(mainWindow.Handle, -20, passThroughWindowStyle);
                return;
            }
            SetWindowLong(mainWindow.Handle, -20, originalWindowStyle);
        }

        #endregion
    }
}
