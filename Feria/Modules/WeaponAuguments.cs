using System;
using Steamworks;
using UnityEngine;

namespace Feria
{
    internal class WeaponAuguments : MonoBehaviour
    {
        private WeaponType gearload;

        private GamePlayerNetworked[] gPlayer;
        public string myPlayer;

        public void Start()
        {

            myPlayer = SteamFriends.GetPersonaName();
            Console.WriteLine("Weapon AUG Module Loaded");
            InvokeRepeating("FetchPlayer", 1.0f,
                1.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.

        }

        public void FetchPlayer()
        {
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
        }

        public void Update()
        {
            foreach (var p in gPlayer)
                if (p.playerName == myPlayer) // fetches my name 
                {
                    var x = new WeaponType();
                    var mycurrentweapon = p.equipmentIDs[p.currentEquipmentIndex];
                    gearload = WeaponType.GetAllWeaponTypes()[mycurrentweapon];
                    gearload.bulletSpreadDegreesMax = 0;
                   // gearload.bulletMoveSpeed = 220;
                  //  gearload.clipSize = 9999;
             //       Console.WriteLine(  "Move Speed added per rarity " +x.bulletMoveSpeedAddedPerRarity);
                //    Console.WriteLine("spread " + x.bulletSpreadDegreesMax);
                    
                    if (GuiMenu.NoSlow)
                        gearload.gunMoveSpeedMult = 1.2f; // Server checks are strong.. but it does work.. to an extent
                 
                    if (GuiMenu.Auto) gearload.canHoldFire = true; // Full pew pew on pistols
                }
        }

        public void OnGui()
        {
        }
    }
}