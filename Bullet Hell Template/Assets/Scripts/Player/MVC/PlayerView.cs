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

        switch (lives)
        {
            case 0:
                _lives[0].color = Color.black;
                _lives[1].color = Color.black;
                _lives[2].color = Color.black;
                break;

            case 1:
                _lives[0].color = Color.white;
                _lives[1].color = Color.black;
                _lives[2].color = Color.black;
                break;

            case 2:
                _lives[0].color = Color.white;
                _lives[1].color = Color.white;
                _lives[2].color = Color.black;
                break;

            case 3:
                _lives[0].color = Color.white;
                _lives[1].color = Color.white;
                _lives[2].color = Color.white;
                break;
        }
    }

}
