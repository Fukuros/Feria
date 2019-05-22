using System;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Feria.Modules;
using Harmony;
using Lidgren.Network;
using Steamworks;
using UHWID;
using UnityEngine;

namespace Feria
{
    public class Hax : MonoBehaviour
    {
      


        public Hax()
        {

            CodeStage.AntiCheat.Detectors.InjectionDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();
          
            try
            {
                HarmonyInstance.DEBUG = true;
                var h = HarmonyInstance.Create("Heck");
                
               var y = typeof(GameScript).GetMethod("GameServerSentChatMessage");
                if (y == null)
                   Console.WriteLine("it's null");
               else
                    Console.WriteLine("Method found");
               //  h.Patch(y, new HarmonyMethod(typeof(Patchx1.chatpatch), "Prefix"), new HarmonyMethod());
               Console.WriteLine(" > Chat patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }

            try
            {
                var h = HarmonyInstance.Create("Heck1");
                var y = typeof(GamePlayerController).GetMethod("CheckPointIsValidWalkSpace", BindingFlags.NonPublic |  BindingFlags.Instance);
                if (y == null)
                    Console.WriteLine("it's null");
                else
                    Console.WriteLine("Method found");
                h.Patch(y, new HarmonyMethod(typeof(NoClip.NoClip1), "Prefix"), new HarmonyMethod());
                Console.WriteLine(" > No Clip patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }


            try
            {
                var h = HarmonyInstance.Create("Heck3");
                var y = typeof(GamePlayerController).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                if (y == null)
                  Console.WriteLine("it's nullxx");
               else
                    Console.WriteLine("xxxx found");
                h.Patch(y, new HarmonyMethod(typeof(Godemode.hPatchhoriz), "Postfix"), new HarmonyMethod());
                Console.WriteLine(" > movement patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }

            try
            {
                var h = HarmonyInstance.Create("Heck4");
                var y = typeof(MainMenuScript).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                if (y == null)
                    Console.WriteLine("it's nullxx");
                else
                    Console.WriteLine("xxxx found");
                h.Patch(y, new HarmonyMethod(typeof(gamestartpatch1), "Postfix"), new HarmonyMethod());
                Console.WriteLine(" > startgame patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }

            try
            {
                var h = HarmonyInstance.Create("Heck5");
                var y = typeof(GameScript).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                if (y == null)
                    Console.WriteLine("it's nullxx");
                else
                    Console.WriteLine("xxxx found");
                h.Patch(y, new HarmonyMethod(typeof(gameleavepatch1), "Postfix"), new HarmonyMethod());
                Console.WriteLine(" > endgame patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }


            try
            {
                var h = HarmonyInstance.Create("Heck6");
                var y = typeof(GamePlayerNetworked).GetMethod("Update", BindingFlags.NonPublic | BindingFlags.Instance);
                if (y == null)
                    Console.WriteLine("it's nullxx");
                else
                    Console.WriteLine("xxxx found");
                h.Patch(y, new HarmonyMethod(typeof(gameplayernpatch.yyyyyyyy), "Postfix"), new HarmonyMethod());
                Console.WriteLine(" > YMOVEMENTGET patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }

     
        }


        
        public void Update()
        {
            Camera.main.orthographicSize = GuiMenu.EntityDist;

        }
    }
}