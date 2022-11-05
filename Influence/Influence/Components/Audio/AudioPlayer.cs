using System;
using System.IO;
using System.Media;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Windows.Forms;

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

            int e = SendCommand(string.Format($"open \"{{0}}\" type MPEGVideo alias {{1}}", audioLocation, alias));
            Debug.Log("set Error Code: " + e);
        }

        public void ChangeAudio(string newFileName)
        {
            audioLocation = GetPathToFileInAssembly("Assets\\Audio\\" + newFileName);

            SendCommand(string.Format($"open \"{{0}}\" type WaveAudio alias {{1}}", audioLocation, alias));
        }

        public void SetVolume(float volume)
        {
            if (volume > 1)
                volume = 1;
            else if (volume < 0)
                volume = 0;

            int vol = (int)Math.Max(Math.Min(volume * 1000f, 1000f), 0f);

            SendCommand(string.Format("setaudio {0} volume to {1}", this.alias, vol));
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

        public static void SetVolume(string alias, float volume)
        {
            Debug.Log("volume: " + volume);

            volume *= 1000f;

            int vol = (int)(volume < 0 ? 0 : (volume > 1000 ? 1000 : volume));

            Debug.Log("vol: " + vol);

            StringBuilder buffer = new StringBuilder();

            int e = mciSendString(string.Format("setaudio {0} volume to {1}", alias, vol), buffer, 0, IntPtr.Zero);
            Debug.Log("Error Code: " + e);
        }

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

        int SendCommand(string cmd) => mciSendString(cmd, null, 0, IntPtr.Zero);

        [DllImport("winmm.dll")]
        static extern int mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hWndCallback);

        [DllImport("winmm.dll")]
        static extern long mciGetErrorString(long fdwError, StringBuilder errorText, int cchErrorText);

    }
}
