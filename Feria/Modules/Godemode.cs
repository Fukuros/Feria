using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStage.AntiCheat.ObscuredTypes;
using Harmony;
using Lidgren.Network;

namespace Feria.Modules
{
    class Godemode
    {
        public static float myplayerverit;
        public static float myplayerhoriz;

        [HarmonyPatch(typeof(GamePlayerController), "Update")]
        public static class hPatchhoriz
        {

            //typeof(GameScript).GetMethod("GameServerSentServerAttackHit");
            // Token: 0x0600008D RID: 141 RVA: 0x00007738 File Offset: 0x00005938
            private static void Postfix(ref float ___vertInput, ref float ___horizInput, ref bool ___pressedJumpDuringAJump, GamePlayerController __instance, ref ObscuredFloat ___actY,
                ref ObscuredFloat ___actX)
            {
                GamePlayerNetworked component = __instance.gameObject.GetComponent<GamePlayerNetworked>();

              //    ___vertInput = myplayerverit;
            //       ___horizInput = myplayerhoriz;

                /// TELEPORT TO FRIEND







                ___pressedJumpDuringAJump = false;
                if (___horizInput != 0 || ___vertInput != 0)
                {
                    //   Console.WriteLine("We're moving so get that cash");
                  //  component.currentWalkMode = PlayerWalkMode.Normal;
                  if (GuiMenu.FastHack)
                  {
                      component.currentWalkMode = PlayerWalkMode.Roll;
                    }
                  

                }

                //  component.RollPerformed();


            }

        }


    }

}
