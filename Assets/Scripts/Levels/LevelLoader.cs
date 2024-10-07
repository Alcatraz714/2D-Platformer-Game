using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))] // we want a button to have this script
public class LevelLoader : MonoBehaviour
{
    public string LevelName;

    public void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch(levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level is locked please complete the level prior to this one");
                break;

            case LevelStatus.Unlocked:
            SceneManager.LoadScene(LevelName);
            break;

            case LevelStatus.Completed:
            SceneManager.LoadScene(LevelName);
            break;

            default:
            Debug.Log("IDK");
            break;
        }
        //SceneManager.LoadScene(LevelName);
    }
}
