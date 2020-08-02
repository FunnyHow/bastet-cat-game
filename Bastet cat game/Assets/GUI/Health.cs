using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int health;
    public int numberofAnkhs;
    public Image[] ankhs;
    public Sprite fullAnkh;
    public Sprite emptyAnkh;
    public UnityEvent onDamage;

    public void TakeDamage()
    {
        onDamage.Invoke();
        health--;
    }


    // Update is called once per frame
    void Update()
    {
        if (health > numberofAnkhs) {
            health = numberofAnkhs;
        }
        for (int i = 0; i < ankhs.Length; i++)
        {
            if (i < health)
            {
                ankhs[i].sprite = fullAnkh;
            }
            else
            {
                ankhs[i].sprite = emptyAnkh;
            }

            if (i < numberofAnkhs)
            {
                ankhs[i].enabled = true;
            }
            else { 
                ankhs[i].enabled = false;
            }
        } 
    }
}
