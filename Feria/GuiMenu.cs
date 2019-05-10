using UnityEngine;

namespace Feria
{
    public class GuiMenu : MonoBehaviour
    {
        public static bool NoSlow;
        public static bool Auto;
        public static bool NoReload;
        public static bool PickUp = false;
        public static bool EntityESP;
        public static bool LootESP = false;
        public static float EntityDist = 67.5f;

     
        private Rect _window;

    
        private Rect _window2;

       
        private Rect _window3;

        private Rect _window4;

     
        public bool ItemsVisible = false;

       
        public bool OptionsVisible = false;

   
        public bool OtherVisible = false;

       
        public bool Visible = true;


        public void Start()
        {
            _window = new Rect(10f, 10f, 250f, 150f);
            _window2 = new Rect(10f, 10f, 250f, 150f);
            _window3 = new Rect(10f, 10f, 250f, 150f);
            _window4 = new Rect(10f, 10f, 250f, 150f);
        }

   
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Home)) Visible = !Visible;
        }

     
        public void OnGUI()
        {
            if (!Visible) return;
            _window = GUILayout.Window(0, _window, Draw, "Feria v1.0");
            if (OptionsVisible) _window2 = GUILayout.Window(1, _window2, DrawESPOptions, "Entity Options");
            if (ItemsVisible) _window3 = GUILayout.Window(2, _window3, DrawAvailablePickups, "Loot options");
        }

        public void Draw(int id)
        {
            EntityESP = GUILayout.Toggle(EntityESP, "Entity ESP");
            NoReload = GUILayout.Toggle(NoReload, "No Reload");
            NoSlow = GUILayout.Toggle(NoSlow, "No Weapon Slow");
            Auto = GUILayout.Toggle(Auto, "Full Auto");
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("Zoom Distance: {0}", EntityDist));
            EntityDist = Mathf.Round(GUILayout.HorizontalSlider(EntityDist, 25.5f, 170f) * 5000f) / 5000f;
            GUI.DragWindow();
        }


        public void DrawESPOptions(int id)
        {
            GUILayout.Label("Entity Options:");
            GUILayout.Space(-5f);

            GUI.DragWindow();
        }


        public void DrawAvailablePickups(int id)
        {
            GUILayout.Label("Loot Options:");
            GUILayout.Space(-5f);

            GUI.DragWindow();
        }
    }
}