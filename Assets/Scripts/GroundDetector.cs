using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    PlayerController PlyrCntrlr;

    // Start is called before the first frame update

    GameObject Player;

    void Start()
    {
        Player = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                Player.GetComponent<PlayerController>().isGrounded = true;

            }
        }
        void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
            {
                Player.GetComponent<PlayerController>().isGrounded = false;

            }
        }
    }
}
