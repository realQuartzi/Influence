using System;

namespace Influence
{
    class DemoGame : Influence
    {
        public DemoGame(): base(512, 512, "Demo Game") { }

        protected override void Initialize()
        {
            Console.WriteLine("[Initialized] Called");
        }

        protected override void Awake()
        {
            Console.WriteLine("[Awake] Called");
        }

        protected override void FixedUpdate()
        {
            Console.WriteLine("[Fixed Update] Fixed Time: " + Time.fixedTime + " | Fixed Delta Time: " + Time.fixedDeltaTime);
        }

        protected override void LateUpdate()
        {

        }

        protected override void Start()
        {
            Console.WriteLine("[Start] Called");
        }

        int frame = 0;
        protected override void Update()
        {
            frame++;
            Console.WriteLine("Frame " + frame);
            Console.WriteLine("[Update] Time: " + Time.time + " | Delta Time: " + Time.deltaTime);
        }
    }
}
