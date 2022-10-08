using System.Drawing;
using System.Windows.Forms;

namespace Influence
{
    class DemoGame : Influence
    {
        public DemoGame(): base(512, 512, "Demo Game") { }

        GameObject player;

        protected override void Initialize()
        {
        }

        protected override void Awake()
        {
            player = new GameObject("Player").AddComponent(new Shape(16, 16)).gameObject;
            player.AddComponent(new Sprite("Ensoul"));
            player.transform.position = new Vector3(32, 32);
            player.transform.scale = new Vector3(2, 2);

        }

        protected override void FixedUpdate()
        {

        }

        protected override void LateUpdate()
        {

        }

        protected override void Start()
        {
            
        }

        protected override void Update()
        {
            if (Input.GetKeyDown(Keys.W))
            {
                player.transform.Translate(Vector3.up * 100 * -Time.deltaTime);
            }

            if (Input.GetKeyDown(Keys.S))
            {
                player.transform.Translate(Vector3.down * 100 * -Time.deltaTime);
            }

            if (Input.GetKeyDown(Keys.A))
            {
                player.transform.Translate(Vector3.left * 100 * Time.deltaTime);
            }

            if (Input.GetKeyDown(Keys.D))
            {
                player.transform.Translate(Vector3.right * 100 * Time.deltaTime);
            }


        }
    }
}
