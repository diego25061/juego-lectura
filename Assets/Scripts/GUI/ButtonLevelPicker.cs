using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GUI {
    public class ButtonLevelPicker : MonoBehaviour {

        public int levelId;

        public void PickLevel() {
            GameManager._instance.StartLevel(levelId);
        }

    }
}
