using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatterns : PatternSpawner
{
    private List<PatternFlyweight> flyweightPointers = new List<PatternFlyweight>();
    private IPattern basePattern;
    private bool _shouldRandomizeBehaviour = true;
    private bool _shouldReproducePattern = true;
    [SerializeField] private float randomizePatternValuesTimer;
    [SerializeField] private float timerBetweenSpawns;
    public void InitializePatterns()
    {
        flyweightPointers.Add(NonStaticFlyweightPointers.Circle);
        flyweightPointers.Add(NonStaticFlyweightPointers.Circle);
    }

    private void Awake()
    {
        InitializePatterns(); 
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


    public IPattern RandomizePattern()
    {
        IPattern pattern = new BasePattern(NonStaticFlyweightPointers.LinearLockOn, transform);
                                     
        return pattern;
    }

    private IEnumerator ReproducePattern()
    {
        basePattern.PlayPattern();

        _shouldReproducePattern = false;

        yield return new WaitForSeconds(timerBetweenSpawns);


        _shouldReproducePattern = true;

    }
    private IEnumerator RandomizeBehaviour()
    {
        _shouldRandomizeBehaviour = false;
        
        basePattern = RandomizePattern();

        yield return new WaitForSeconds(randomizePatternValuesTimer);

        _shouldRandomizeBehaviour = true;
    }
}
