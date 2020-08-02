using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerInteractions : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip hiss;
    public AudioClip meow;
    public AudioClip[] damageMeow;
  
    // Start is called before the first frame update

    private int RandomFromList()
    {
        System.Random rnd = new System.Random();
        return rnd.Next(damageMeow.Length);
    }

    public void OnDamage()
    {
        audioSource.PlayOneShot(damageMeow[RandomFromList()], 0.7f);
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // play the sound
            audioSource.PlayOneShot(hiss, 0.7f);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            // play the sound
            audioSource.PlayOneShot(meow, 0.7f);
        }
    }
}
