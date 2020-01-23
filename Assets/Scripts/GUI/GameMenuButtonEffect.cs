using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GUI {
    public class GameMenuButtonEffect : MonoBehaviour {
        public void ContinueButtonPressed() {
            GameManager._instance.ShowMainMenuScene();
        }
    }
}
