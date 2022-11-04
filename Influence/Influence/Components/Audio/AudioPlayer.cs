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
            var di = new DirectoryInfo(GetPathToFileInAssembly("Assets/Audio/" + fileName + ".wav"));
            Debug.Log("Audio Location: " + GetPathToFileInAssembly("Assets/Audio/" + fileName + ".wav"));
            audioLocation = GetPathToFileInAssembly("Assets /Audio/" + fileName + ".wav");

            mciSendString(string.Format("open \"{0}.wav\" type MPEGVideo alias {1}", audioLocation, alias), null, 0, IntPtr.Zero);
        }

        static string GetPathToFileInAssembly(string relativePath)
        {
            return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);
        }

        public void Play()
        {
            //SoundPlayer player = new SoundPlayer(audioLocation);
            //player.Play();

            Debug.Log("Trying to play: " + alias);

            string cmd = "play {0}";
            cmd = string.Format(cmd, audioLocation);

            if(loop)
            {
                cmd += " REPEAT";
            }

            SendCommand(cmd);
        }

        public void Stop()
        {
            string cmd = "stop {0}";
            cmd = string.Format(cmd, alias);

            SendCommand(cmd);
        }

        public void Dispose()
        {
            string cmd = "close {0}";
            cmd = string.Format(cmd, alias);

            SendCommand(cmd);
        }

        public void Restart()
        {
            string cmd = "seek {0} to start";
            cmd = string.Format(cmd, alias);

            SendCommand(cmd);
        }

        void SendCommand(string cmd)
        {
            Debug.Log("Sending Audio Command: " + cmd);
            Debug.Log("File Location: " + AudioLocation);
            mciSendString(cmd, null, 0, IntPtr.Zero);
        }

        [DllImport("winmm.dll")]
        static extern long mciSendString(string strCommand, StringBuilder strReturn, int iReturnLength, IntPtr hWndCallback);

        public static string ToShortPathName(string longName)
        {
            uint bufferSize = 256;

            // don´t allocate stringbuilder here but outside of the function for fast access
            StringBuilder shortNameBuffer = new StringBuilder((int)bufferSize);

            GetShortPathName(string.Format("\"{0}\"", longName), shortNameBuffer, bufferSize);

            return shortNameBuffer.ToString();
        }

        public string ShortPath(string longpath)
        {
            char[] buffer = new char[256];

            GetShortPathName(longpath, buffer, buffer.Length);

            return new string(buffer);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName([MarshalAs(UnmanagedType.LPTStr)] string lpszLongPath, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszShortPath, uint cchBuffer);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern uint GetShortPathName(string lpszLongPath, char[] lpszShortPath, int cchBuffer);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetShortPathNameW", SetLastError = true)]
        static extern int GetShortPathName(string pathName, StringBuilder shortName, int cbShortName);
    }
}
