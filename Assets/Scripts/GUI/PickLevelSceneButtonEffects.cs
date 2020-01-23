using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickLevelSceneButtonEffects : MonoBehaviour
{

    public void GoBackButtonPressed() {
        GameManager._instance.ShowMainMenuScene();
    }

    public void StartLevel1Pressed() {
        GameManager._instance.StartLevel(1);
    }

}
