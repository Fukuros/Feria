using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace Feria
{
    class GetObjects : MonoBehaviour
    {
        public GameLoot[] gLoot;
        public Camera gCamera; // Used for grabbing pos of camera object
        public GameScript gScript;
        public GamePlayerController gController;
        public GamePlayerNetworked[] gPlayer; //Used for grabbing pos of player
        private string myPlayerName;

        public void Start()
        {

           // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchLoot", 1.0f, 1.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchScript", 1.0f, 15.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
        
          
            InvokeRepeating("GetPlayerName", 1.0f, 30.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.

        }


        public void GetPlayerName()
        {
            myPlayerName = SteamFriends.GetPersonaName();
            Console.WriteLine("Found Name");
        }
      

        public void FetchLoot()
        {
         
            Console.WriteLine("Loot Object Collection Started"); // write Status of object collection
               gLoot = FindObjectsOfType<GameLoot>(); // Load GameLoot Class/Object into Memory
               Console.WriteLine("Loot Object Collection Finished");// write Status of object collection
        }

        public void FetchScript()
        {
            Console.WriteLine("Script Object Collection Started"); // write Status of object collection
            gScript = FindObjectOfType<GameScript>(); // Load GameScript Class/Object into Memory
            Console.WriteLine("Script Object Collection Finished");// write Status of object collection
        }

        public void FetchController()
        {
            Console.WriteLine("Controller Object Collection Started"); // write Status of object collection
            gController = FindObjectOfType<GamePlayerController>();// Load GamePlayerController Class/Object into Memory
            Console.WriteLine("Controller Object Collection Finished");// write Status of object collection
        }

       
    }
}
