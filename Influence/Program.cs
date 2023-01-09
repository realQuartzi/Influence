
namespace Influence
{
    class Program
    {
        static void Main(string[] args)
        {
            new Game(400, 400, "Julie my Love <3");
        }
    }

    public class Game : Application
    {
        public Game(int width, int height, string title = "") : base(width, height, title)
        {
        }

        protected override void Awake()
        {
            window?.SetBackgroundColor(Color.Julie);
        }

        protected override void FixedUpdate()
        {
            Random random = new Random();
            byte r = (byte)random.Next(0, 255);
            byte g = (byte)random.Next(0, 255);
            byte b = (byte)random.Next(0, 255);

            //window?.SetBackgroundColor(new Color(r, g, b));
        }

        protected override void Initialize()
        {

        }

        protected override void LateUpdate()
        {

        }

        protected override void RenderUpdate()
        {

        }

        protected override void Start()
        {

        }

        protected override void Update()
        {

        }
    }
}