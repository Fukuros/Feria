using UnityEngine;

namespace Feria
{
    public class Loader
    {
        private static GameObject Load;

        public static void Init()
        {
            Load = new GameObject();
            Load.AddComponent<Hax>();
            Load.AddComponent<GuiMenu>();
            Load.AddComponent<Aimbot>();
            Load.AddComponent<ESP>();
          Load.AddComponent<NoReload>();
           Load.AddComponent<WeaponAuguments>();

            Object.DontDestroyOnLoad(Load);
        }
    }
}