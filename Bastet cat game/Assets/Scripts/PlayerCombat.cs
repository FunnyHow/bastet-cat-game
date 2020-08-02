using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;



    // Start is called before the first frame update
    void Attack()
    {
        //play anim
        animator.SetTrigger("Attack");
        //detect enemy collsion
        Collider2D[] hitObjects= Physics2D.OverlapCircleAll(attackPoint.position, attackRange);
        // do damage

        foreach (Collider2D item in hitObjects) {
            if (item.tag == "Enemy")
            {
                Debug.Log("hit this " + item.name);
            }
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Attack();
        }    
    }
}
