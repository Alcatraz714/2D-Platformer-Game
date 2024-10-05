using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_Controller : MonoBehaviour
{
    public void PlayerDied()
    {
        gameObject.SetActive(true);
    }
}
