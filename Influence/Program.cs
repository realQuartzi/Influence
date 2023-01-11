
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
        Sprite sprite;
        Sprite spriteClone;
        float time;
        string[] medals = new string[] { "Easy_Medal", "Medium_Medal", "Hard_Medal" };

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
            sprite = new GameObject("Hard_Medal").AddComponent(new Sprite("Hard_Medal")) as Sprite;
            sprite.transform.position = new Vector3(32, 32);
            sprite.transform.scale = new Vector3(0.5f, 0.5f);

            spriteClone = new GameObject("Easy_Medal").AddComponent(new Sprite("Easy_Medal")) as Sprite;
            spriteClone.transform.position = new Vector3(128, 128);
        }

        protected override void Update()
        {
            if(time <= 0)
            {
                Random rnd = new Random();

                string medal = medals[rnd.Next(0, 3)];
                string medal2 = medals[rnd.Next(0, 3)];

                sprite.ChangeSprite(medal);
                spriteClone.ChangeSprite(medal2);

                time = 1f;
            }

            time -= (float)Time.deltaTime;
        }
    }
}