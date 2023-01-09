using SDL2;

namespace Influence
{
    public abstract class Application
    {
        public static bool INITSDL_VIDEO = false;
        public static bool INITSDL_AUDIO = false;

        public static int targetFramerate = 60;
        double previousTime;

        public static ApplicationWindow? window;
        bool applicationActive;

        //Thread gameLoopThread;
        //Thread inputThread;

        static List<GameObject> registeredGameObject = new List<GameObject>();
        public static void RegisterGameObject(GameObject sprite) => registeredGameObject.Add(sprite);
        public static void UnRegisterGameObject(GameObject sprite) => registeredGameObject.Remove(sprite);

        public Application(int width, int height, string title = "")
        {
            if (window != null)
                return;

            window = new ApplicationWindow(width, height, title);

            InitializeApplication();
        }

        void InitializeApplication()
        {
#if DEBUG
            Debug.Info("Initializing Application...");
#endif

            applicationActive = true;
            ApplicationLoop();

            //gameLoopThread = new Thread();
            //gameLoopThread.Start();
        }

        void ApplicationLoop()
        {
#if DEBUG
            Debug.Info("Starting Application Loop...");
#endif

            SDL.SDL_Event e;

            Initialize();

            Awake();

            Start();

            while (applicationActive)
            {
                Time.deltaTime = Time.time - previousTime;

                while(window.PollEvents(out e))
                {
                    window.HandlePollEvents(e);
                }

                Update();

                if ((Time.time - Time.fixedTime) > (1f / 30f))
                {
                    Time.fixedDeltaTime = Time.time - Time.fixedTime;
                    Time.fixedTime = Time.time;

                    FixedUpdate();
                }

                Render();

                LateUpdate();
                //Input.ClearAll();

                float passedTime = 1f / targetFramerate;

                previousTime = Time.time;
                Time.time += passedTime;
                Thread.Sleep((int)(passedTime * 1000));
            }

            SDL.SDL_ClearError();
        }

        private void Render()
        {
            // Refresh Windows
            window?.Clear();

            // Set Background Color
            SDL.SDL_SetRenderDrawColor(window.RenderPtr, window.backgroundColor.r, window.backgroundColor.g, window.backgroundColor.b, window.backgroundColor.a);

            for (int i = 0; i < registeredGameObject.Count; i++)
            {
                for (int j = 0; j < registeredGameObject[i].Components.Count; j++)
                {
                    registeredGameObject[i].Components[j].Render(window);
                }
            }

            RenderUpdate();

            /*
            // Julie Heart
            Gizmos.DrawLine(window, new Vector2(128, 128), new Vector2(160, 160), Color.Blue);
            Gizmos.DrawLine(window, new Vector2(160, 160), new Vector2(192, 128), Color.Blue);
            Gizmos.DrawLine(window, new Vector2(192, 128), new Vector2(192+32, 180), Color.Blue);
            Gizmos.DrawLine(window, new Vector2(192 + 32, 180), new Vector2(160, 256), Color.Blue);
            Gizmos.DrawLine(window, new Vector2(160, 256), new Vector2(160-64, 180), Color.Blue);
            Gizmos.DrawLine(window, new Vector2(160 - 64, 180), new Vector2(128, 128), Color.Blue);
            */

            // Display
            window.Display();
        }

        protected abstract void Initialize();
        protected abstract void Awake();
        protected abstract void Start();

        protected abstract void Update();

        protected abstract void FixedUpdate();

        /// <summary>
        /// Run all Rendering related content in here! Or else it won't render!
        /// </summary>
        protected abstract void RenderUpdate();

        protected abstract void LateUpdate();
    }
}
