using System.Windows.Forms;

namespace Influence
{
    class DemoHUD : InfluenceHUD
    {
        public DemoHUD(): base() { }

        GameObject player;
        Collider playerCol;

        GameObject collisionTest;
        Collider testCol;

        protected override void Initialize()
        {
        }

        protected override void Awake()
        {
            player = new GameObject("Player").AddComponent(new Sprite("Ensoul")).gameObject;
            playerCol = player.AddComponent(new Collider(new Vector2(16,16))) as Collider;
            player.transform.position = new Vector3(32, 32);
            player.transform.scale = new Vector3(2, 2);

            collisionTest = new GameObject("Collider");
            testCol = collisionTest.AddComponent(new Collider(new Vector2(12, 12))) as Collider;
            collisionTest.transform.position = new Vector3(64, 64);
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
            if (Input.GetKeyUp(Keys.Space))
            {
                Sprite s = player.GetComponent<Sprite>();
                s.enabled = !s.enabled;
            }

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
