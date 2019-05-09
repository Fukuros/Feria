using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using UnityEngine;

namespace Feria
{
    class NoReload : MonoBehaviour
    {

        public void Start()
        {
            Console.WriteLine("No Reload Module Loaded");
        }

        public void Update()
        {
             if (Menu.NoReload)
            {
               var objectsloaded = new GetObjectsNew();

                   objectsloaded.gController.reloadFinishTime = 0;
                   Console.WriteLine("Adjusted Reload Time");
            }
        }

        public void OnGui()
        {

        }
    }
}
