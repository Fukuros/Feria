using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Feria
{
    internal class NoReload : Hack
    {
        private GamePlayerController gController;

        override public void Start()
        {
            Console.WriteLine("No Reload Module Loaded");
            b.InvokeRepeating("FetchController", 1.0f,
                15.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
        }

        public NoReload(Hax b) : base("No Reload", b)
        {

        }

        override public void OnGUI()
        {

        }

       public void FetchController()
        {
            gController =
                MonoBehaviour.FindObjectOfType<GamePlayerController>(); // Load GamePlayerController Class/Object into Memory
        }

        override public void Update()
        {
            //Console.WriteLine("called update no reload");
            if (enabled) gController.reloadFinishTime = 0;
        }
    }
}