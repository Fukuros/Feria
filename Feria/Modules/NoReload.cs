using System;
using UnityEngine;

namespace Feria
{
    internal class NoReload : MonoBehaviour
    {
        private GamePlayerController gController;

        public void Start()
        {
            Console.WriteLine("No Reload Module Loaded");
            InvokeRepeating("FetchController", 1.0f,
                15.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
        }

        public void FetchController()
        {
            gController =
                FindObjectOfType<GamePlayerController>(); // Load GamePlayerController Class/Object into Memory
        }

        public void Update()
        {
            if (GuiMenu.NoReload) gController.reloadFinishTime = 0;

        }
    }
}