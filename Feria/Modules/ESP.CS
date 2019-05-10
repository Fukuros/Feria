using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Steamworks;
using UnityEngine;

namespace Feria
{
    class ESP : MonoBehaviour
    {

        private GamePlayerNetworked[] gPlayer;
        private Camera gCamera;
        private string myPlayer;

        public void Start()
        {
            myPlayer = SteamFriends.GetPersonaName();
          Console.WriteLine("ESP Module Loaded");
            InvokeRepeating("FetchPlayer", 1.0f,
                1.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchCamera", 1.0f, 1.0f);
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
            //  Console.WriteLine("Player Object Collection Started"); // write Status of object collection
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
            // Console.WriteLine("Player Object Collection Started"); // write Status of object collection
        }

        public void FetchCamera()
        {

         //   Console.WriteLine("Camera Object Collection Started"); // write Status of object collection
            gCamera = FindObjectOfType<Camera>(); // Load Camera Class/Object into Memory
           // Console.WriteLine("Camera Object Collection Finished"); // write Status of object collection
        }

        private void Esper()
        {
         //   Console.WriteLine("started func ESPER");
            if (GuiMenu.EntityESP)
            {
           //     Console.WriteLine("detected enabled esper");
                foreach (var p in gPlayer)
                {

                   // Console.WriteLine("looping through players");
                    var mousePosition = Input.mousePosition;
                    Vector3 position3 = p.transform.position;
                    var target =
                        gCamera.transform.position +
                        gCamera.transform.forward; //Calculate a point facing straight away from us
                    var w2s = gCamera.WorldToScreenPoint(target); //Translate position to screen
                    var v = Camera.main.WorldToScreenPoint(position3);
                    var num1 = Vector2.Distance(w2s, v);


                    position3.y += 6.5f;

                    Vector3 vector2 = Camera.main.WorldToScreenPoint(position3);
                    vector2.y = (float) Screen.height - vector2.y - 50f;
                    vector2.x -= 15f;

                    Vector2 vector3 = GUI.skin.label.CalcSize(new GUIContent(
                        p.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + p.playerHP));


                    bool flag7 = vector2.x > (float) Screen.width - vector3.x;
                    if (flag7)
                    {

                        vector2.x = (float) Screen.width - vector3.x;
                    }

                    bool flag8 = vector2.y > (float) Screen.height - vector3.y;
                    if (flag8)
                    {
                        vector2.y = (float) Screen.height - vector3.y;
                    }

                    bool flag9 = vector2.x < 0f;
                    if (flag9)
                    {
                        vector2.x = 0f;
                    }

                    bool flag10 = vector2.y < 0f;
                    if (flag10)
                    {
                        vector2.y = 0f;
                    }

                    if (p.playerHP != 0 && p.playerName != myPlayer && num1 < 2100)
                    {
                        GUI.Label(new Rect(vector2, new Vector2(vector3.x, vector3.y)),
                            p.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + p.playerHP);
                        Color backgroundColor = GUI.backgroundColor;
                        GUI.backgroundColor = Color.red;
                        GUI.backgroundColor = backgroundColor;

                    }


                }

            }

        }
    }
}
