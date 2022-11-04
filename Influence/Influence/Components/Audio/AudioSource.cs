﻿using System.Drawing;

namespace Influence.Audio
{
    class AudioSource : Component
    {
        AudioPlayer audioPlayer;

        public AudioSource(string fileName, string alias)
        {
            audioPlayer = new AudioPlayer(fileName, alias);
        }

        public void Play() => audioPlayer.Play();
        public void Stop() => audioPlayer.Stop();
        public void Restart() => audioPlayer.Restart();

        public override void Render(Graphics graphics)
        {
            // None
        }
    }
}
