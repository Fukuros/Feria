using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace Feria
{
    class WeaponAuguments : MonoBehaviour
    {
        private GamePlayerNetworked[] gPlayer;
        private WeaponType gearload;
  //      private Aimbot welz;

        public void Start()
        {

      
            Console.WriteLine("Weapon AUG Module Loaded");
            InvokeRepeating("FetchPlayer", 1.0f, 1.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
        }

        public void FetchPlayer()
        {
         
            gPlayer = FindObjectsOfType<GamePlayerNetworked>();// Load GamePlayerNetworked Class/Object into 
        
        }

        public void Update()
        {
            
            foreach (var p in gPlayer)
            {
                if (p.playerName == SteamFriends.GetPersonaName()) // fetches my name 
                {

                    short mycurrentweapon = p.equipmentIDs[p.currentEquipmentIndex];
                    gearload = WeaponType.GetAllWeaponTypes()[mycurrentweapon];

                    if (GuiMenu.NoSlow)
                    {
                        gearload.gunMoveSpeedMult = 1.2f; // Server checks are strong.. but it does work.. to an extent

                    }

                    if (GuiMenu.Auto)
                    {
                        gearload.canHoldFire = true; // Full pew pew on pistols
                    }



                }
            }

        }

        public void OnGui()
        {

        }
    }
}
