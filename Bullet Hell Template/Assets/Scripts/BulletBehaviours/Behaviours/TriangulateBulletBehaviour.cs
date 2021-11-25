using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangulateBulletBehaviour : IAdvance<BulletBeahaviour>
{
    Transform _target;

    public TriangulateBulletBehaviour(Transform target)
    {
        _target = target;
    }
    
    public void Advance()
    {
        throw new System.NotImplementedException();
    }

    public void Triangulate()
    {

    }
}
