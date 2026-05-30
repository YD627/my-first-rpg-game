using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScytheWeapon : Weapon
{
    private const string ANIMATION_PARM_ISATTACK = "IsAttack";
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public override void Attack()
    {
        animator.SetTrigger(ANIMATION_PARM_ISATTACK);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == Tag.Enemy)
        {
            print("Hit Enemy: " + other.name);
        }
    }
}
