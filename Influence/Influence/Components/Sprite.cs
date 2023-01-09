using SDL2;

namespace Influence
{
    public class Sprite : Component
    {
        public string directory;
        IntPtr spritePtr;

        public Sprite(string spriteDirectory)
        {
            directory = spriteDirectory;
            spritePtr = SDL.SDL_LoadFile($"Assets/Sprites/{directory}.png", out _);


            if (spritePtr == IntPtr.Zero)
                Debug.LogWarning("The Sprite '" + directory + "' could not be loaded!");
        }

        public override void Render(ApplicationWindow window)
        {
            if (!enabled || spritePtr == IntPtr.Zero)
                return;


            SDL.SDL_RenderCopy(window.RenderPtr, spritePtr, IntPtr.Zero, IntPtr.Zero);
        }
    }
}