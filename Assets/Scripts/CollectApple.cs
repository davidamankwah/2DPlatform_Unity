using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectApple : MonoBehaviour
{
    private int apples = 0; //counts for collect items
    [SerializeField] private Text countTexts; //refernce to score text

    [SerializeField] private AudioSource collectionSoundEffect; //reference to the music for collect items

    //function checks for collison with collect items
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if collison with apples gameobject, execute the code below 
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectionSoundEffect.Play(); //collect items sound effect
            Destroy(collision.gameObject); //remove the collect items
            apples++; //increment counter
            countTexts.text = "Apples: " + apples; //updates the score text with number of collect items incremented
            //Debug.Log("Apples: " + apples);
        }

    }
}
