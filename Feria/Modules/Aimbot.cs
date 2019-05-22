using System;
using System.Runtime.InteropServices;
using Steamworks;
using UnityEngine;

namespace Feria
{
    internal class Aimbot : MonoBehaviour
    {
        public int CurMovSpeed = 1;

        public int CurMovSpeed111 { get; private set; }

        private Camera gCamera;
        private WeaponType gearload;
        private GamePlayerNetworked[] gPlayer;
        private short friend1=999;
        private short friend2= 999;
        private short friend3= 999;
        private short friend4= 999;
        private GameScript gScript;
        private Vector3 mousePosition;
        private string myPlayer;
        public Vector3 myPlayer2d;
        public float myplayerx;
        public float myplayery;

        public Vector3 MyVelocityx { get; private set; }

        private float previous;
        private float velocity1;
        private float previous1;
        private float ProjectileSpeed = 5;
        private Vector3 _prevPosition;
        private float velocity;
        private Vector3 interceptPoint;
        private int CurMovSpeednew;
        private int CurMovSpeedoldsimple;
        private int CurMovSpeedcurrentmethod;
        public static float yMovement;
        public static float lastyPosition;

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public void Start()
        {
            Console.WriteLine("NoClip Module Loaded");

            myPlayer = SteamFriends.GetPersonaName();
          
      //      InvokeRepeating("FetchPlayer", 1.0f,
               // 0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchCamera", 1.0f, 0.3f);
            InvokeRepeating("FetchScript", 1.0f,
                0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("CompareObjectsLive", 1.0f, 5.0f);
        }
        public void CompareObjectsLive()
        {
            if (gPlayer == null)
            {

                FetchPlayer(); // INITIAL OBJECT DOES NOT EXIST SO CREATE IT 


            }

            if (gScript == null && gPlayer != null)
            {
                Console.WriteLine("shit is hella null gscript  " + gPlayer.Length);
                Array.Clear(gPlayer, 0, 63); // CLEAR INDEX BECAUSE OUTSIDE OF GAME
                FetchPlayer();
            }
            else
            {
                Console.WriteLine(gScript.playersAliveCount);
            }

            if (gPlayer.Length < gScript.playersAliveCount)
            {
                Array.Clear(gPlayer, 0, gPlayer.Length);
                Console.WriteLine("Player length is not correct forcing fetch player method " + "Length " + gPlayer.Length + "Players Alive" + gScript.playersAliveCount);
                FetchPlayer();
            }
        }
        public void Update()
        {
            if (GuiMenu.Aimbot)
            {
                if (Input.GetKey(GuiMenu.AimKey))
                {
                    aimbot();
                   Console.WriteLine("doing aimbot");
                }
            }
        
        }

        public void FetchPlayer()
        {
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 


            friend1 = 999;
            friend2 = 999;
            friend3 = 999;
            friend4 = 999;

            friend1 = gScript.playerIDsOnLocalTeamOrdered[0];
            friend2 = gScript.playerIDsOnLocalTeamOrdered[1];
            friend3 = gScript.playerIDsOnLocalTeamOrdered[2];
            friend4 = gScript.playerIDsOnLocalTeamOrdered[3];




        }

        public void FetchCamera()
        {
            gCamera = FindObjectOfType<Camera>(); // Load Camera Class/Object into Memory
        }

        public void FetchScript()
        {
            gScript = FindObjectOfType<GameScript>(); // Load GameScript Class/Object into Memory
        }

        public void aimbot()
        {
            foreach (var p in gPlayer)
            {
                if (p.playerName == myPlayer)
                {
                    myPlayer2d = p.transform.position;
                    myplayerx = p.transform.position.x;
                    myplayery = p.transform.position.y;
                    MyVelocityx = (p.transform.position - _prevPosition) / Time.fixedDeltaTime;
                    _prevPosition = p.transform.position;
                    var mycurrentweapon = p.equipmentIDs[p.currentEquipmentIndex];
                    gearload = WeaponType.GetAllWeaponTypes()[mycurrentweapon];
                    ProjectileSpeed = gearload.bulletMoveSpeed;
                }
                mousePosition = Input.mousePosition;
                var position3 = p.transform.position;
                var target =
                    gCamera.transform.position +
                    gCamera.transform.forward; //Calculate a point facing straight away from us
                var w2s = gCamera.WorldToScreenPoint(target); //Translate position to screen
                var v = Camera.main.WorldToScreenPoint(position3);
                var DistanceToEnemy = Vector2.Distance(w2s, v);

                var vy = Screen.height - v.y - 31.0f;
                var vxx = v.x;
                var vx = v.x + p.xMovement;

                var DistanceFromMouse = Vector2.Distance(mousePosition, v);

                var xOut = Convert.ToInt32(vx);
                var yOut = Convert.ToInt32(vy);
                var currentLevel = gScript.currentLevel;
                var CollissionCheck = currentLevel.GetIsCollisionBetweenPoints((uint) myplayerx, (uint) myplayery,
                    (uint) p.transform.position.x, (uint) p.transform.position.y, CollisionType.MovementAndSight);


                if (p.playerHP != 0 && DistanceFromMouse < 250  && !CollissionCheck &&p.playerName !=myPlayer && p.playerID!= friend1 && p.playerID != friend2 && p.playerID != friend3 && p.playerID != friend4 && p.currentWalkMode != PlayerWalkMode.Downed)
                {


                    //      Console.WriteLine("targetvelocity is :dsadsa");
                    velocity = (p.transform.position.y - previous) / Time.fixedDeltaTime;
                    previous = p.transform.position.y;

              


                    if (DistanceToEnemy > 175 && ProjectileSpeed != 0)
                    {
                        
                       // CurMovSpeednew = (int) DistanceToEnemy / Convert.ToInt32(ProjectileSpeed * time_of_impact(myPlayer2d.x, myPlayer2d.y, TargetVelocity.x, TargetVelocity.y, ProjectileSpeed)) + Convert.ToInt32(p.GetCurrentMoveSpeed());
                       // CurMovSpeedoldsimple = (int) DistanceToEnemy / Convert.ToInt32(ProjectileSpeed) + Convert.ToInt32(p.GetCurrentMoveSpeed());
                      //  CurMovSpeed = (int)DistanceToEnemy / Convert.ToInt32(ProjectileSpeed * 0.42 + Convert.ToInt32(p.GetCurrentMoveSpeed()));
                      //  CurMovSpeedcurrentmethod = (int)DistanceToEnemy / Convert.ToInt32(ProjectileSpeed) + Convert.ToInt32(p.GetCurrentMoveSpeed());

                        CurMovSpeed = (int)DistanceToEnemy / (int)ProjectileSpeed + Convert.ToInt32(p.GetCurrentMoveSpeed() + (int)ProjectileSpeed / (int)DistanceToEnemy );
                        Console.WriteLine("My current prediction set : " + CurMovSpeed);
                                 //Console.WriteLine("This Method is CurMovSpeednew : " + CurMovSpeednew);
                       // Console.WriteLine("This Method is CurMovSpeed : " + CurMovSpeed);
                        //Console.WriteLine("This Method is CurMovSpeedcurrentmethod not used : " + CurMovSpeedcurrentmethod);
                    }
                    else
                    {
                        CurMovSpeed = Convert.ToInt32(p.GetCurrentMoveSpeed());
                    }
                  
        

                    if (p.xMovement > 0 && velocity < 0)
                        SetCursorPos(xOut + CurMovSpeed,
                            yOut + CurMovSpeed); //Call this when you want to set the mouse position
                    else if (p.xMovement < 0 && velocity < 0)
                        SetCursorPos(xOut - CurMovSpeed,
                            yOut + CurMovSpeed); //Call this when you want to set the mouse position
                    else if (p.xMovement > 0 && velocity > 0)
                        SetCursorPos(xOut + CurMovSpeed,
                            yOut - CurMovSpeed); //Call this when you want to set the mouse position
                    else if (p.xMovement < 0 && velocity > 0)
                        SetCursorPos(xOut - CurMovSpeed,
                            yOut - CurMovSpeed); //Call this when you want to set the mouse position
                    else if (p.xMovement > 0) // goes right 
                        SetCursorPos(xOut + CurMovSpeed, yOut); //Call this when you want to set the mouse position
                    else if (p.xMovement < 0) // goes left
                        SetCursorPos(xOut - CurMovSpeed, yOut); //Call this when you want to set the mouse position
                    else if (velocity < 0) // goes up
                        SetCursorPos(xOut, yOut + CurMovSpeed); //Call this when you want to set the mouse position
                    else if (velocity > 0) // goes down 
                        SetCursorPos(xOut, yOut - CurMovSpeed); //Call this when you want to set the mouse position
                    else
                    SetCursorPos(xOut , yOut ); //Call this when you want to set the mouse position
                }
            }
        }


        //first-order intercept using absolute target position
        public static Vector3 FirstOrderIntercept
        (
            Vector3 shooterPosition,
            Vector3 shooterVelocity,
            float shotSpeed,
            Vector3 targetPosition,
            Vector3 targetVelocity
        )
        {
            Vector3 targetRelativePosition = targetPosition - shooterPosition;
            Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
            float t = FirstOrderInterceptTime
            (
                shotSpeed,
                targetRelativePosition,
                targetRelativeVelocity
            );
            return targetPosition + t * (targetRelativeVelocity);
        }
        //first-order intercept using relative target position
        public static float FirstOrderInterceptTime
        (
            float shotSpeed,
            Vector3 targetRelativePosition,
            Vector3 targetRelativeVelocity
        )
        {
            float velocitySquared = targetRelativeVelocity.sqrMagnitude;
            if (velocitySquared < 0.001f)
                return 0f;

            float a = velocitySquared - shotSpeed * shotSpeed * 15;
            Console.WriteLine("velocity squared exxxddd: "  + velocitySquared);
            Console.WriteLine("vxxxxxxxxxsa231321ddd: " + a);
            //handle similar velocities
            if (Mathf.Abs(a) < 0.001f)
            {
                float t = -targetRelativePosition.sqrMagnitude /
                          (
                              2f * Vector3.Dot
                              (
                                  targetRelativeVelocity,
                                  targetRelativePosition
                              )
                          );
                return Mathf.Max(t, 0f); //don't shoot back in time
            }

            float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
            float c = targetRelativePosition.sqrMagnitude;
            float determinant = b * b - 4f * a * c;

            if (determinant > 0f)
            { //determinant > 0; two intercept paths (most common)
                float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
                    t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
                if (t1 > 0f)
                {
                    if (t2 > 0f)
                        return Mathf.Min(t1, t2); //both are positive
                    else
                        return t1; //only t1 is positive
                }
                else
                    return Mathf.Max(t2, 0f); //don't shoot back in time
            }
            else if (determinant < 0f) //determinant < 0; no intercept path
                return 0f;
            else //determinant = 0; one intercept path, pretty much never happens
                return Mathf.Max(-b / (2f * a), 0f); //don't shoot back in time
        }

        public static double time_of_impact(double px, double py, double vx, double vy, double s)
        {
            var a = s * s - (vx * vx + vy * vy);
            var b = px * vx + py * vy;
            var c = px * px + py * py;

            var d = b + b + (a + c);

            double t = 0;
            if (d >= 0)
            {
                t = (b + Math.Sqrt(d)) / a;
                if (t < 0)
                    t = 0;
            }

            return t;
        }
    }
}