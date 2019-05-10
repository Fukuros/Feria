using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using CodeStage.AntiCheat.Detectors;
using UnityEngine;

namespace Feria
{
    public class Hax : MonoBehaviour
    {
        private const uint StdOutputHandle = 0xFFFFFFF5;

        public  Dictionary<string, Hack> hacks = new Dictionary<string, Hack>();
        // initialize hack objects
        public Hack noreload;
        private GuiMenu guimenu;
        public Hack esper;

        public Hax()
        {
            InjectionDetector.Dispose();
            ObscuredCheatingDetector.Dispose();
            SpeedHackDetector.Dispose();
            TimeCheatingDetector.Dispose();
            WallHackDetector.Dispose();

            AllocConsole(-1);
            var stdout = Console.OpenStandardOutput();
            var sw = new StreamWriter(stdout, Encoding.Default);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.SetError(sw);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(uint nStdHandle);

        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(uint nStdHandle, IntPtr handle);

        [DllImport("kernel32")]
        private static extern bool AllocConsole(int pid);

        [DllImport("msvcrt.dll")]
        public static extern int system(string cmd);

        public void Update()
        {
            Camera.main.orthographicSize = GuiMenu.EntityDist;
            foreach (var v in hacks)
            {
                Hack h = v.Value;
                h.Update();
                Console.WriteLine(v.Key);
                Console.WriteLine(v.Value);
            }
          
        }

        public void OnGUI()
        {
            foreach (var v in hacks)
            {
                Hack h = v.Value;
                h.OnGUI();
                Console.WriteLine(v.Key);
                Console.WriteLine(v.Value);
            }

        }


        public void Start()
        {
           esper = new ESP(this);
           noreload = new NoReload(this);
           guimenu = new GuiMenu(this);

            hacks.Add(noreload.named, noreload);
            hacks.Add(esper.named, esper);
            hacks.Add(guimenu.named, guimenu);
            foreach (var v in hacks)
            {
                Hack h = v.Value;

                h.Start();
                Console.WriteLine(v.Key);
                Console.WriteLine(v.Value);
            }

        }
    }
}