using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Runtime.Remoting.Channels;
using Microsoft.Win32;
using Steamworks;
using UnityEngine.UI;


namespace Feria
{
    public class GuiMenu : MonoBehaviour
    {
        // Token: 0x0600004A RID: 74 RVA: 0x00003B24 File Offset: 0x00001D24
        public void Start()
        {
            var path = Application.dataPath + "/License.dat";
            if (!File.Exists(path))
            {
                Console.WriteLine("we exist fam");

                System.IO.File.WriteAllText(path, stringToEdit);
            }
            else
            {
                string text = File.ReadAllText(path);
                Console.WriteLine("read from dat file  " + text);
                stringToEdit = "BIG GAY DOGS FUCKING YAOI BOIS"; //todo
            }
            this._window = new Rect(150f, 10f, 250f, 150f);
            this._window2 = new Rect(150f, 10f, 250f, 150f);
            this._window3 = new Rect(150f, 10f, 250f, 150f);
            this._window4 = new Rect(150f, 10f, 250f, 150f);
            InvokeRepeating("lastime", 3.0f, 10.0f);

        }

        // Token: 0x0600004B RID: 75 RVA: 0x00003B90 File Offset: 0x00001D90
        private void Update()
        {
          
            if (Input.GetKeyDown(KeyCode.Home))
            {
                this.Visible = !this.Visible;
            }
       //     Console.WriteLine("key is incorrect time is " + fadeout);
       if (stringToEdit == "BIG GAY DOGS FUCKING YAOI BOIS")
       {
           iscorrect = "This key is VALID!";
           runmeee = true;
          // Console.WriteLine("accepted");
       }

        }

        public void lastime()
        {
        
            if (runmeee)
            {
                Console.WriteLine("it's true dude");
                lnom = true;
            }
          
            // Token: 0x0600004C RID: 76 RVA: 0x00003BB0 File Offset: 0x00001DB0
        }



        // Token: 0x0600004C RID: 76 RVA: 0x00003BB0 File Offset: 0x00001DB0
        public void OnGUI()
        {

          
            if (!this.Visible)
            {
                return;
            }
            
         
                this._window = GUILayout.Window(2, this._window, new GUI.WindowFunction(this.Draw),
                    "Feria GuiMenu V0.3", new GUILayoutOption[0]);

            
           
        }



        public void Draw(int id)
        {
            GuiMenu.NoClip = GUILayout.Toggle(GuiMenu.NoClip, "NoClip", new GUILayoutOption[0]);
            GuiMenu.EntityESP = GUILayout.Toggle(GuiMenu.EntityESP, "Entity ESP", new GUILayoutOption[0]);
            GuiMenu.NoReload = GUILayout.Toggle(GuiMenu.NoReload, "No Reload", new GUILayoutOption[0]);
            GuiMenu.NoSlow = GUILayout.Toggle(GuiMenu.NoSlow, "No Weapon Slow", new GUILayoutOption[0]);
            GuiMenu.Auto = GUILayout.Toggle(GuiMenu.Auto, "Full Auto", new GUILayoutOption[0]);
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("Zoom Distance: {0}", GuiMenu.EntityDist), new GUILayoutOption[0]);
            GuiMenu.EntityDist = Mathf.Round(GUILayout.HorizontalSlider(GuiMenu.EntityDist, 25.5f, 170f, new GUILayoutOption[0]) * 5000f) / 5000f;
            GUI.DragWindow();
        }

        public void Draw1(int id)
        {
            stringToEdit = GUILayout.TextField(stringToEdit, 99, new GUILayoutOption[0]);
        //    stringToEdit1 = GUILayout.TextField("",30, new GUILayoutOption[0]);
          //  GUILayout.Space(0f);
            
            GUILayout.Box(iscorrect, new GUILayoutOption[0]);
            //  GuiMenu.EntityESP = GUILayout.Toggle(GuiMenu.EntityESP, "Entity ESP", new GUILayoutOption[0]);
            GUI.DragWindow();
            
        }

       
       

        // Token: 0x04000032 RID: 50
        public bool Visible = true;

        // Token: 0x04000032 RID: 50
        public bool OptionsVisible = false;

        // Token: 0x04000032 RID: 50
        public bool ItemsVisible = false;

        // Token: 0x04000032 RID: 50
        public bool OtherVisible = false;

        // Token: 0x04000035 RID: 53
        private Rect _window;

        // Token: 0x04000036 RID: 54
        private Rect _window2;

        // Token: 0x04000037 RID: 55
        private Rect _window3;

        private Rect _window4;
        private string stringToEdit = "Insert Product Key";
        private string stringToEdit1 = "?";
        public static bool NoSlow = false;
        public static bool Auto = false;
        public static bool NoReload = false;
        public static bool PickUp = false;

        public static bool NoClip = false;

        public static bool EntityESP = false;
        public static bool LootESP = false;
        public  static float EntityDist = 67.5f;
        private string iscorrect = "The Key is invalid!";
        private bool runmeee;
        private bool lnom;
        private float fadeout;
    }
}