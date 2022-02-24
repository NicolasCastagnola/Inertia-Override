using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyView : BaseEntityView
{
    private Animator _animator;
    private Image[] _lives;

    public EnemyView(Animator animator, Image[] images)
    {
        _animator = animator;
        _lives = images;
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

    public void RefreshLivesUI(int healthDisplayNumber)
    {
        for (int i = 0; i < _lives.Length; i++)
        {
            _lives[i].color = Color.black;

            for (int j = 0; j < healthDisplayNumber; j++)
            {
                _lives[j].color = Color.red;
            }
        }
    }

}
