using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager _instance;

    public string LevelPickerSceneName;
    public string MainMenuSceneName;
    public string LevelSceneNamePrefix;

    private void Awake() {
        _instance = this;
    }

    void Start() 
    {
        
    }

    void Update()
    {
        
    }

    public void SelectPlayButton() {
        Debug.Log("Boton play seleccionado!");
    }

    public void ShowMainMenuScene() {
        SceneManager.LoadScene(MainMenuSceneName);

    }


    public void StartGame() {
        StartLevel(1);

    }

    public void StartLevel(int id) {
        SceneManager.LoadScene(LevelSceneNamePrefix+id);
    }

    public void ShowLevelsScene() {
        SceneManager.LoadScene(LevelPickerSceneName);
    }

    public void ShowGameOverScreen() {

    }

    public void ExitGame() {
        Debug.Log("Saliendo del juego!");
        Application.Quit();
    }

}