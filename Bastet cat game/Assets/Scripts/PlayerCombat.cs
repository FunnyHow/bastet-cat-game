using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Attack()
    {
        //play anim
        animator.SetTrigger("Attack");
        //detect enemy collsion
        // do damage
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) {
            Attack();
        }    
    }
}
