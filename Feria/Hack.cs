using UnityEngine;

namespace Feria
{
     public abstract class Hack
     {
         public Hax b;
        public bool enabled;
        public string named;
        
        public Hack(string s, Hax b)
        {
            named = s;
            this.b = b;
        }

        abstract public void Update();

     

       abstract public void OnGUI();
    


       abstract public void Start();
       

        public bool isEnabled()
        {
            return enabled;
        }

        public string name()
        {
            return named;
        }
    }
}