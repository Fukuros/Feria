using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Harmony;
using UnityEngine;
using UnityEngine.UI;

namespace Feria.Modules
{
    class NoClip
    {


        [HarmonyPatch(typeof(GamePlayerController), "CheckPointIsValidWalkSpace")]
        public static class NoClip1
        {


            // Token: 0x0600008D RID: 141 RVA: 0x00007738 File Offset: 0x00005938
            private static bool Prefix(ref bool __result)
            {
                if (GuiMenu.NoClip)
                {
                    __result = true;
                    return false;
                }

                return true;
            }
        
        }
    }
}