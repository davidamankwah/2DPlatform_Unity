using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField] private Transform player; //reference to player

    // Update is called once per frame
    void Update()
    {
      //sets the position of the camera to the position of the player
      //transform.position.z keeps value of camera
        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
}
