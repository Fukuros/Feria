using Harmony;
using System;
using System.Collections;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Lidgren.Network;
using PlayFab.PlayStreamModels;
using UnityEngine;  

namespace Feria
{
    public class Hax : MonoBehaviour
    {
        private int i;
        private GamePlayerNetworked[] Peoples;
        private Camera cam;

        public LevelType LevelT { get; private set; }

        private InventoryBaseType weapon1;
        private GamePlayerController gplayer;
       
        private LevelType level;
        private GameCamera gcam;
        private GamePlayerNetworked gnetwork;
        private GameScript gscript;
        private MainMenuCamera MENUcam;
        private GameLoot[] lotties;
        private GamePlayerNetworked _Player;
        public string pig = "0";
        public int pig1;


        private string iName;

        private Vector3 myplayer;
        private string itemid;

        public int wait1;
        private const UInt32 StdOutputHandle = 0xFFFFFFF5;
        [DllImport("kernel32.dll")]
        private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
        [DllImport("kernel32.dll")]
        private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
        [DllImport("kernel32")]
        static extern bool AllocConsole(int pid);
        [DllImport("msvcrt.dll")]
        public static extern int system(string cmd);
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);
          [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
   public static extern void mouse_event(uint dwFlags, uint cButtons, uint dwExtraInfo);
   //Mouse actions
   private const int MOUSEEVENTF_LEFTDOWN = 0x02;
   private const int MOUSEEVENTF_LEFTUP = 0x04;
   private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
   private const int MOUSEEVENTF_RIGHTUP = 0x10;
        private float timeSinceLastCalled;
        public short personofinterest;
        private readonly float delay = 1f;
        public short myid;
        private bool ranonce = false;
        private GamePlayerController gplayerx;
        private static float myplayerx;
        private static float myplayery;
        private static float myplayerz;
        private float velocity;
        private GamePlayerNetworked closestEnemy;
        private double yMovement;
        private double lastyPosition;
        private double newydirection;
        public  Vector3 mousePosition;
        private short myfriend;
        private int myfirstfriend =999;
        private int mysecondfriend = 999;
        private int mythirdfriend = 999;
        private int myfourthfriend = 999;
        private float previous;
        private bool nomoreloop = true;
        private WeaponType gearload;
        private float pspeed = 0;

        public int CurMovSpeed { get; private set; }
        public object Playerclosest { get; private set; }

        public Hax()
        {
          
            CodeStage.AntiCheat.Detectors.InjectionDetector.Dispose();
            CodeStage.AntiCheat.Detectors.ObscuredCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.SpeedHackDetector.Dispose();
            CodeStage.AntiCheat.Detectors.TimeCheatingDetector.Dispose();
            CodeStage.AntiCheat.Detectors.WallHackDetector.Dispose();

            AllocConsole(-1);
            var stdout = Console.OpenStandardOutput();
            var sw = new System.IO.StreamWriter(stdout, Encoding.Default);
            sw.AutoFlush = true;
            Console.SetOut(sw);
            Console.SetError(sw);


        }
       
        public void Start()
        {
           
            InvokeRepeating("updateobject", 1.0f, 0.5f);
            //InvokeRepeating("friendcheck", 1.0f, 66.0f);

        }

        public void Update()
        {


            if (Input.GetKey(KeyCode.Mouse1))
            {
                aimbot();
                Console.WriteLine("doing aimbot");

            }

            NoReloadTime();
            Camera.main.orthographicSize = Menu.EntityDist;
         
        }


        public void updateobject()
        {
            lotties = FindObjectsOfType<GameLoot>(); //Get camera
            cam = FindObjectOfType<Camera>(); //Get camera  
            gscript = FindObjectOfType<GameScript>();
            gplayer = FindObjectOfType<GamePlayerController>();
            Peoples = FindObjectsOfType<GamePlayerNetworked>();
            DontDestroyOnLoad(transform.gameObject);
            foreach (var p in Peoples)
            {
                if (p.playerName == "Phone")
                {
                    myplayerx = p.transform.position.x;
                    myplayery = p.transform.position.y;
                    myplayerz = p.transform.position.z;
                    short num16 = p.equipmentIDs[p.currentEquipmentIndex];
                    gearload = WeaponType.GetAllWeaponTypes()[num16];
                    Console.WriteLine(gearload.GetWeaponName());
                    gearload.canHoldFire = true;
                    gearload.gunMoveSpeedMult = 1.3f;
                    pspeed = gearload.bulletMoveSpeed;

                }
            }

            //  Console.WriteLine("Updated objects");


        }

        public void NoReloadTime()
        {
            if (Menu.NoReload)
            {
                gplayer.reloadFinishTime = 0;
              //  Console.WriteLine("im gay" + gplayer.reloadFinishTime);
            }
        }
     
        public void walkalltime()
        {
            if (Menu.NoReload)
            {
               
                //Console.WriteLine("im gay" + gplayer.reloadFinishTime);
            }
        }

        public void OnGUI()

        {

         //   ZatsRenderer.DrawLine(mousePosition, closestEnemy.transform.position);
            drawnewesp();
         //  DrawEsp();
      //      GUI.Label(new Rect(3, 30, 300f, 20f), "REEEEE");
       //     GUI.Label(new Rect(3, 30, 300f, 20f), "REEEEE" + i + wait1);
        }

        private IEnumerator SleepFor(float Time)
        {
            yield return new WaitForSeconds(Time);
        }

        public void friendcheck()
        {
            myfirstfriend = gscript.playerIDsOnLocalTeamOrdered[0];
            mysecondfriend = gscript.playerIDsOnLocalTeamOrdered[1];
            mythirdfriend  = gscript.playerIDsOnLocalTeamOrdered[2];
            myfourthfriend  = gscript.playerIDsOnLocalTeamOrdered[3];


          //  myfirstfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > 0);
         //   mysecondfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > myfirstfriend);
          //  mythirdfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > mysecondfriend);
           // myfourthfriend = gscript.playerIDsOnLocalTeamOrdered.Find(i => i > mythirdfriend);
            Console.Write("all my friends are - " + Environment.NewLine + myfirstfriend + Environment.NewLine + mythirdfriend + Environment.NewLine + mysecondfriend + Environment.NewLine + myfourthfriend);

        }

       
        public void aimbot()
        {
          //  Console.WriteLine("Ran Aimbot function");

        

            //  int xPos = 30, yPos = 1000;
            //     SetCursorPos(xPos, yPos);//Call this when you want to set the mouse position
          //  Console.WriteLine("Key Pressed" );
            
                var screenMid = new Vector2(Screen.width, Screen.height);
                foreach (var p in Peoples)
                {

                   
             

                  //  Console.WriteLine("velocity:" + velocity);
                // / Console.WriteLine("my y movement: " + yMovement);
                //  Console.WriteLine("my lasty movement: " + lastyPosition);
                //   Console.WriteLine("my yyyyyy movement: " + newydirection);
                //  walkalltime();\
              mousePosition = Input.mousePosition;
        
             
                    Vector3 position3 = p.transform.position;
                    var target =
                        cam.transform.position + cam.transform.forward; //Calculate a point facing straight away from us
                    var w2s = cam.WorldToScreenPoint(target); //Translate position to screen
                    var v = Camera.main.WorldToScreenPoint(position3);
                    var num1 = Vector2.Distance(w2s, v);

                    var vy = (float) Screen.height - v.y - 30f;
                    var vxx = v.x;
                    var vx = v.x + p.xMovement;

                var num2 = Vector2.Distance(mousePosition, v);

                int xOut = Convert.ToInt32(vx);
                    int yOut = Convert.ToInt32(vy);
                    LevelType currentLevel = gscript.currentLevel;
                bool flag3 = currentLevel.GetIsCollisionBetweenPoints((uint)myplayerx, (uint)myplayery, (uint)p.transform.position.x, (uint)p.transform.position.y, CollisionType.MovementAndSight);


                
                if (p.playerHP != 0 && num2 < 250 && p.playerName != "Phone" && !flag3 && p.playerID != myfirstfriend && p.playerID != mysecondfriend && p.playerID != mythirdfriend && p.playerID != myfourthfriend)
                {

                    velocity = (p.transform.position.y - previous) / Time.deltaTime;
                    previous = p.transform.position.y;
               
                 
                //  Console.Write("Distance From Me ?" + num1);
                      if (pspeed != 0)
                      {

                          Console.WriteLine("TTI" + time_of_impact(p.transform.position.x, p.transform.position.y, p.GetCurrentMoveSpeed(), p.GetCurrentMoveSpeed(), pspeed));
                         
                        CurMovSpeed = (int)num1 / (int)pspeed + Convert.ToInt32(p.GetCurrentMoveSpeed() + time_of_impact(p.GetCurrentMoveSpeed(), p.GetCurrentMoveSpeed(), p.xMovement, velocity, pspeed) );
                        

                       }
                      else
                      {
                          
                              CurMovSpeed = Convert.ToInt32(p.GetCurrentMoveSpeed());
                        
                      }


                    // ZatsRenderer.DrawLine(mousePosition, p.transform.position);
                    if (p.xMovement > 0 && velocity < 0)
                    {
                        SetCursorPos(xOut + CurMovSpeed, yOut + CurMovSpeed); //Call this when you want to set the mouse position
                      //  Console.WriteLine("R&D");
                    }else if (p.xMovement < 0 && velocity < 0)
                    {
                        SetCursorPos(xOut - CurMovSpeed, yOut + CurMovSpeed); //Call this when you want to set the mouse position
                      //  Console.WriteLine("L&D");
                    }
                    else if (p.xMovement > 0 && velocity > 0)
                    {
                        SetCursorPos(xOut + CurMovSpeed, yOut - CurMovSpeed); //Call this when you want to set the mouse position
                       // Console.WriteLine("R&U");
                    }
                    else if (p.xMovement < 0 && velocity > 0)
                    {
                        SetCursorPos(xOut - CurMovSpeed, yOut - CurMovSpeed); //Call this when you want to set the mouse position
                       // Console.WriteLine("l&U");
                    }
                    else if (p.xMovement > 0) // goes right 
                    {
                       SetCursorPos(xOut + CurMovSpeed, yOut); //Call this when you want to set the mouse position
                      // Console.WriteLine("Going Right");
                    }else if (p.xMovement < 0) // goes left
                    {
                        SetCursorPos(xOut - CurMovSpeed, yOut); //Call this when you want to set the mouse position
                     //   Console.WriteLine("Going Left");
                    }
                    else if (velocity < 0) // goes up
                    {
                        SetCursorPos(xOut , yOut + CurMovSpeed); //Call this when you want to set the mouse position
                      //  Console.WriteLine("Going Down");
                    }
                    else if (velocity > 0) // goes down 
                    {
                        SetCursorPos(xOut, yOut - CurMovSpeed); //Call this when you want to set the mouse position
                       // Console.WriteLine("Going Up");
                    } 
                    else 
                    {
                        SetCursorPos(xOut, yOut); //Call this when you want to set the mouse position

                    }
              
                   // DoMouseClick();



                    //    Console.WriteLine("set cursor to" + xOut + yOut + "Name: " + p.playerName + "EnemyPOS :" +p.transform.position.x + " "+ p.transform.position.y + " "+ "is collision ?" + flag3 + " " + myplayerx + " " + myplayery);
                }
                }
            


        }

       public static double time_of_impact(double px, double py, double vx, double vy, double s)
        {
            double a = s * s - (vx * vx + vy * vy);
            double b = px * vx + py * vy;
            double c = px * px + py * py;

            double d = (b + b) + (a + c);

            double t = 0;
            if (d >= 0)
            {
                t = (b + Math.Sqrt(d)) / a;
                if (t < 0)
                    t = 0;
            }

            return t;
        }

        public void DoMouseClick()
        {
         
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0);
        }


