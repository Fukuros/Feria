using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Feria.Modules;
using Harmony;
using UnityEngine;

namespace Feria
{
    public class Hax : MonoBehaviour
    {
      


        public Hax()
        {
    


            try
            {
                HarmonyInstance.DEBUG = true;
                var h = HarmonyInstance.Create("Heck");
                
               var y = typeof(GameScript).GetMethod("GameServerSentChatMessage");
                if (y == null)
                   Console.WriteLine("it's null");
               else
                    Console.WriteLine("Method found");
                 h.Patch(y, new HarmonyMethod(typeof(Patchx1.chatpatch), "Prefix"), new HarmonyMethod());
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
                var h = HarmonyInstance.Create("Heck2");
                var y = typeof(GameScript).GetMethod("GameServerSentPlayerDied");
                if (y == null)
                    Console.WriteLine("it's nullxx");
                else
                    Console.WriteLine("Method found");
                //h.Patch(y, new HarmonyMethod(typeof(Godemode.Godemode1), "Prefix"), new HarmonyMethod());
                Console.WriteLine(" > GodMode patch!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);


            }
            //GameScript
            // GameServerSentPerformAttack

            
        }



        public void Update()
        {
            Camera.main.orthographicSize = GuiMenu.EntityDist;
        }
    }
}