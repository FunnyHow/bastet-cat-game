using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage) {
        currentHealth -= damage;

        //play hurt anim
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() {
        Debug.Log("Aieeee!");
        // play death anim
        animator.SetBool("IsDead", true);

        //disable
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

}