        private void drawnewesp()
        {

            if (Menu.EntityESP) {
                foreach (var cur in Peoples)
                {
                  
                    var target1 = cur.transform.position; //Calculate a point facing straight away from us

                    var w2s2 = cam.WorldToScreenPoint(target1); //Translate position to screen
                    if (w2s2.z < 0) //Behind screen?
                        return; //Skip
                    //   GUI.Label(new Rect(w2s.x, w2s.y, 3000f, 200f), "X" + pig + wtfdidwefind);
                    //   GUI.Label(new Rect(w2s.x, w2s.y, 3000f, 200f), "X" + pig + wtfdidwefind);


                    var dist = Vector3.Distance(myplayer, w2s2);
                    var mousePosition = Input.mousePosition;
                    Vector3 position3 = cur.transform.position;
                    var target = cam.transform.position + cam.transform.forward; //Calculate a point facing straight away from us
                    var w2s = cam.WorldToScreenPoint(target); //Translate position to screen
                    var v = Camera.main.WorldToScreenPoint(position3);
                    var num1 = Vector2.Distance(w2s, v);


                    position3.y += 6.5f;
                    Vector3 vector = Camera.main.WorldToScreenPoint(position3);
                    Vector3 vector2 = vector;
                    vector2.y = (float) Screen.height - vector2.y - 50f;
                    vector2.x -= 15f;
                    Vector2 vector3 = GUI.skin.label.CalcSize(new GUIContent(
                        cur.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + cur.playerHP ));
                    bool flag7 = vector2.x > (float) Screen.width - vector3.x;
                    if (flag7)
                    {
                        for (;;)
                        {
                            switch (3)
                            {
                                case 0:
                                    continue;
                            }

                            break;
                        }

                        vector2.x = (float) Screen.width - vector3.x;
                    }

                    bool flag8 = vector2.y > (float) Screen.height - vector3.y;
                    if (flag8)
                    {
                        vector2.y = (float) Screen.height - vector3.y;
                    }

                    bool flag9 = vector2.x < 0f;
                    if (flag9)
                    {
                        vector2.x = 0f;
                    }

                    bool flag10 = vector2.y < 0f;
                    if (flag10)
                    {
                        vector2.y = 0f;
                    }

                    if (cur.playerHP != 0 && cur.playerName != "phone" && num1 < 2100)
                    {
                        GUI.Label(new Rect(vector2, new Vector2(vector3.x, vector3.y)),
                            cur.playerName + Environment.NewLine + num1 + Environment.NewLine + "Health: " + cur.playerHP );
                        Color backgroundColor = GUI.backgroundColor;
                        GUI.backgroundColor = Color.red;
                        GUI.backgroundColor = backgroundColor;

                    }


                }

            }

            if (Menu.LootESP)
                foreach (var cur2 in lotties)
                {
                    Vector3 position3 = cur2.transform.position;
                    var target = cam.transform.position + cam.transform.forward; //Calculate a point facing straight away from us
                    var w2s = cam.WorldToScreenPoint(target); //Translate position to screen
                    var v = Camera.main.WorldToScreenPoint(position3);
                    var num1 = Vector2.Distance(w2s, v);
                    pig1++;
                    pig = "pig" + Peoples.Length;

                    var mousePosition = Input.mousePosition;
                    var position = cur2.transform.position;

                    position.y += 6.5f;
                 
                    var num2 = Vector2.Distance(mousePosition, v);


                    var target1 = cur2.transform.position; //Calculate a point facing straight away from us

                    var w2s2 = cam.WorldToScreenPoint(target1); //Translate position to screen
                    if (w2s2.z < 0) //Behind screen?
                        return; //Skip

                    var dist = Vector3.Distance(myplayer, target1);
                    itemid = cur2.itemInfo.ToString();
                    switch (itemid)
                    {
                        case "1":
                            iName = " Level 1 Armor";

                            break;
                        case "2":

                            iName = " Level 2 Armor";

                            break;
                        case "3":

                            iName = " Level 3 Armor";

                            break;
                        case "35":

                            iName = "Magnum";

                            break;
                        case "34":

                            iName = "Pistol";

                            break;
                        case "39":

                            iName = "Ak-47";

                            break;
                        case "10":

                            iName = "Health";

                            break;
                        case "41":

                            iName = "Sniper";

                            break;
                        case "0":

                            iName = "Broken Armor";

                            break;
                        case "38":

                            iName = "Pump ShotGun";

                            break;
                        case "37":

                            iName = "SMG";

                            break;
                        case "20":

                            iName = "Short bullets";

                            break;
                        case "43":
                            iName = "Grenade";
                            break;
                        case "44":

                            iName = "Bannna";

                            break;
                        case "21":

                            iName = "Little Bullets";

                            break;
                        case "8":

                            iName = "Shotgun Bullets";

                            break;
                        case "7":

                            iName = "Ammo";

                            break;
                        case "9":

                            iName = "Ammo";

                            break;
                        case "6":

                            iName = "Ammo";

                            break;
                        case "40":

                            iName = "big Health";
                            break;
                        default:
                            iName = "what the fuck is thing ";

                            break;
                    }


                    if (num2 < 1000)
                        GUI.Label(new Rect(w2s2.x - 50f, Screen.height - w2s2.y, 30300f, 23000f), "" + iName + num2); // THIS DRAWS NAMES

                }
        }
        private void DrawEsp()
        {
            if (Menu.EntityESP)
                foreach (var cur in Peoples)
                {
                   mousePosition = Input.mousePosition;
                    var position = cur.transform.position;
                    position.y += 6.5f;
                    var v = Camera.main.WorldToScreenPoint(position);
                    var num1 = Vector2.Distance(mousePosition, v);


                    pig1++;
                    pig = "pig" + Peoples.Length;


               


                    var target1 = cur.transform.position; //Calculate a point facing straight away from us

                    var w2s2 = cam.WorldToScreenPoint(target1); //Translate position to screen
                    if (w2s2.z < 0) //Behind screen?
                        return; //Skip


                    var dist = Vector3.Distance(myplayer, target1);
                    if (cur.playerHP != 0 && cur.playerName != "Phone" && num1 < 1000)
                    {
                       

                        ZatsRenderer.DrawBox(new Vector2(w2s2.x - 5, Screen.height - w2s2.y - 55), new Vector2(20, 45),
                            new Color(0.4f, 0.6f, 0.2f, 0.62f));

                        ZatsRenderer.DrawString(new Vector2(w2s2.x, Screen.height - w2s2.y),
                            cur.playerName + " Health: " + cur.playerHP + "My Id: " + cur.playerID +
                            "PersonofInterest: " + personofinterest, new Color(0.8f, 0.2f, 0.2f, 1));
                    }


                    if (cur.playerHP != 0 && cur.playerName != "Phone" && num1 < 100) personofinterest = cur.playerID;

           
                }
            
        }

        

    }




}

//TODO 

// Abuse packets 


// create security 
// monotize 
// watch game burn in flames like survivedby 
// collect tears. 