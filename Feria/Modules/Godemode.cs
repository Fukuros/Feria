using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;

namespace Feria.Modules
{
    class Godemode
    {

        [HarmonyPatch(typeof(GameScript), "GameServerSentPlayerDied")]
        public static class Godemode1
        {

            //typeof(GameScript).GetMethod("GameServerSentServerAttackHit");
            // Token: 0x0600008D RID: 141 RVA: 0x00007738 File Offset: 0x00005938
            private static bool Prefix()
            {

                return false;


            }

        }
    }
  
}
