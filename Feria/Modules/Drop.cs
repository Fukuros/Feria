using System;
using MultiplayerWithBindingsExample;
using Steamworks;
using UnityEngine;

namespace Feria
{
    public class Drop : MonoBehaviour
    {
        private Aimbot myaim;
        private GamePlayerNetworked[] gPlayer;

        private string myPlayer;

        public void Start()
        {

            myPlayer = SteamFriends.GetPersonaName();
            Console.WriteLine("Auto Drop Module");

         myaim =new Aimbot();
         FetchPlayer();
         InvokeRepeating("eatcoco", 1.0f, 155.0f);
        }

        public void FetchPlayer()
        {
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
           
        }

        public void eatcoco()
        {
            for (ushort i = 0; i < 1000; i++)
            {
              //GameServerManager.ClientSendPerformAttackToServer(14,1,55,90);
                Console.WriteLine("eating mad cocos bro bro " + i);

                if (i == 10000)
                {
                    i = 0;
                }

            }
        }


        public void Update()
        {

            foreach (var p in gPlayer)
            {
                if (p.playerName == myPlayer) // fetches my name 
            {

                    p.healingDrinkStartTime = +100f;

            }

            }
        }
    }
}