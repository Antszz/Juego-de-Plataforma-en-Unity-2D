using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    private AudioSource audio;
    private bool isGrounded;
    private Animator playerAnim;

    public float speed;
    public float speedJump;
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        rbPlayer = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        rbPlayer.velocity = new Vector2(Input.GetAxis("Horizontal")*speed,rbPlayer.velocity.y);

        if (isGrounded )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rbPlayer.AddForce(Vector2.up * speedJump);
                isGrounded = false;
                playerAnim.SetTrigger("isJump");
                audio.Play();
            }
        }

        //Animation
        float axis= Input.GetAxis("Horizontal");
        if(axis == 0)
        {
            playerAnim.SetBool("isWalking", false);
        }
        else
        {
            if (axis < 0)
                GetComponent<SpriteRenderer>().flipX = true;
            else
                GetComponent<SpriteRenderer>().flipX = false;
            playerAnim.SetBool("isWalking", true);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }

}
