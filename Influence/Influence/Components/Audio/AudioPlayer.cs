using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Influence.Audio
{
    public class AudioPlayer
    {
        string alias;
        public string AudioName => alias;

        string audioLocation;
        public string AudioLocation => audioLocation;

        bool loop;
        public bool isLooping => loop;
        public bool SetLoop(bool loop) => this.loop = loop;

        public AudioPlayer(string fileName, string audioAlias)
        {
            alias = audioAlias;
            audioLocation = GetPathToFileInAssembly("Assets\\Audio\\" + fileName);

            mciSendString(string.Format($"open \"{{0}}\" type WaveAudio alias {{1}}", audioLocation, alias), null, 0, IntPtr.Zero);
        }

        static string GetPathToFileInAssembly(string relativePath)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);
        }


        public static void Play(string alias)
        {
            string cmd = "seek {0} to start";
            cmd = string.Format(cmd, alias);

            mciSendString(cmd, null, 0, IntPtr.Zero);

            cmd = "play {0}";
            cmd = string.Format(cmd, alias);

            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        public static void PlayLooped(string alias)
        {
            string cmd = "seek {0} to start";
            cmd = string.Format(cmd, alias);

            mciSendString(cmd, null, 0, IntPtr.Zero);

            cmd = "play {0} repeat";
            cmd = string.Format(cmd, alias);

            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        public static void Stop(string alias) => mciSendString("stop " + alias, null, 0, IntPtr.Zero);

        public void Play()
        {
            string cmd = "play " + alias;

            if (loop)
            {
                cmd += " REPEAT";
            }

            SendCommand(cmd);
        }

        public void Stop() => SendCommand("stop " + alias);

        public void Dispose() => SendCommand("close " + alias);

        public void Restart() =>  SendCommand("seek " + alias + " to start");

        void SendCommand(string cmd) => mciSendString(cmd, null, 0, IntPtr.Zero);

        [DllImport("winmm.dll")]
        static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hWndCallback);
    }
}
