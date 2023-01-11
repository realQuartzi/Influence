using SDL2;

namespace Influence
{
    public class Sprite : Component
    {
        public string directory;

        Vector2Int dimensions = new Vector2Int();
        public Vector2Int Dimensions => dimensions;

        IntPtr texturePtr;
        Rect srcRect;
        public Rect SourceRect => new Rect(srcRect.x, srcRect.y, srcRect.w, srcRect.h);

        Rect dstRect;
        public Rect DestinationRect => new Rect(dstRect.x, dstRect.y, dstRect.w, dstRect.h);

        public Sprite(string spriteDirectory)
        {
            directory = spriteDirectory;

            texturePtr = SDL_image.IMG_LoadTexture(Application.window.RenderPtr, $"Assets/Sprites/{directory}.png");
            if (texturePtr == IntPtr.Zero)
            {
                Debug.LogWarning("The Sprite '" + directory + "' could not be loaded!");
                return;
            }

            GetSize(texturePtr);

            srcRect = new Rect(0,0, dimensions.x, dimensions.y);
            dstRect = new Rect();
        }

        public override void Render(ApplicationWindow window)
        {
            if (!enabled || texturePtr == IntPtr.Zero)
                return;

            UpdateSource();
            UpdateDestination();

            SDL.SDL_Rect src = srcRect.GetSDLRect();
            SDL.SDL_Rect dst = dstRect.GetSDLRect();

            SDL.SDL_RenderCopy(window.RenderPtr, texturePtr, ref src, ref dst);
        }

        void GetSize(IntPtr texture) => SDL.SDL_QueryTexture(texture, out _, out _, out dimensions.x, out dimensions.y);

        void UpdateSource()
        {
            if (gameObject == null)
                return;

            srcRect.x = 0;
            srcRect.y = 0;
            srcRect.w = dimensions.x;
            srcRect.h = dimensions.y;
        }

        void UpdateDestination()
        {
            if (gameObject == null)
                return;

            dstRect.x = (int)transform.position.x;
            dstRect.y = (int)transform.position.y;

            dstRect.h = (int)(dimensions.x * transform.scale.x);
            dstRect.w = (int)(dimensions.y * transform.scale.y);
        }

        public void ChangeSprite(string spriteDirectory)
        {
            directory = spriteDirectory;

            IntPtr oldPtr = texturePtr;

            texturePtr = SDL_image.IMG_LoadTexture(Application.window.RenderPtr, $"Assets/Sprites/{directory}.png");
            if (texturePtr == IntPtr.Zero)
            {
                Debug.LogWarning("The Sprite '" + directory + "' could not be loaded!");
                return;
            }

            SDL.SDL_DestroyTexture(oldPtr);

            GetSize(texturePtr);
            UpdateSource();
            UpdateDestination();
        }

        ~Sprite()
        {
            SDL.SDL_DestroyTexture(texturePtr);
        }
    }
}