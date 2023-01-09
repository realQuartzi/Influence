
using SDL2;

namespace Influence.Primitive
{
    public static class Draw
    {
        public static void DrawLine(ApplicationWindow window, Vector2 start, Vector2 end)
        {
            window.SetDrawColor(Color.Red);
            SDL.SDL_RenderDrawLine(window.RenderPtr, (int)start.x, (int)start.y, (int)end.x, (int)end.y);
            window.ResetDrawColor();
        }

        public static void DrawLine(ApplicationWindow window, Vector2 start, Vector2 end, Color color)
        {
            window.SetDrawColor(color);
            SDL.SDL_RenderDrawLine(window.RenderPtr, (int)start.x, (int)start.y, (int)end.x, (int)end.y);
            window.ResetDrawColor();
        }

        public static void DrawLine(ApplicationWindow window, Vector2Int start, Vector2Int end)
        {
            window.SetDrawColor(Color.Red);
            SDL.SDL_RenderDrawLine(window.RenderPtr, start.x, start.y, end.x, end.y);
            window.ResetDrawColor();
        }

        public static void DrawLine(ApplicationWindow window, Vector2Int start, Vector2Int end, Color color)
        {
            window.SetDrawColor(color);
            SDL.SDL_RenderDrawLine(window.RenderPtr, start.x, start.y, end.x, end.y);
            window.ResetDrawColor();
        }
    }
}
