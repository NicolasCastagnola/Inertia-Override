using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossPatterns : PatternSpawner
{
    public static LookUpTable<int, float> sinLookAtTable;
    public static LookUpTable<int, float> cosLookAtTable;

    public Transform target;
    private List<PatternFlyweight> flyweightPointers = new List<PatternFlyweight>();
    private IPattern currentPattern;
    private bool _shouldRandomizeBehaviour = true;
    private bool _shouldReproducePattern = true;

    [SerializeField] private float randomizePatternValuesTimer;
    [SerializeField] private float timerBetweenSpawns;

    private bool shouldInsertBuff = true; 
    public void InitializePatterns()
    {
        //flyweightPointers.Add(NonStaticFlyweightPointers.LinearHoming);
        flyweightPointers.Add(NonStaticFlyweightPointers.Circle);
        flyweightPointers.Add(NonStaticFlyweightPointers.CircleSpiral);
        flyweightPointers.Add(NonStaticFlyweightPointers.Spiral);
        flyweightPointers.Add(NonStaticFlyweightPointers.Spiral30);
    }

    private void Awake()
    {
        InitializePatterns(); 

        sinLookAtTable = new LookUpTable<int, float>(CalculateX);
        cosLookAtTable = new LookUpTable<int, float>(CalculateY);

        EventManager.Subscribe(EventType.Deafeat, TurnOffFactory);
        EventManager.Subscribe(EventType.OnCheckpointLoaded, TurnOnFactory);
    }

    private void OnDisable()
    {
        EventManager.UnSubscribe(EventType.Deafeat, TurnOffFactory);
        EventManager.UnSubscribe(EventType.OnCheckpointLoaded, TurnOnFactory);
    }

    private void TurnOffFactory(params object[] parameters)
    {
        _shouldRandomizeBehaviour = false;
        _shouldReproducePattern = false;
        StopAllCoroutines();
    }

    private void TurnOnFactory(params object[] parameters)
    {
        _shouldRandomizeBehaviour = true;
        _shouldReproducePattern = true;
    }
    public float CalculateX(int value)
    {
        var c = Mathf.Sin((value * Mathf.PI) / 180);

        return c;
    }

    public float CalculateY(int value)
    {
        var c = Mathf.Cos((value * Mathf.PI) / 180);

        return c;
    }
    private void Update()
    {
        if (_shouldRandomizeBehaviour)
        {
            StartCoroutine(RandomizeBehaviour());
        }
        else
        {
            if (_shouldReproducePattern)
            {
                StartCoroutine(ReproducePattern());
            }
        }
    }
    public IPattern GetRandomPattern() 
    {
        IPattern pattern = new BasePattern(flyweightPointers.ElementAt(Random.Range(0, flyweightPointers.Count)), transform, target);
                                     
        return pattern;
    }
    private IEnumerator ReproducePattern()
    {
        currentPattern.PlayPattern();

        _shouldReproducePattern = false;

        yield return new WaitForSeconds(timerBetweenSpawns);


        _shouldReproducePattern = true;

    }
    private IEnumerator RandomizeBehaviour()
    {
        _shouldRandomizeBehaviour = false;
        
        currentPattern = GetRandomPattern();

        yield return new WaitForSeconds(randomizePatternValuesTimer);

        _shouldRandomizeBehaviour = true;
    }
}
