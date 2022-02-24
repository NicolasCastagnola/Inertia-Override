using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : BaseEntityView
{
    private Animator _animator;
    private Image[] _lives;
    public PlayerView(Animator animator, Image[] lives)
    {
        _animator = animator;
        _lives = lives;
    }

    public override void PlayAnimationWithName(string animation)
    {
        _animator.Play(animation);
    }
    public void PlayDeath()
    {
        PlayAnimationWithName("Death");
    }
    public void PlayHeal()
    {
        PlayAnimationWithName("Heal");
    }
    public void PlayDamage()
    {
        PlayAnimationWithName("Damage");
    }
    public void LivesDisplay(int lives)
    {
        for (int i = 0; i < _lives.Length; i++)
        {
            _lives[i].color = Color.black;

            for (int j = 0; j < lives; j++)
            {
                _lives[j].color = Color.white;
            }
        }
    }
}
