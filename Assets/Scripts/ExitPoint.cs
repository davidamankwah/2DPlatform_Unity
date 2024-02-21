using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoint : MonoBehaviour
{
   [SerializeField] private AudioSource finishSound; // variable for the audio source component
    private bool Completedlevel = false; // a bool variable to check if level is complete

    // Start is called before the first frame update
    void Start()
    {
         finishSound = GetComponent<AudioSource>(); // reference the audio source component
    }

    //check if player collide with checkpoint
   private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        //check if player collides and level is not complete
        if (whatHitMe.gameObject.tag == "Player" && !Completedlevel)
        {
            finishSound.Play(); //play sound
            Completedlevel = true; // set bool variable to true
        
            Invoke("CompleteLevel", 1f); //call CompleteLevel() function with delay
        }
    }

    //function to load next level
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //load next level
    }
}
