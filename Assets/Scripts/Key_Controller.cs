using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Controller : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.GetComponent<Player_Controller>() != null)
        {
            Player_Controller playerController = other.gameObject.GetComponent<Player_Controller>();
            playerController.PickupKey();
            Destroy(gameObject);
        }     
    }
}
