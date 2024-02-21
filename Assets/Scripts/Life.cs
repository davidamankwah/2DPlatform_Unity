using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    //declare variable for rigibody and animator
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSoundEffect; //refernce the audio source component

    private void Start()
    {
        //refernce the Rigiody and animator component
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    //function to check if player collide with traps
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if there is a collision with trap game object, execute code below
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die(); // call function to allow player to die
        }
    }

    //function for when player death
    private void Die()
    {
        deathSoundEffect.Play(); // death sound plays
        rb.bodyType = RigidbodyType2D.Static; //disable player movement
        anim.SetTrigger("death"); //switch to death animation
    }

    //function to restart the level 
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reload level
    }
}
