using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecatable : MonoBehaviour
{
    private AudioSource audio;
    ParticleSystem particle;
    static int cont = 0;
    private Text collectableText;
    // Start is called before the first frame update
    void Start()
    {
        cont = 0;
        collectableText = GameObject.Find("Text").GetComponent<Text>();
        particle = GameObject.Find("CollectableParticle").GetComponent<ParticleSystem>();
        audio = GetComponentInParent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audio.Play();
            particle.transform.position = transform.position;
            particle.Play();
            gameObject.SetActive(false);
            cont++;
            collectableText.text = cont.ToString();
        }
    }
}
