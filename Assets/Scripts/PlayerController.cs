using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;
    public float jump;
     private Rigidbody2D rb2d;
    
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

            position.x +=  horizontal * speed * Time.deltaTime;
            transform.position = position;

            //vertical movement
            
            if (vertical > 0)
            {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
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
                   
    
    }

      
}
