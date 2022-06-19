using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator anim;
    public float damage = 12;

    public void StartAttacking()
    {
        anim.SetBool("isAttacking", true);
    }
    


    public void Attack()
    {
        anim.SetBool("isAttacking", false);

        float randomDamage = Random.Range(damage - 5, damage + 5);
        FindObjectOfType<CharacterMovement>().GetComponent<Health>().maxHealth -= randomDamage;
    }


    public void Die()
    {
        anim.SetBool("isDead", true);
    }
}
