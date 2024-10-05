using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //if collsion is with player 
        if(other.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("PLayer has finished the lvl");
            LoadNextLevel(); // we dont have a next level but this where we add new levels in order in project settings
        }
    }

    public void LoadNextLevel()
    {
        // Load the next scene based on the build index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}