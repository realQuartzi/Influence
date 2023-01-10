using SDL2;

namespace Influence
{
    public class Sprite : Component
    {
        public string directory;
        IntPtr texturePtr;
        IntPtr srcRect;


        public Sprite(string spriteDirectory)
        {
            directory = spriteDirectory;

            texturePtr = SDL_image.IMG_LoadTexture(Application.window.RenderPtr, $"Assets/Sprites/{directory}.png");

            if (texturePtr == IntPtr.Zero)
                Debug.LogWarning("The Sprite '" + directory + "' could not be loaded!");
        }

        public override void Render(ApplicationWindow window)
        {
            if (!enabled || texturePtr == IntPtr.Zero)
                return;



            SDL.SDL_RenderCopy(window.RenderPtr, texturePtr, IntPtr.Zero, IntPtr.Zero);
        }
    }
}