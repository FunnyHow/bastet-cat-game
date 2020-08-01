using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numberofAnkhs;
    public Image[] ankhs;
    public Sprite fullAnkh;
    public Sprite emptyAnkh;


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ankhs.Length; i++)
        {
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
