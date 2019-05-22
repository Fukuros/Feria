using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.Security;
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
            this._window = new Rect(350f, 50f, 250f, 150f);
            this._window2 = new Rect(150f, 10f, 250f, 150f);
            this._window3 = new Rect(150f, 10f, 250f, 150f);
            this._window4 = new Rect(150f, 10f, 250f, 150f);
        

        }

        // Token: 0x0600004B RID: 75 RVA: 0x00003B90 File Offset: 0x00001D90
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Home))
            {
                this.Visible = !this.Visible;
            }



            ///// START REBINDING OF KEYS
            ///
            /// WOW


            if (this.WaitingAimbotKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    AimKey = current.keyCode;
                    this.WaitingAimbotKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    AimKey = keyCode_;
                    WaitingAimbotKey = false;
                }

            }
             // ESP ESP ESP ESP 
            if (this.WaitingEntityESPKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    EspKey = current.keyCode;
                    this.WaitingEntityESPKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    EspKey = keyCode_;
                    WaitingEntityESPKey = false;
                }

            }


            if (this.WaitingAutoKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    AutoKey = current.keyCode;
                    this.WaitingAutoKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    AutoKey = keyCode_;
                    WaitingAutoKey = false;
                }

            }


            if (this.WaitingFastHackKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    FastKey = current.keyCode;
                    this.WaitingFastHackKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    FastKey = keyCode_;
                    WaitingFastHackKey = false;
                }

            }


            if (this.WaitingNoReloadKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    NoReloadKey = current.keyCode;
                    this.WaitingNoReloadKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    NoReloadKey= keyCode_;
                    WaitingNoReloadKey = false;
                }

            }


            if (this.WaitingNoSlowKey)
            {
                Event current = Event.current;
                if (current.isKey && current.type == EventType.KeyUp)
                {
                    Console.WriteLine("bruh we set it to " + current.keyCode);
                    NoSlowKey = current.keyCode;
                    this.WaitingNoSlowKey = false;
                }

                if (current.isMouse && current.type == EventType.MouseDown)
                {
                    KeyCode keyCode_ = KeyCode.Mouse1;
                    int button = current.button;
                    if (button == 0)
                    {
                        keyCode_ = KeyCode.Mouse0;
                    }

                    if (button == 1)
                    {
                        keyCode_ = KeyCode.Mouse1;
                    }

                    if (button == 2)
                    {
                        keyCode_ = KeyCode.Mouse2;
                    }

                    if (button == 3)
                    {
                        keyCode_ = KeyCode.Mouse3;
                    }

                    if (button == 4)
                    {
                        keyCode_ = KeyCode.Mouse4;
                    }

                    if (button == 5)
                    {
                        keyCode_ = KeyCode.Mouse5;
                    }

                    if (button == 6)
                    {
                        keyCode_ = KeyCode.Mouse6;
                    }

                    NoSlowKey = keyCode_;
                    WaitingNoSlowKey = false;
                }

            }

            if (Input.GetKeyUp(NoSlowKey))
            {
                NoSlow = !NoSlow;
            }
            if (Input.GetKeyUp(NoReloadKey))
            {
                NoReload = !NoReload;
            }
            if (Input.GetKeyUp(EspKey))
            {
                EntityESP = !EntityESP;
            }
            if (Input.GetKeyUp(AutoKey))
            {
                Auto = !Auto;
            }
            if (Input.GetKeyUp(FastKey))
            {
                FastHack = !FastHack;
            }
         


        }



   

        // Token: 0x0600004C RID: 76 RVA: 0x00003BB0 File Offset: 0x00001DB0
        public void OnGUI()
        {

            if (Bindings)
            {
                this._window2 = GUILayout.Window(1, this._window2, new GUI.WindowFunction(this.DrawBindingOptions), "Bindings Menu", new GUILayoutOption[0]);
            }
            // replace steamId with myuniqueidis
            CSteamID steamId = SteamUser.GetSteamID();
            if (steamId == steamId)
            {

           
            if (!this.Visible)
            {
                return;
            }
            
         
                this._window = GUILayout.Window(2, this._window, new GUI.WindowFunction(this.Draw),
                    "Feria v1.1", new GUILayoutOption[0]);

            }
            else
            {
                Console.WriteLine("WE COULD NOT AUTHENTICATE YOUR ID");
            }




         

        }

        public void DrawBindingOptions(int id)
        {
         
            GUILayout.Space(5f);
            if (WaitingAimbotKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("Aimbot Key: " + AimKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingAimbotKey = true;
            }


            if (WaitingEntityESPKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("Entity Esp Key: " + EspKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingEntityESPKey = true;
            }

            if (WaitingFastHackKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("Fast Hack Key: " + FastKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingFastHackKey = true;
            }

            if (WaitingAutoKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("Full Auto Key: " + AutoKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingAutoKey = true;
            }

         

            if (WaitingNoReloadKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("No Reload Key: " + NoReloadKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingNoReloadKey = true;
            }

            if (WaitingNoSlowKey)
            {
                GUILayout.Button("Waiting For Key..", new GUILayoutOption[0]);
            }
            else if (GUILayout.Button("No Weapon Slow Key: " + NoSlowKey.ToString(), new GUILayoutOption[0]))
            {
                this.WaitingNoSlowKey = true;
            }


            GUI.DragWindow();
        }

        public void Draw(int id)
        {
           


            GuiMenu.Aimbot = GUILayout.Toggle(GuiMenu.Aimbot, "Aimbot", new GUILayoutOption[0]);
            GuiMenu.EntityESP = GUILayout.Toggle(GuiMenu.EntityESP, "Entity ESP", new GUILayoutOption[0]);

            GuiMenu.FastHack = GUILayout.Toggle(GuiMenu.FastHack, "Fast Hack(Very Obvious)", new GUILayoutOption[0]);
            GuiMenu.Auto = GUILayout.Toggle(GuiMenu.Auto, "Full Auto", new GUILayoutOption[0]);
            GuiMenu.NoReload = GUILayout.Toggle(GuiMenu.NoReload, "No Reload", new GUILayoutOption[0]);
   
            GuiMenu.NoSlow = GUILayout.Toggle(GuiMenu.NoSlow, "No Weapon Slow", new GUILayoutOption[0]);
           
    
            GUILayout.Space(10f);
            GUILayout.Label(string.Format("Zoom Distance: {0}", GuiMenu.EntityDist), new GUILayoutOption[0]);
            GuiMenu.EntityDist = Mathf.Round(GUILayout.HorizontalSlider(GuiMenu.EntityDist, 25.5f, 170f, new GUILayoutOption[0]) * 5000f) / 5000f;
            if (GUILayout.Button("Bindings Options", new GUILayoutOption[0]))
            {
                this._window2.x = this._window.width + 20f;
                this.Bindings = !this.Bindings;
            }
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
        public static bool FollowBot = false;
        public static bool Teleport;
        public static bool NoReload = false;
        public static bool PickUp = false;

        public static bool NoClip = false;

        public static bool Aimbot = false;
        public static bool EntityESP = false;
        public static bool LootESP = false;
        public  static float EntityDist = 67.5f;
        private string iscorrect = "The Key is invalid!";
        private bool runmeee;
        private bool lnom;
        private float fadeout;
        public static float aimbotslider;
        public static bool FastHack = false;
       public CSteamID myuniqueidis = (CSteamID)76561198164502417;
       public static KeyCode AimKey = KeyCode.Mouse1;
       public static KeyCode EspKey = KeyCode.F6;
       public static KeyCode FastKey = KeyCode.F7;
       public static KeyCode AutoKey = KeyCode.F8;
       public static KeyCode NoReloadKey = KeyCode.F9;
       public static KeyCode NoSlowKey = KeyCode.F10;
        private bool WaitingAimbotKey;
        private bool WaitingFastHackKey;
        private bool WaitingAutoKey;
        private bool WaitingNoReloadKey;
        private bool WaitingEntityESPKey;
        private bool WaitingNoSlowKey;
        private bool Bindings;
    }
}