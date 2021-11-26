using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPatterns : PatternSpawner
{
    IPattern basePattern;
    private bool _shouldRandomizeBehaviour = true;
    private bool _shouldReproducePattern = true;
    [SerializeField] private float randomizePatternValuesTimer;
    [SerializeField] private float timerBetweenSpawns;
    

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

    /// <summary>
    /// Placeholder para que el boss pueda funcionar con su IPattern, se tiene que randomizar el IPattern desde si clase base Patternspawner
    /// </summary>
    /// <returns></returns>
    public IPattern RandomizePattern()
    {
        IPattern pattern = new BasePattern().SetSpawnPoint(transform)
                                            .SetBehaviour(BulletBeahaviour.None)
                                            .SetInitialRotationInDegrees(Random.Range(0, 5))
                                            .SetAngleMultiplier((Random.Range(0, 10)))
                                            .SetProjectileQuantity(Random.Range(2, 50))
                                            .SetProjectileSpeed(Random.Range(2,3))
                                            .SetSize(Random.Range(3, 5));
                                     
        
        return pattern;
    }

    private IEnumerator ReproducePattern()
    {
        basePattern.Pattern();

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
