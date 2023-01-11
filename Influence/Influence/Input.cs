using SDL2;

namespace Influence
{
    static class Input
    {
        public static KeyCode EventToKeyCode(SDL.SDL_Event e)
        {
            if(e.type != SDL.SDL_EventType.SDL_KEYDOWN && e.type != SDL.SDL_EventType.SDL_KEYUP)
                return KeyCode.None;

            switch (e.key.keysym.scancode)
            {
                case SDL.SDL_Scancode.SDL_SCANCODE_UNKNOWN:
                    return KeyCode.None;
                case SDL.SDL_Scancode.SDL_SCANCODE_A:
                    return KeyCode.A;
                case SDL.SDL_Scancode.SDL_SCANCODE_B:
                    return KeyCode.B;
                case SDL.SDL_Scancode.SDL_SCANCODE_C:
                    return KeyCode.C;
                case SDL.SDL_Scancode.SDL_SCANCODE_D:
                    return KeyCode.D;
                case SDL.SDL_Scancode.SDL_SCANCODE_E:
                   return KeyCode.E;
                case SDL.SDL_Scancode.SDL_SCANCODE_F:
                    return KeyCode.F;
                case SDL.SDL_Scancode.SDL_SCANCODE_G:
                    return KeyCode.G;
                case SDL.SDL_Scancode.SDL_SCANCODE_H:
                    return KeyCode.H;
                case SDL.SDL_Scancode.SDL_SCANCODE_I:
                    return KeyCode.I;
                case SDL.SDL_Scancode.SDL_SCANCODE_J:
                    return KeyCode.J;
                case SDL.SDL_Scancode.SDL_SCANCODE_K:
                    return KeyCode.K;
                case SDL.SDL_Scancode.SDL_SCANCODE_L:
                    return KeyCode.L;
                case SDL.SDL_Scancode.SDL_SCANCODE_M:
                    return KeyCode.M;
                case SDL.SDL_Scancode.SDL_SCANCODE_N:
                    return KeyCode.N;
                case SDL.SDL_Scancode.SDL_SCANCODE_O:
                    return KeyCode.O;
                case SDL.SDL_Scancode.SDL_SCANCODE_P:
                    return KeyCode.P;
                case SDL.SDL_Scancode.SDL_SCANCODE_Q:
                    return KeyCode.Q;
                case SDL.SDL_Scancode.SDL_SCANCODE_R:
                    return KeyCode.R;
                case SDL.SDL_Scancode.SDL_SCANCODE_S:
                    return KeyCode.S;
                case SDL.SDL_Scancode.SDL_SCANCODE_T:
                    return KeyCode.T;
                case SDL.SDL_Scancode.SDL_SCANCODE_U:
                    return KeyCode.U;
                case SDL.SDL_Scancode.SDL_SCANCODE_V:
                    return KeyCode.V;
                case SDL.SDL_Scancode.SDL_SCANCODE_W:
                    return KeyCode.W;
                case SDL.SDL_Scancode.SDL_SCANCODE_X:
                    return KeyCode.X;
                case SDL.SDL_Scancode.SDL_SCANCODE_Y:
                    return KeyCode.Y;
                case SDL.SDL_Scancode.SDL_SCANCODE_Z:
                    return KeyCode.Z;
                case SDL.SDL_Scancode.SDL_SCANCODE_1:
                    return KeyCode.One;
                case SDL.SDL_Scancode.SDL_SCANCODE_2:
                    return KeyCode.Two;
                case SDL.SDL_Scancode.SDL_SCANCODE_3:
                    return KeyCode.Three;
                case SDL.SDL_Scancode.SDL_SCANCODE_4:
                    return KeyCode.Four;
                case SDL.SDL_Scancode.SDL_SCANCODE_5:
                    return KeyCode.Five;
                case SDL.SDL_Scancode.SDL_SCANCODE_6:
                    return KeyCode.Six;
                case SDL.SDL_Scancode.SDL_SCANCODE_7:
                    return KeyCode.Seven;
                case SDL.SDL_Scancode.SDL_SCANCODE_8:
                    return KeyCode.Eight;
                case SDL.SDL_Scancode.SDL_SCANCODE_9:
                    return KeyCode.Nine;
                case SDL.SDL_Scancode.SDL_SCANCODE_0:
                    return KeyCode.Zero;
                case SDL.SDL_Scancode.SDL_SCANCODE_RETURN:
                    return KeyCode.Return;
                case SDL.SDL_Scancode.SDL_SCANCODE_ESCAPE:
                    return KeyCode.Escape;
                case SDL.SDL_Scancode.SDL_SCANCODE_BACKSPACE:
                    return KeyCode.Backspace;
                case SDL.SDL_Scancode.SDL_SCANCODE_TAB:
                    return KeyCode.Tab;
                case SDL.SDL_Scancode.SDL_SCANCODE_SPACE:
                    return KeyCode.Space;
                case SDL.SDL_Scancode.SDL_SCANCODE_DELETE:
                    return KeyCode.Delete;
                case SDL.SDL_Scancode.SDL_SCANCODE_RIGHT:
                    return KeyCode.RightArrow;
                case SDL.SDL_Scancode.SDL_SCANCODE_LEFT:
                    return KeyCode.LeftArrow;
                case SDL.SDL_Scancode.SDL_SCANCODE_DOWN:
                    return KeyCode.DownArrow;
                case SDL.SDL_Scancode.SDL_SCANCODE_UP:
                    return KeyCode.UpArrow;
                case SDL.SDL_Scancode.SDL_SCANCODE_LCTRL:
                    return KeyCode.LeftControl;
                case SDL.SDL_Scancode.SDL_SCANCODE_LSHIFT:
                    return KeyCode.LeftShift;
                case SDL.SDL_Scancode.SDL_SCANCODE_LALT:
                    return KeyCode.LeftAlt;
                case SDL.SDL_Scancode.SDL_SCANCODE_RCTRL:
                    return KeyCode.RightControl;
                case SDL.SDL_Scancode.SDL_SCANCODE_RSHIFT:
                    return KeyCode.RightShift;
                case SDL.SDL_Scancode.SDL_SCANCODE_RALT:
                    return KeyCode.RightAlt;
                default:
                    return KeyCode.None;
            }
        }

        public static List<KeyCode> keyDownInputs = new List<KeyCode>();
        public static List<KeyCode> keyUpInputs = new List<KeyCode>();

        public static bool GetKeyDown(KeyCode key) => keyDownInputs.Contains(key);
        public static bool GetKeyUp(KeyCode key) => keyUpInputs.Contains(key);

        public static void ClearAll()
        {
            keyUpInputs.Clear();
        }

        public enum KeyCode
        {
            None, // None
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z, // Alpha
            One,Two, Three, Four, Five, Six, Seven, Eight, Nine, Zero, // Nulbers
            LeftClick, RightClick, MiddleClick, // Mouse
            UpArrow, DownArrow, LeftArrow, RightArrow, // Arrow Keys
            Backspace,
            Delete,
            Tab,
            Return,
            Escape,
            Space,

            RightShift, LeftShift,
            RightAlt, LeftAlt,
            RightControl, LeftControl
        }
    }
}
