using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Boss : Enemy
{
    [SerializeField] private float changeStateTimer;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Animator animator;

    private List<IAdvance<EnemiesBehaviours>> advances = new List<IAdvance<EnemiesBehaviours>>();

    private bool _sholudRandomizeBehaviour = true;
    private void AddBehaviours()
    {
        //REMPLAZAR POR FSM / Random States
        IAdvance<EnemiesBehaviours> targetAdvance = new RandomAdvanceInsideColliderBounds(transform, defaultSpeed, boxCollider);
        advances.Add(targetAdvance);
        IAdvance<EnemiesBehaviours> idle = new Idle();
        advances.Add(idle);
    }

    private void Awake()
    {
        AddBehaviours();
    }

    private void OnEnable()
    {
        Flyweight Boss = FlyweightPointer.Boss;

        InitializeEntity(animator, Boss.minHealth, Boss.maxHealth, Boss.maxSpeed, Boss.defaultSpeed);
    }

    private void Update()
    {
        OnUpdate();

        if (_sholudRandomizeBehaviour)
        {
            SetBehaviour(advances.ElementAt(UnityEngine.Random.Range(0, advances.Count)));
            StartCoroutine(WaitToChangeBehaviourAgain());
        }
    }

    private IEnumerator WaitToChangeBehaviourAgain()
    {
        _sholudRandomizeBehaviour = false;

        yield return new WaitForSeconds(changeStateTimer);

        _sholudRandomizeBehaviour = true;
    }
    
    public override void ResetAllBuilders()
    {
        throw new NotImplementedException();
    }

    public override void Die()
    {
        EventManager.TriggerEvent(EventType.SaveData);
    }
}
