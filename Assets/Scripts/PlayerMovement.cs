using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Declare variables and serialized variables
     [SerializeField] private float hSpeed = 4;
    [SerializeField] private float vSpeed = 4;
    [SerializeField] private float xBound = 9;
    [SerializeField] private float yBound = 9;
    [SerializeField] private float jumpspeed = 4;
    [SerializeField] private float runspeed = 4;
    [SerializeField] private Rigidbody2D rbb;
    [SerializeField] private LayerMask jumpGround;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AudioSource jumpSoundEffect;
    private enum StateMoves { idle, run, jump, falling }
    private StateMoves state = StateMoves.idle;
    private BoxCollider2D collison;

    private Animator ani;
    private float hInput = 4;

    
    // Start is called before the first frame update
    void Start()
    {
        //Gets references to the Rigidbody2D, BoxCollider2D, SpriteRenderer, and Animator
        rbb = GetComponent<Rigidbody2D>();
        collison = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(); //call function for moving the player's positions
        Jump(); //call function for updating the player's state to indicate that they are jumping.
    }

    private void MovePlayer()
    {
        hInput = Input.GetAxis("Horizontal"); // Get Horizontal Axis Value
        float vInput = Input.GetAxis("Vertical"); // Get Vertical Axis Value

        // Work on Offset
        float xOffset = hInput * hSpeed * Time.deltaTime;
        float yOffset = vInput * vSpeed * Time.deltaTime;

        // Get position
        float xPosition = transform.position.x + xOffset;
        float yPosition = transform.position.y + yOffset;

        // Update position
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);

        // Get position and keep in boundary
        xPosition = Mathf.Clamp(transform.position.x + xOffset, -xBound, xBound);
        yPosition = Mathf.Clamp(transform.position.y + yOffset, -yBound, yBound);

        AnimatorUpdate(); //call function for updating the player's states to jump, fall, idle and run right or left.
    }

 //checks whether the player is currently on the ground or not.
 //Return true if player is on the ground, and false otherwise
 //Box cast checks for collisions with the jumpGround layer mask.
 bool isGround()
 {
    return Physics2D.BoxCast(collison.bounds.center, collison.bounds.size, 0f, Vector2.down, .9f, jumpGround);  //.1f
 }
    
    //make a player character jump
    private void Jump()
    {
        //checks if the player is on the ground and the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space) && isGround())
        {
            jumpSoundEffect.Play();//play jump sounds

            // give the player a velocity in the y direction only - check later for double jumps
            Vector2 jumpVelToAdd = new Vector2(0f, jumpspeed);
            rbb.velocity += jumpVelToAdd;
        }
    }

     //The function updates the state of the character's animation based on the player's movement
     private void AnimatorUpdate()
    {
        StateMoves state; //stores the current animation state

      //if condition is true, the state variable is set to StateMoves.run,
      if(hInput > 0f)
        {
            state = StateMoves.run;
            sprite.flipX =false; //player's moves right
        }

       //if condition is true, the state variable is set to StateMoves.run
       else if(hInput < 0f)
        {
           state = StateMoves.run;
           sprite.flipX =true; //player's moves left
        }

        else
        {
            state = StateMoves.idle; //state variable is idle
        }

        //if condition is true, the state variable is set to StateMoves.jump
         if(rbb.velocity.y > .1f)
        {
            state = StateMoves.jump;
        }

        //if condition is true, the state variable is set to StateMoves.falling
        else if(rbb.velocity.y <  -.1f)
        {
            state = StateMoves.falling;
        }

        //Sets the animator to transition to the appropriate animation state.
        ani.SetInteger("state",(int)state);
    }
}
