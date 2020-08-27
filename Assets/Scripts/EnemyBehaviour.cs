using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private Rigidbody2D enemyRb;
    private SpriteRenderer enemySprite;
    private Animator enemyAnim;
    float timeBeforeChange;
    public float delay = .5f;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed < 0)
            enemySprite.flipX = true;
        else
            enemySprite.flipX = false;
        enemyRb.velocity = Vector2.right * speed;
        if(timeBeforeChange < Time.time)
        {
            speed *= -1;
            timeBeforeChange = Time.time + delay;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (transform.position.y + 0.3f < collision.transform.position.y)
            {
                enemyAnim.SetBool("isDead", true);
            }
        }
    }

    public void DisableEnemy()
    {
        gameObject.SetActive(false);
    }

}
