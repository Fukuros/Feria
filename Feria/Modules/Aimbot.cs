using System;
using System.Runtime.InteropServices;
using Steamworks;
using UnityEngine;

namespace Feria
{
    internal class Aimbot : MonoBehaviour
    {
        public int CurMovSpeed = 1;
        private Camera gCamera;
        private WeaponType gearload;
        private GamePlayerNetworked[] gPlayer;
        private GameScript gScript;
        private Vector3 mousePosition;
        private string myPlayer;
        private float myplayerx;
        private float myplayery;
        private float previous;
        private float ProjectileSpeed;
        private float velocity;

        [DllImport("user32.dll")]
        private static extern bool SetCursorPos(int X, int Y);

        public void Start()
        {
            Console.WriteLine("Aimbot Module Loaded");

            myPlayer = SteamFriends.GetPersonaName();
          
            InvokeRepeating("FetchPlayer", 1.0f,
                0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
            InvokeRepeating("FetchCamera", 1.0f, 0.3f);
            InvokeRepeating("FetchScript", 1.0f,
                0.3f); // Calls a method on start of game - Starts after 1 second in game repeats every 15 seconds.
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.Mouse1))
            {
                aimbot();
                Console.WriteLine("doing aimbot");
            }
        }

        public void FetchPlayer()
        {
            gPlayer = FindObjectsOfType<GamePlayerNetworked>(); // Load GamePlayerNetworked Class/Object into 
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
                    myplayerx = p.transform.position.x;
                    myplayery = p.transform.position.y;

                    var mycurrentweapon = p.equipmentIDs[p.currentEquipmentIndex];
                    gearload = WeaponType.GetAllWeaponTypes()[mycurrentweapon];
                    Console.WriteLine(gearload.GetWeaponName() + ProjectileSpeed);
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

                var vy = Screen.height - v.y - 30f;
                var vxx = v.x;
                var vx = v.x + p.xMovement;

                var DistanceFromMouse = Vector2.Distance(mousePosition, v);

                var xOut = Convert.ToInt32(vx);
                var yOut = Convert.ToInt32(vy);
                var currentLevel = gScript.currentLevel;
                var CollissionCheck = currentLevel.GetIsCollisionBetweenPoints((uint) myplayerx, (uint) myplayery,
                    (uint) p.transform.position.x, (uint) p.transform.position.y, CollisionType.MovementAndSight);


                if (p.playerHP != 0 && DistanceFromMouse < 250 && p.playerName != myPlayer && !CollissionCheck)
                {
                    velocity = (p.transform.position.y - previous) / Time.deltaTime;
                    previous = p.transform.position.y;


                    if (DistanceToEnemy > 125 && ProjectileSpeed != 0)
                        CurMovSpeed = (int) DistanceToEnemy / (int) ProjectileSpeed +
                                      Convert.ToInt32(p.GetCurrentMoveSpeed() + time_of_impact(p.xMovement, velocity,
                                                          p.xMovement, velocity, ProjectileSpeed) * 2);
                    else
                        CurMovSpeed = Convert.ToInt32(p.GetCurrentMoveSpeed());


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
                        SetCursorPos(xOut, yOut); //Call this when you want to set the mouse position
                }
            }
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