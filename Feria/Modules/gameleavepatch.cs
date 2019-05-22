using System;
using System.CodeDom;
using System.Text;
using Harmony;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Feria.Modules
{

     class gameleavepatch1
    {
        static void Postfix(GameScript __instance)
        {
            try
               {
                 if (GuiMenu.FollowBot && FollowBot.endgame)
                   {
                       __instance.OnQuitYesClicked();
                   }

               }
               catch (Exception e)
               {
                   Console.WriteLine(e);
               }
               
          //  Console.WriteLine("hello from gameleave");
        }
    }
}