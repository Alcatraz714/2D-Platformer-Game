using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    public GameObject LevelSelectorPopup;
    public GameObject LevelCompleteScreen;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //if collsion is with player 
        if(other.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("Player has finished the lvl");
            LevelManager.Instance.MarkCurrentLevelComplete();
            LevelCompleteScreen.SetActive(true);
        }
    }

    public void LoadNextLevel()
    {
        // Load the next scene based on the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void PlayGame()
    {
        SoundManager.Instance.PlaySound(Sounds.ButtonClick);
        LevelSelectorPopup.SetActive(true);// enable Popup
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void BacktoLobby()
    {
        SceneManager.LoadScene(0); // in load order we have 0 as the build index for the lobby
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}