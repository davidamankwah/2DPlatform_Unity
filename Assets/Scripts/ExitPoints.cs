using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPoints : MonoBehaviour
{
   [SerializeField] private AudioSource finishSound;
    private bool CompleteLevel = false;
    // Start is called before the first frame update
    void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

     void CompletedLevel()
   {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }

   private void OnTriggerEnter2D(Collider2D whatHitMe)
   {
     if(whatHitMe.gameObject.tag == "Player" && !CompleteLevel)
     {
        finishSound.Play();
        CompleteLevel = true;
        Invoke("CompletedLevel",1f);
     }
   }
}

