using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BuffSpawner : MonoBehaviour, IObserver<PlayerStates>
{
    [SerializeField] Player observable;
    [SerializeField] List<Transform> spawnPoints;

    public bool Stop
    {
        get { return _stopSpawner; }
        set => _stopSpawner = !_stopSpawner;
    }
    private bool _stopSpawner;

    private void Awake()
    {
        observable.Subscribe(this);
    }
    private void Start()
    {
        StartCoroutine(SpawnInvincibleInTime());
    }

    private void OnDestroy()
    {
        observable.Unsubscribe(this);
    }
    public IEnumerator SpawnHealUnitilHalt()
    {
        while (!_stopSpawner)
        {
            var e = BuffPoolManager.Instance.healPool.GetObject();

            e.transform.position = GetRandomSpawnPointFromTransformList().position;

            yield return new WaitForSeconds(20f);
        }
    }

    public IEnumerator SpawnInvincibleInTime()
    {
        yield return new WaitForSeconds(60f);

        while (true)
        {
            var e = BuffPoolManager.Instance.invulerablePool.GetObject();

            e.transform.position = GetRandomSpawnPointFromTransformList().position;

            yield return new WaitForSeconds(Random.Range(60, 90));
        }
    }

    public Transform GetRandomSpawnPointFromTransformList()
    {
        return spawnPoints.ElementAt(Random.Range(0, spawnPoints.Count));
    }
    public void Notification(PlayerStates action)
    {
        switch (action)
        {
            case PlayerStates.NeedHeal:
                _stopSpawner = false;
                StartCoroutine(SpawnHealUnitilHalt());
                break;

            case PlayerStates.PlayerHealed:
                _stopSpawner = true;
                StopCoroutine(SpawnHealUnitilHalt());
                break;
        }
    }


}
