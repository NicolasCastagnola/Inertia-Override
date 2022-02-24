using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEntity : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var hostile = other.GetComponent<IEntity<HostileEntity>>();
        if (hostile != null) hostile.TerminateEntity();

        var allied = other.GetComponent<IEntity<AlliedEntity>>();
        if (allied != null) allied.TerminateEntity();
    }
}
