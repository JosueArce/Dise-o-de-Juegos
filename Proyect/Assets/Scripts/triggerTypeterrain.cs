using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class triggerTypeterrain : MonoBehaviour
{
        public static bool entroGrass = true;

        void OnTriggerEnter()
        {
            entroGrass = false;
        }
        void OnTriggerExit()
        {
            entroGrass = true;
        }
    }

