using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class angry_enemy : Enemy
{
    Animator Animator;
    public override void Start()
    {
        Animator = GetComponent<Animator>();
        base.Start();
    }
    public override void extra_features()
    {
        GetComponentInChildren<ParticleSystem>().Play();
        Animator.SetBool("dead", true);
    }
    public override void OnMouseDown()
    {
        Animator.SetTrigger("hit");
        base.OnMouseDown();
    }
}
