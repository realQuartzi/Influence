﻿using System;
using System.Drawing;

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
            new Shape(new Vector2(12, 12), new Vector3(24, 24,0));
            new Shape(new Vector2(12, 12), new Vector3(48, 48, 0), Color.Red);
            new Shape(new Vector2(32, 32), new Vector3(128, 128, 0), Color.Aqua);

            new Sprite("Ensoul", new Vector3(64,64));
            new Sprite("Ensoul", new Vector3(256, 256), new Vector3(5,5,5));
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
