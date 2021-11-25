using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class PatternSpawner : MonoBehaviour
{
    [SerializeField] protected float patternTimer;

    protected List<IPattern> patterns = new List<IPattern>();
    protected IPattern _currentPattern;

    
    public IEnumerator PlayCurrentPattern(IPattern pattern)
    {
        _currentPattern.Pattern();
        
        yield return new WaitForSeconds(patternTimer);

    }
    public virtual IPattern GetCurrentIPattern(){ return _currentPattern; }
    public virtual IPattern SelectRandomPattern()
    {
        IPattern randomPattern = patterns.ElementAt(Random.Range(0, patterns.Count));
        return randomPattern;
    }
    public virtual void AddIPattern(IPattern pattern){ patterns.Add(pattern); } 

}
