using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    private Animator anim;
    int wholeNumber = 16;
    float decimalNumber = 4.56f;
    string text = "blah:";
    bool boolean = false;
    //public int maxHealth = 100;
    //public int currentHealth; 
   

	
    
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float jumpSpeed = 11f;
    [SerializeField] private float moveSpeed = 7f;

    private enum MovementState {idle, running, jumping, falling}
    
    [SerializeField] private AudioSource jumpSoundEffect;
    //public Healthbar healthBar;
    
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        //currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);

    }

    // Update is called once per frame
    private void Update()
    {
        
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        //if(Input.GetKeyDown(KeyCode.W)){
         //   TakeDamage(20);
        //}
        

        UpdateAnimationState();

    }

    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
 //           anim.SetBool("running", true);
            sprite.flipX = false;

        }
        else if (dirX < 0)
        {
            state = MovementState.running;
      //      anim.SetBool("running", false);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
            
            //anim.SetBool("running", false);
        }
        if(rb.velocity.y > 0.1f) //value small because to avoid jump animations
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }

   private bool IsGrounded()
    {
       return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
    
    

    
}


