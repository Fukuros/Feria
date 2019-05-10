using System;
using UnityEngine;

namespace Feria
{
    abstract class Hack : MonoBehaviour
    {
		public bool enabled;
		public string name;
		
		// constructor sets its name
		public Hack(string s) {
			name = s;
		}
		
		public bool isEnabled() {
			return enabled;
		}
		
		public string name() {
			return name;
		}

    }
}