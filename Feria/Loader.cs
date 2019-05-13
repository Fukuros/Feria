using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Feria
{
    public class Loader
    {
        private static GameObject Load;
        private const uint StdOutputHandle = 0xFFFFFFF5;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nStdHandle, IntPtr handle);

        [DllImport("kernel32")]
        private static extern bool AllocConsole(int pid);

        [DllImport("msvcrt.dll")]
        public static extern int system(string cmd);
        public static void Init()
        {

            AllocConsole(-1);
            var stdout = Console.OpenStandardOutput();
            var sw = new StreamWriter(stdout, Encoding.Default);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.SetError(sw);



            Load = new GameObject();
            Load.AddComponent<Hax>();
            Load.AddComponent<GuiMenu>();
            Load.AddComponent<Aimbot>();
            Load.AddComponent<ESP>();
          Load.AddComponent<NoReload>();
        //  Load.AddComponent<Drop>();
            Load.AddComponent<WeaponAuguments>();


            Object.DontDestroyOnLoad(Load);
        }
    }
}