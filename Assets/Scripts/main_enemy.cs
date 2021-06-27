using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_enemy : Enemy
{
    public override void extra_features()
    {
        GetComponentInChildren<ParticleSystem>().Play();
    }
}
