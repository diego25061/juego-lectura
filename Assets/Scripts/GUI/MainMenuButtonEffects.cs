using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonEffects : MonoBehaviour
{

    public void SelectLevelsButtonPressed() {
        GameManager._instance.ShowLevelsScene();
    }

    public void ExitButtonPressed() {
        GameManager._instance.ExitGame();
    }

    public void StartButtonPressed() {
        GameManager._instance.StartGame();
    }
}
