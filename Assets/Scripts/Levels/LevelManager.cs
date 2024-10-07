using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance {get {return instance;}}
    public string[] Levels;

    private void Awake() 
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // pass this instance
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() 
    {
        if(GetLevelStatus(Levels[0]) == LevelStatus.Locked)
        {
            SetLevelStatus(Levels[0], LevelStatus.Unlocked);
        }
    }

    public void MarkCurrentLevelComplete()
    {
        // Mark current as complete
        Scene Currentscene = SceneManager.GetActiveScene();
        SetLevelStatus(Currentscene.name, LevelStatus.Completed); // rather than loading next level we just unlock it

        /* Unlock the next level
        int nextSceneIndex = Currentscene.buildIndex + 1;
        Scene Nextscene = SceneManager.GetSceneByBuildIndex(nextSceneIndex);
        SetLevelStatus(Nextscene.name, LevelStatus.Unlocked); // we unlock the next scene in order in build settings */

        // Unlock next level new method
        int currentSceneIndex = Array.FindIndex(Levels, level => level == Currentscene.name);
        int nextSceneIndex = currentSceneIndex +1;
        if(nextSceneIndex < Levels.Length)
        {
            SetLevelStatus(Levels[nextSceneIndex], LevelStatus.Unlocked);
        }
    }

    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus) PlayerPrefs.GetInt(level, 0);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus); // we save the level and status enum which have defined values in integer 0,1,2
        Debug.Log("Setting level: "+ level + "status: "+ levelStatus);
    }
}
