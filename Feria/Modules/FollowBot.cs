using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WindowsInput;
using Harmony;
using Lidgren.Network;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace Feria.Modules
{
    class FollowBot : MonoBehaviour
    {
        private string myPlayer;
        private GameScript gScript;
        private Camera gCamera;
        private GamePlayerNetworked[] gPlayer;
        private float myHealth = 100;
        private int myID = 0;
        private Vector3 myPos;
        private float friendisparachuting;

        public string friendname { get; private set; }

        private float friendHealth =100;
        private int xdir;
        private int ydir;
        private int myfirstfriend = 999;
        private int mysecondfriend = 999;
        private int mythirdfriend = 999;
        private int myfourthfriend = 999;
        private int finalfriend =1;
        private GamePlayerController gController;
        private MainMenuScript mScript;
        public static bool endgame;

        public Vector3 friendPos { get; private set; }

   

        private static void Send(NetOutgoingMessage msg, NetDeliveryMethod method, int optionalSequenceChannel)
        {
            GameServerManager.netClient.SendMessage(msg, method, optionalSequenceChannel);
        }
        public static void ClientSendFlightEjectToServer()
        {
            NetOutgoingMessage netOutgoingMessage = GameServerManager.netClient.CreateMessage();
            netOutgoingMessage.Write(7);
          Send(netOutgoingMessage, NetDeliveryMethod.ReliableOrdered, 0);
        }
        public void Start()
        {
          

            Console.WriteLine("Friend Module Loaded");

            myPlayer = SteamFriends.GetPersonaName();

            //      InvokeRepeating("FetchPlayer", 1.0f,
            // 0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchCamera", 1.0f, 0.3f);
            InvokeRepeating("FetchScript", 1.0f,
                0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("CompareObjectsLive", 1.0f, 1.0f);
        }
        public void CompareObjectsLive()
        {
            if (gPlayer == null)
            {

                FetchPlayer(); // INITIAL OBJECT DOES NOT EXIST SO CREATE IT 


            }

            if (gScript == null && gPlayer != null)
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
              //  Console.WriteLine("Player length is not correct forcing fetch player method " + "Length " + gPlayer.Length + "Players Alive" + gScript.playersAliveCount);
                FetchPlayer();
            }
        }
        public void Update()
        {
            //AccessTools.Method(MainMenuScript, "PerfomPlay").Invoke(mScript,null);
            if (GuiMenu.FollowBot)
            {


                if (gScript != null)
                {
                    FollowFriend();
                    friendcheck();
                    // myfirstfriend = gScript.playerIDsOnLocalTeamOrdered.Find(i => i > 0);

                    //  mysecondfriend = gScript.playerIDsOnLocalTeamOrdered.Find(i => i > myfirstfriend);
                    Console.WriteLine(myfirstfriend);
                    Console.WriteLine(mysecondfriend);

                }

                if (myHealth == 0 && gScript != null)
                {
                    Console.WriteLine("i dead..");
                    endgame = true;
                    myHealth = 100;
                    friendHealth = 100;
                    Console.WriteLine("ended game");
                    Console.WriteLine("myxxx health" + myHealth);
                }
                else
                {
                    endgame = false;
                    Console.WriteLine("starting game");
                    Console.WriteLine("my yyhealth" + myHealth);
                }
            }
        }

        public void friendcheck()
        {
            try
            {

                var wow = gScript.playerIDsOnLocalTeamOrdered;
                

         

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
            }
           

            //      myfirstfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > 0);
            //      mysecondfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > myfirstfriend);
            //     mythirdfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > mysecondfriend);
            //     myfourthfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > mythirdfriend);
          //  Console.Write("Friend 1 is " + Environment.NewLine + myfirstfriend + Environment.NewLine + mythirdfriend + Environment.NewLine + mysecondfriend + Environment.NewLine + myfourthfriend);

        }
        public void FollowFriend()
        {


      
            foreach (var p in gPlayer)
            {
                if (p.playerName == myPlayer)
                {
                    /// Grabbing my values
                    ///
                    ///
                    myHealth = p.playerHP;
                    myID = p.playerID;
                  //  Console.WriteLine("my id is this please dont use as friend" + myID);
                    myPos = p.transform.position;
                   // p.currentWalkMode = PlayerWalkMode.Roll;

                }


                if (p.playerID == 63)
                {
                    /// Grabbing my values
                    ///
                    ///
                    ///
                    ///
                    /// 
                    Console.WriteLine("my friendname is " +friendname);
                    friendisparachuting = p.currParachuteHeight;
                    friendname = p.playerName;
                    friendHealth = p.playerHP;
                    friendPos = p.transform.position;
                }

                if(friendisparachuting > 0)
                {
                  //  ClientSendFlightEjectToServer();
                }

                if (friendPos.x !=0 && myHealth != 0)
                {
                 //   Console.WriteLine("my friend is: " +friendname);
                  //  var DistanceToEnemy = Vector2.Distance(friendPos, myPos);
                   
                        xdir = friendPos.x > myPos.x ? 1 : -1;
                        ydir = friendPos.y > myPos.y ? 1 : -1;
                    
                 

                    Godemode.myplayerhoriz = xdir;
                    Godemode.myplayerverit = ydir;
           
                    
                 //   Console.WriteLine("my friend is x: " + friendPos.x  + "My Pos is x: " + myPos.x);
                   // Console.WriteLine("my friend is y: " + friendPos.y + "My Pos is y: " + myPos.y);


                 //   Console.WriteLine("ydir xdir " + ydir +" "+ xdir);
                }

           


            }
       


        }


        public void FetchPlayer()
        {
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
        }

        public void FetchCamera()
        {
            gCamera = FindObjectOfType<Camera>(); // Load Camera Class/Object into Memory
        }

        public void FetchScript()
        {
            gScript = FindObjectOfType<GameScript>(); // Load GameScript Class/Object into Memory
        }

        public void FetchController()
        {
            gController = FindObjectOfType<GamePlayerController>(); // Load GameScript Class/Object into Memory
        }
        public static object InvokeMethod(object obj, string methodName, params object[] methodParams)
        {
            var methodParamTypes = methodParams?.Select(p => p.GetType()).ToArray() ?? new Type[] { };
            var bindingFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static;
            MethodInfo method = null;
            var type = obj.GetType();
            while (method == null && type != null)
            {
                method = type.GetMethod(methodName, bindingFlags, Type.DefaultBinder, methodParamTypes, null);
                type = type.BaseType;
            }

            return method?.Invoke(obj, methodParams);
        }

    }
    }
