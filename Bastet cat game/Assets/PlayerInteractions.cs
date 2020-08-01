using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip hiss;
    public AudioClip meow;
    // Start is called before the first frame update
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
