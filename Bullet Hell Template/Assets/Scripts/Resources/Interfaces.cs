using System;
using System.Collections;
using System.Collections.Generic;
public interface ICommand { void Do(); void Undo();}
public interface IPrototype { IPrototype Clone(); }
public interface IObserver<Type> { void Notification(Type action); }
public interface IObservable<T> 
{
    void Subscribe(IObserver<T> obs); 
    void Unsubscribe(IObserver<T> obs); 
    void NotifyToObservers(T action); 
}
public interface IAdvance<T> { void Advance();}

//------------------------------------------------------------------------------------------------

public interface IEntity<T> { void TakeDamage(int dmg); void TakeHeal(int heal);}
public interface IModel<T> { void TakeHeal(T amount); void TakeDamage(T amount); void Die(); }
public interface IConsumable<P,T> { void OnConsume(P param, T type); }
public interface IDamagable<T> { void OnDamage(T amount);}
public interface IHealeable<T> { void OnHeal(T amount);}
public interface IPattern { void Pattern();}
public interface IPoolable<T> { void TurnOn(T type); void TurnOff(T type); void ReturnToPool(); void OnReset(); }
public interface IState { void OnEnter(); void OnUpdate(); void OnExit(); }


