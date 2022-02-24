using System;
using System.Collections;
using System.Collections.Generic;
public interface ICommand { void Do(); void Undo();}
public interface IPrototype { IPrototype Clone(); }
public interface IObserver<T> { void Notification(T action); }
public interface IObservable<T> 
{
    void Subscribe(IObserver<T> obs); 
    void Unsubscribe(IObserver<T> obs); 
    void NotifyToObservers(T action); 
}
public interface IAdvance<T> { void Advance();}

//------------------------------------------------------------------------------------------------

public interface IEntity<T> { void TakeDamage(int dmg); void TakeHeal(int heal); void TerminateEntity(); }
public interface IModel<T> { void TakeHeal(T amount); void TakeDamage(T amount); void Die(); }
public interface IPickupable<T> { void OnPickUp(T collsionType); IEnumerator Feedback(); }
public interface IDamagable { void OnDamage(int amount); void OnDeath(); }
public interface IHealeable { void OnHeal(int amount);}
public interface IWeapon { void Shoot(Bullet b); void ChangeWeapon();  }
public interface IUntargatable { void MakeUntargateble(float time); }
public interface IPattern { void PlayPattern(); }
public interface IPoolable<T> { void TurnOn(T type); void TurnOff(T type); void ReturnToPool(); void OnReset(); }
public interface IState { void OnEnter(); void OnUpdate(); void OnExit(); }
public interface IRewindable { void Action(); void SaveMementoParamerters(); void OnRewind(ParamsMemento wrappers); }




