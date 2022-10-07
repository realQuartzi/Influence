using System;

namespace Influence
{
    class DemoGame : Influence
    {
        public DemoGame(): base(512, 512, "Demo Game") { }

        protected override void Initialize()
        {
        }

        protected override void Awake()
        {
            Sprite sprite = new Sprite(new Vector2(24, 24), new Vector2(12, 12));
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
        }
    }
}
