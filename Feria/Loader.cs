using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
namespace Feria
{
    public class Loader     
    {
        public static void Init()
        {

            Loader.Load = new GameObject();
            Loader.Load.AddComponent<Hax>();
         //   Loader.Load.AddComponent<GuiMenu>();
            Loader.Load.AddComponent<Aimbot>();
          //  Loader.Load.AddComponent<ESP>();
           // Loader.Load.AddComponent<NoReload>();
            Loader.Load.AddComponent<WeaponAuguments>();

            UnityEngine.Object.DontDestroyOnLoad(Loader.Load);
        }

        public static GameObject Load;
    }
}
