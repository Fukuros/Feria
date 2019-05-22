using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodeStage.AntiCheat.ObscuredTypes;
using Harmony;
using Lidgren.Network;

namespace Feria.Modules
{
    class gameplayernpatch
    {


        [HarmonyPatch(typeof(GamePlayerNetworked), "Update")]
        public static class yyyyyyyy
        {

            //typeof(GameScript).GetMethod("GameServerSentServerAttackHit");
            // Token: 0x0600008D RID: 141 RVA: 0x00007738 File Offset: 0x00005938
            private static void Postfix(GamePlayerNetworked __instance)
            {
                Aimbot.yMovement = __instance.transform.localPosition.y - Aimbot.lastyPosition;
                Aimbot.lastyPosition = __instance.transform.localPosition.y;


            }


        }

    }
}