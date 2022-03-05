using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Seeker : Enemy
{
    public Animator animator;
    private IAdvance<EnemiesBehaviours> currentAdvance;

    private void Start()
    {
        currentAdvance = new TargetSinuosAdvance(transform, target, 8, 0.1f);
        SetBehaviour(currentAdvance);
    }
    private void Awake()
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
        if (dropableBuff != null) Instantiate(dropableBuff, transform);
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

    public override void OnSpawn()
    {
        Debug.Log("Spawn");
    }

    public override void TerminateEntity()
    {
        Debug.Log("Die");
    }
}
