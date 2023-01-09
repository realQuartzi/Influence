
using SDL2;

namespace Influence
{
    public class Shape : Component
    {
        public Vector2 size = new Vector2();
        public Color color = Color.White;

        public Shape(int sizeX, int sizeY)
        {
            size.x = sizeX;
            size.y = sizeY;
        }
        public Shape(Vector2 size)
        {
            this.size = size;
        }
        public Shape(int sizeX, int sizeY, Color color)
        {
            size.x = sizeX;
            size.y = sizeY;

            this.color = color;
        }
        public Shape(Vector2 size, Color color)
        {
            this.size = size;
            this.color = color;
        }

        public override void Render(ApplicationWindow window)
        {
            if (!enabled)
                return;

            SDL.SDL_Rect rect = new SDL.SDL_Rect();

            rect.x = (int)transform.position.x;
            rect.y = (int)transform.position.y;

            rect.w = (int)(size.x * transform.scale.x);
            rect.h = (int)(size.y * transform.scale.y);

            window.SetDrawColor(color);
            SDL.SDL_RenderFillRect(window.RenderPtr, ref rect);
            window.ResetDrawColor();
        }
    }
}