using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.LevelLogics {
    public abstract class LevelLogic : MonoBehaviour  {

        public static LevelLogic _instance;

        private void Awake() {
            _instance = this;
        }


        public abstract void CharacterInteraction(CharacterController character, Interactable interactable);

    }
}
