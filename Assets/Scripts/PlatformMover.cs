using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class PlatformMover : MonoBehaviour
{
    public enum FollowType
    {
        MoveTowards,
        Lerp
    }

    [SerializeField]
    private float speed = 1;

    public FollowType type = FollowType.MoveTowards;
    public PlatformPath path;
    public float maxDistanceToGoal = 0.1f;

    private IEnumerator<Transform> _currentPoint;

    public void Start()
    {
        if (path == null)
        {
            Debug.LogError("Path cannot be null ", gameObject);
            return;
        }

        _currentPoint = path.GetPathsEnumerator();
        _currentPoint.MoveNext();

        if (_currentPoint.Current == null)
        {
            return;
        }

        transform.position = _currentPoint.Current.position;
    }
        
    public void Update()
    {
        if (_currentPoint == null || _currentPoint.Current == null)
        {
            return;
        }

        if (type == FollowType.MoveTowards)
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }
        else if (type == FollowType.Lerp)
        {
            transform.position = Vector3.Lerp(transform.position, _currentPoint.Current.position, Time.deltaTime * speed);
        }

        var distanceSquared = (transform.position -
        _currentPoint.Current.position).sqrMagnitude; if (distanceSquared <
        maxDistanceToGoal * maxDistanceToGoal)
        {
            _currentPoint.MoveNext();
        }
    }   
}