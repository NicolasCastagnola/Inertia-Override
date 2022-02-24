using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : Enemy
{
    public Animator animator;
    private IAdvance<EnemiesBehaviours> currentAdvance;
    private void Start()
    {
        currentAdvance = new TargetAdvance(transform, target, defaultSpeed);
        SetBehaviour(currentAdvance);
    }
    private void OnEnable()
    {
        InitializeEntity(animator, minHealth, maxHealth, maxSpeed, defaultSpeed);
    }
    private void OnDisable()
    {
        ResetAllBuilders();
    }
    private void Update()
    {
        OnUpdate();
    }
    public override void Die()
    {
        HostileEntitiesManager.Instance.RemoveEntityFromGlobalList(this);

        TerminateEntity();
    }
    public override void ResetAllBuilders()
    {
    }

    public override void OnRewind(ParamsMemento wrappers)
    {
        throw new System.NotImplementedException();
    }

    public override void SaveMementoParamerters()
    {
        throw new System.NotImplementedException();
    }

    public override void TerminateEntity()
    {
        throw new System.NotImplementedException();
    }

    public override void OnSpawn()
    {
        throw new System.NotImplementedException();
    }
}
