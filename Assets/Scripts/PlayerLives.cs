using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    private int heart = 3;
    bool hasCooldown = false;
    public Image[] hearts;
    public ChangeScene change;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
            restLife();
    }

    void restLife()
    {
        if (!hasCooldown)
        {
            if (heart > 1)
            {
                heart--;
                hearts[heart].gameObject.SetActive(false);
                hasCooldown = true;
                Debug.Log("xDDD");
                StartCoroutine(Cooldown());
            }
            else
            {
                change.changeScene("Lose");
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(.5f);
        hasCooldown = false;
        StopCoroutine(Cooldown());
    }
}
