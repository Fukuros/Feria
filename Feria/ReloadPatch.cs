using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Feria
{
    [HarmonyPatch(typeof(GamePlayerController), "Update", null)]
    public static class ReloadPatch112
    {

        // Token: 0x06000090 RID: 144 RVA: 0x000077C0 File Offset: 0x000059C0
        private static void Prefix(GamePlayerController __instance)
        {
          
               __instance.reloadFinishTime = 0f;
               __instance.reloadStartTime = 0f;

        }
    }
}