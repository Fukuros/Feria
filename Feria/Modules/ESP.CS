using System;
using Steamworks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Feria
{
    internal class ESP : Hack
    {
        private Camera gCamera;

        private GamePlayerNetworked[] gPlayer;
        private string myPlayer;

        override public void Start()
        {
            myPlayer = SteamFriends.GetPersonaName();
            Console.WriteLine("ESP Module Loaded");
            b.InvokeRepeating("FetchPlayer", 1.0f,
                1.0f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            b.InvokeRepeating("FetchCamera", 1.0f, 1.0f);
        }


        public ESP(Hax b):base("ESP", b)
        {
         
        }


        override public void OnGUI()
        {
            Esper();
        }

        public void FetchPlayer()
        {
          
            gPlayer = MonoBehaviour.FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
         
        }

        public void FetchCamera()
        {
      
            gCamera = MonoBehaviour.FindObjectOfType<Camera>(); // Load Camera Class/Object into Memory
           
        }

        private void Esper()
        {
            //Console.WriteLine("called update no ESPER");
            //   Console.WriteLine("started func ESPER");
            if (enabled)
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

        public override void Update()
        {
         //   throw new NotImplementedException();
        }
    }
}