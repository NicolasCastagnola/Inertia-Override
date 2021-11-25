using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyView : BaseEntityView
{
    private Animator _animator;

    public EnemyView(Animator animator)
    {
        _animator = animator;
    }

    public override void PlayAnimationWithName(string animation)
    {
        _animator.Play(animation);
    }

    internal void PlayDeath()
    {
        PlayAnimationWithName("Die");
    }

    internal void PlayHeal()
    {
        PlayAnimationWithName("Heal");
    }

    internal void PlayDamage()
    {
        PlayAnimationWithName("Damage");
    }
}
