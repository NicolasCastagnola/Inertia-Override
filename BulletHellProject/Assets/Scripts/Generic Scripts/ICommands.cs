using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Up : ICommand
{
    Transform _t;
    float _s;
    public Up(Transform transform, float speed)
    {
        _t = transform;
        _s = speed;
    }

    public void Do()
    {
        _t.position += Vector3.up * _s *Time.deltaTime;
    }

    public void Undo()
    {
        _t.position -= Vector3.up;
    }
}
public class Left : ICommand
{
    Transform _t;
    float _s;

    public Left(Transform transform, float speed)
    {
        _t = transform;
        _s = speed;
    }

    public void Do()
    {
        _t.position -= Vector3.right * _s * Time.deltaTime;
    }

    public void Undo()
    {
        _t.position += Vector3.right;
    }
}
public class Right : ICommand
{
    Transform _t;
    float _s;

    public Right(Transform transform, float speed)
    {
        _t = transform ;
        _s = speed;
    }

    public void Do()
    {
        _t.position += Vector3.right * _s * Time.deltaTime;
    }

    public void Undo()
    {
        _t.position -= Vector3.right;
    }
}
public class Down : ICommand
{
    Transform _t;
    float _s;

    public Down(Transform transform, float speed)
    {
        _t = transform;
        _s = speed;
    }

    public void Do()
    {
        _t.position += Vector3.down * _s * Time.deltaTime;
    }

    public void Undo()
    {
        _t.position -= Vector3.down;
    }
}