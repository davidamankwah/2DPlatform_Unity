using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStick : MonoBehaviour
{

  //check when player touches moving platform  
  private void OnTriggerEnter2D(Collider2D collision)
    {
        //check if the player collides 
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform); //puts player in as child of moving platform
        }
    }

    //check player leaving moving platform
    private void OnTriggerExit2D(Collider2D collision)
    {
        //check if it is the player object
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); // remove player as child of moving platform. Null value set
        }
    }
}
