using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Invulnerable : Buff
{
    [SerializeField]  float timer = 1;
    public AudioSource audioSource;
    public override IEnumerator Feedback()
    {
        if (audioSource) audioSource.Play();

        yield return new WaitForEndOfFrame();
    }
    public void Update()
    {
        MoveTowardDirection(Vector3.down * Time.deltaTime * speedTowardsPlayer);
    }
    public override void OnPickUp(Collider collider)
    {
        var untargatable = collider.GetComponent<IUntargatable>();

        if (untargatable != null)
        {
            untargatable.MakeUntargateble(timer); 
            ReturnToPool();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        OnPickUp(other);
    }

    public override void TurnOn(Buff type)
    {
        type.OnReset();
        type.gameObject.SetActive(true);
    }

    public override void TurnOff(Buff type)
    {
        type.gameObject.SetActive(false);
    }

    public override void ReturnToPool()
    {
        BuffPoolManager.Instance.invulerablePool.ReturnObject(this);
    }

    public override void OnReset()
    {
        Debug.Log("Invulnerable");
    }
}
