using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HostileEntitiesManager : MonoBehaviour, IObserver<PlayerStates>
{
    [SerializeField] private EnemySetter enemySetter;
    private EnemyFactory _enemyFactory;
    public List<string> enemiesID;

    public List<Transform> spawnPoints;
    public List<Transform> goalPoints;

    [SerializeField] Player observable;

    private bool shouldInsertBuff;
    private Buff requiredBuff;
    public static HostileEntitiesManager Instance { get { return _instance; } }

    private static HostileEntitiesManager _instance;

    public List<Enemy> enemiesInScene = new List<Enemy>();

    public bool Stop
    {
        get { return _stopFactory; }
        set => _stopFactory = !_stopFactory;
    }
    private bool _stopFactory;

    private const int CONVOY_MIN = 4;
    private const int CONVOY_MAX = 8;

    #region Init
    private void Awake()
    {
        if (_instance != null && _instance != this) Destroy(gameObject);

        else _instance = this;

        _enemyFactory = new EnemyFactory(Instantiate(enemySetter));

        observable.Subscribe(this);
    }

    private void OnDestroy()
    {
        observable.Unsubscribe(this);
    }
    private void Start()
    {
        StartCoroutine(SpawnEnemyWhenIsTime());
    }

    #endregion
    public int RandomConvoyPatrolQuantity()
    {
        return Random.Range(CONVOY_MIN, CONVOY_MAX);
    }
    public IEnumerator SpawnEnemyWhenIsTime()
    {
        while (!_stopFactory)
        {
            for (int i = 0; i < RandomConvoyPatrolQuantity() ; i++)
            {
                var e = GetRandomEnemyWithIDList().SetTarget(GetRandomTransformFromList(goalPoints)).SetPosition(GetRandomTransformFromList(spawnPoints));
                if (shouldInsertBuff) e.SetBuffToDrop(requiredBuff);
                enemiesInScene.Add(e);
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(5f);
        }
    }

    public void RemoveEntityFromGlobalList(Enemy enemy)
    {
        enemiesInScene.Remove(enemy);
    }

    public Enemy GetRandomEnemyWithIDList()
    {
        var id = enemiesID.ElementAt(Random.Range(0, enemiesID.Count));

        return _enemyFactory.Create(id);
    }

    public Transform GetRandomTransformFromList(List<Transform> transforms)
    {
        return transforms.ElementAt(Random.Range(0, transforms.Count));
    }

    public void CreateEnemyWithID(string id)
    {
        _enemyFactory.Create(id);
    }

    public void ClearAllEntitesInSceneAndStopFactory()
    {
        _stopFactory = true;

        foreach (var item in enemiesInScene)
        {
            if (item != null) item.GetComponent<Enemy>().TerminateEntity();
        }

        enemiesInScene.Clear();
    }

    public void Notification(PlayerStates action)
    {
        switch (action)
        {
            case PlayerStates.Alive:
                break;
            case PlayerStates.Die:
                _stopFactory = true;
                break;
            case PlayerStates.NeedHeal:
                shouldInsertBuff = true;
                requiredBuff = BuffFactoryManager.Instance.GetBuff("Heal");
                break;
            case PlayerStates.NeedEnhancement:
                break;
            default:
                break;
        }
    }
}
