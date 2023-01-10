using SDL2;

namespace Influence
{
    public class ApplicationWindow
    {
        int originalWidth;
        int originalHeight;

        IntPtr windowPtr;
        public IntPtr WindowPtr => windowPtr;

        IntPtr renderPtr;
        public IntPtr RenderPtr => renderPtr;

        public Vector2Int originalScreenSize => new Vector2Int(originalWidth, originalHeight);
        public Color backgroundColor = Color.Black;

        public ApplicationWindow(int width, int height, string title = "")
        {
            InitSDLVideo();
            InitSDLAudio();

            windowPtr = SDL.SDL_CreateWindow(title,
                SDL.SDL_WINDOWPOS_CENTERED, SDL.SDL_WINDOWPOS_CENTERED,
                width, height,
                SDL.SDL_WindowFlags.SDL_WINDOW_RESIZABLE | SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

#if DEBUG
            Debug.Info("Window '" + title + "' created succesfully!");
#endif

            renderPtr = SDL.SDL_CreateRenderer(windowPtr, -1, SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED);

            if(windowPtr == IntPtr.Zero)
            {
                Debug.LogError("Unable to create a window. Error: " + SDL.SDL_GetError());
            }

            this.originalWidth = width;
            this.originalHeight = height;

            SDL.SDL_ShowWindow(windowPtr);
        }

        void InitSDLVideo()
        {
            if (Application.INITSDL_VIDEO)
                return;

#if DEBUG
            Debug.Info("Trying to Initializing SDL Video...");
#endif

            if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
            {
                Debug.LogError("Unable to initialize SDL Video. Error: " + SDL.SDL_GetError());
                return;
            }

            SDL.SDL_Init(SDL.SDL_INIT_VIDEO);
            Application.INITSDL_VIDEO = true;
        }

        void InitSDLAudio()
        {
            if (Application.INITSDL_AUDIO)
                return;

#if DEBUG
            Debug.Info("Trying to Initializing SDL Audio...");
#endif

            if (SDL.SDL_Init(SDL.SDL_INIT_AUDIO) < 0)
            {
                Debug.LogError("Unable to initialize SDL Audio. Error: " + SDL.SDL_GetError());
                return;
            }

            SDL.SDL_Init(SDL.SDL_INIT_AUDIO);
            Application.INITSDL_AUDIO = true;
        }

        public bool PollEvents(out SDL.SDL_Event e) => SDL.SDL_PollEvent(out e) != 0;

        public void HandlePollEvents(SDL.SDL_Event e)
        {
            switch (e.type)
            {
                case SDL.SDL_EventType.SDL_QUIT:

#if DEBUG
                    Debug.Info("Closing Window Requested");
#endif
                    SDL.SDL_DestroyRenderer(renderPtr);
                    SDL.SDL_DestroyWindow(windowPtr);
                    SDL.SDL_Quit();
                    break;
            }
        }

        /// <summary>
        /// Clear the window Renderer. Call before rendering content.
        /// </summary>
        public void Clear()
        {
            SDL.SDL_RenderClear(RenderPtr);
        }

        public void Display()
        {
            SDL.SDL_RenderPresent(RenderPtr);
        }

        public void SetBackgroundColor(Color newColor) => backgroundColor = newColor;

        public void SetDrawColor(Color color) => SDL.SDL_SetRenderDrawColor(RenderPtr, color.r, color.g, color.b, color.a);
        public void SetDrawColor(byte r, byte g, byte b, byte a) => SDL.SDL_SetRenderDrawColor(RenderPtr, r, g, b, a);

        public void ResetDrawColor() => SDL.SDL_SetRenderDrawColor(RenderPtr, backgroundColor.r, backgroundColor.g, backgroundColor.b, backgroundColor.a);

    }
}
