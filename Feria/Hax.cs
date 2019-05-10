using Harmony;
using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Lidgren.Network;
using PlayFab.PlayStreamModels;
using UnityEngine;

namespace Feria
{
    public class Hax : MonoBehaviour
    {
        
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);

        [DllImport("kernel32")]
        static extern bool AllocConsole(int pid);

        [DllImport("msvcrt.dll")]
        public static extern int system(string cmd);



        public Hax()
        {

            CodeStage.AntiCheat.Detectors.InjectionDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();

            AllocConsole(-1);
            var stdout = Console.OpenStandardOutput();
            var sw = new System.IO.StreamWriter(stdout, Encoding.Default);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.SetError(sw);


        }

        public void Update()
        {
            Camera.main.orthographicSize = GuiMenu.EntityDist;
        }



    }
}