using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    [SerializeField]
    private Rigidbody2D rb2d;
    public bool isCrouching;
    public bool isGrounded = false;
    public float jumpSpeed;
    private void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    // Start is called before the first frame update
    // void Start()
    // {
         // }
        void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
      
         MoveCharacter(horizontal,vertical);
         PlayerMovementAnimation(horizontal, vertical);
                     
    }
    private void MoveCharacter(float horizontal, float vertical)
        {
            //horizontal movement
            Vector3 position = transform.position;
            
                            // Speed = d/t(in sec) * (1(sec)/ 30 or whatever fps) 

            position.x +=  horizontal * speed * Time.deltaTime;                                 // p = p + s * t
            transform.position = position;

            //vertical movement
            
            if (vertical > 0 && isGrounded==true)
            {
             rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
            }
    
    }


    private void PlayerMovementAnimation(float horizontal, float vertical)
    {
     
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        Vector3 scale = transform.localScale;
        if(horizontal < 0)
        {
           scale.x = -1f * Mathf.Abs(scale.x);
        }
       
        else if(horizontal > 0)
        {
           scale.x = Mathf.Abs(scale.x);
        }
       
        transform.localScale = scale;

        //jump
       
       if (vertical > 0 )
       {
          animator.SetTrigger("Jump");
       }

        // crouch
         if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Crouch", true);
            isCrouching = true;
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("Crouch", false);
            isCrouching = false;
        }


    }

      
}
