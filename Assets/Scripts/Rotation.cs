using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
     [SerializeField] private float speed = 2f; //varaible for rotation speed

    // Update is called once per frame
    private void Update()
    {
        //The number of times to rotate in x, y and z. 
        //Rotate 360 multply by speed per second
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
