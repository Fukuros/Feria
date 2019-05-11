using System;
using System.Linq;
using MultiplayerBasicExample;
using Steamworks;
using UnityEngine;

namespace Feria
{
    internal class ESP : MonoBehaviour
    {
        private Camera gCamera;

        private GamePlayerNetworked[] gPlayer;
        private string myPlayer;
        private GameScript gScript;

        public void Start()
        {
            myPlayer = SteamFriends.GetPersonaName();
            Console.WriteLine("ESP Module Loaded");
          //  InvokeRepeating("FetchPlayer", 1.0f, 15.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchCamera", 1.0f, 1.0f);
            InvokeRepeating("FetchScript", 1.0f, 5.0f);
            InvokeRepeating("CompareObjectsLive", 1.0f, 5.0f);
        }

        public void Update()
        {
         
        }

        
        public void OnGUI()
        {
            Esper();
        }

        public void FetchPlayer()
        {
          
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
         
        }

        public void CompareObjectsLive()
        {
            if (gPlayer == null)
            {

                FetchPlayer(); // INITIAL OBJECT DOES NOT EXIST SO CREATE IT 


            }

            if (gScript == null && gPlayer != null && gPlayer.Length == 64)
            {
                Console.WriteLine("shit is hella null gscript  " + gPlayer.Length);
                Array.Clear(gPlayer, 0, 63); // CLEAR INDEX BECAUSE OUTSIDE OF GAME
                FetchPlayer();
            }
            else
            {
                Console.WriteLine(gScript.playersAliveCount);
            }

            if (gPlayer.Length < gScript.playersAliveCount)
            {
                Array.Clear(gPlayer, 0, gPlayer.Length);
                Console.WriteLine("Player length is not correct forcing fetch player method " + "Length " + gPlayer.Length + "Players Alive" + gScript.playersAliveCount);
                FetchPlayer();
            }
        }
        public void FetchScript()
        {
            gScript = FindObjectOfType<GameScript>(); // Load GameScript Class/Object into Memory
        }

        public void FetchCamera()
        {
      
            gCamera = FindObjectOfType<Camera>(); // Load Camera Class/Object into Memory
           
        }

        private void Esper()
        {
            //   Console.WriteLine("started func ESPER");
            if (GuiMenu.EntityESP)
                //     Console.WriteLine("detected enabled esper");
                foreach (var p in gPlayer)
                {
                    // Console.WriteLine("looping through players");
                    var mousePosition = Input.mousePosition;
                    var position3 = p.transform.position;
                    var target =
                        gCamera.transform.position +
                        gCamera.transform.forward; //Calculate a point facing straight away from us
                    var w2s = gCamera.WorldToScreenPoint(target); //Translate position to screen
                    var v = Camera.main.WorldToScreenPoint(position3);
                    var num1 = Vector2.Distance(w2s, v);


                    position3.y += 6.5f;

                    var vector2 = Camera.main.WorldToScreenPoint(position3);
                    vector2.y = Screen.height - vector2.y - 50f;
                    vector2.x -= 15f;

                    var vector3 = GUI.skin.label.CalcSize(new GUIContent(
                        p.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + p.playerHP));


                    var flag7 = vector2.x > Screen.width - vector3.x;
                    if (flag7) vector2.x = Screen.width - vector3.x;

                    var flag8 = vector2.y > Screen.height - vector3.y;
                    if (flag8) vector2.y = Screen.height - vector3.y;

                    var flag9 = vector2.x < 0f;
                    if (flag9) vector2.x = 0f;

                    var flag10 = vector2.y < 0f;
                    if (flag10) vector2.y = 0f;

                    if (p.playerHP != 0 && p.playerName != myPlayer && num1 < 2100)
                    {
                        GUI.Label(new Rect(vector2, new Vector2(vector3.x, vector3.y)),
                            p.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + p.playerHP);
                        var backgroundColor = GUI.backgroundColor;
                        GUI.backgroundColor = Color.red;
                        GUI.backgroundColor = backgroundColor;
                    }
                }
        }
    }
}