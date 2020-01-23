using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts {

    public class Interactable : MonoBehaviour {

        public float interactDistance = 3;
        public string identifier;

        /*
        public void Interact(CharacterController character) {
            Debug.Log("INTERACTING!");

            var shaker = GetComponent<ShakerEffect>();
            if (shaker != null) {
                shaker.Shake();
            }

            if (Vector2.Distance(character.transform.position, transform.position) <= interactDistance) {
                Debug.Log("PICKING APPLE!");
            }

            var charComp= character.GetComponent<Character>();
            if (charComp!=null) {
                charComp.hasApple = true;
            }
        }*/

    }
}
