using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossPatterns : PatternSpawner
{
    private List<PatternFlyweight> flyweightPointers = new List<PatternFlyweight>();
    private IPattern currentPattern;
    private bool _shouldRandomizeBehaviour = true;
    private bool _shouldReproducePattern = true;

    [SerializeField] private float randomizePatternValuesTimer;
    [SerializeField] private float timerBetweenSpawns;
    public void InitializePatterns()
    {
        flyweightPointers.Add(NonStaticFlyweightPointers.Circle);
        flyweightPointers.Add(NonStaticFlyweightPointers.CircleSpiral);
        flyweightPointers.Add(NonStaticFlyweightPointers.Spiral);
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


    public IPattern GetRandomPattern() 
    {
        IPattern pattern = new BasePattern(flyweightPointers.ElementAt(Random.Range(0, flyweightPointers.Count)), transform);
                                     
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
