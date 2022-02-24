using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class BaseFSM<T> 
{
    IState _currentState = new BlankState();

    Dictionary<T, IState> _statesDictionary = new Dictionary<T, IState>();

    public void UpdateState()
    {
        if (_currentState != null) _currentState.OnUpdate();
    }

    public void ChangeState(T state)
    {
        if (!_statesDictionary.ContainsKey(state)) return;

        _currentState?.OnExit();
        _currentState = _statesDictionary[state];
        _currentState?.OnEnter();

    }

    public void AddState(T id, IState state)
    {
        if (_statesDictionary.ContainsKey(id)) return;

        _statesDictionary.Add(id, state);
    }

    public void RemoveState(T id)
    {
        if (_statesDictionary.ContainsKey(id))
            _statesDictionary.Remove(id);
    }
}

public class BlankState : IState
{
    public void OnEnter(){}
    public void OnExit(){}
    public void OnUpdate(){}
}


