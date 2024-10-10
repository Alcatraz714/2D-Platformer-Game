using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Controller : MonoBehaviour
{
    public void PlayerDied()
    {
        SoundManager.Instance.PlayMusic(Sounds.PlayerDeath);
        gameObject.SetActive(true);
    }
}
