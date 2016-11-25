using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Linq;

public class PlatformPath : MonoBehaviour
{
    public Transform[] pathPoints;

    public IEnumerator<Transform> GetPathsEnumerator()
    {
        if (pathPoints.Length < 1)
        {
            yield break;
        }

        var direction = 1;
        var index = 0;
        while (true)
        {
            yield return pathPoints[index];

            if (pathPoints.Length == 1)
            {
                continue;
            }

            if (index <= 0)
            {
                direction = 1;
            }
            else if (index >= pathPoints.Length - 1)
            {
                direction = -1;
            }

            index = index + direction;
        }
    }

    public void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Length < 2)
        {
            return;
        }

        var drawPoints = pathPoints.Where(t => t != null).ToList();
        if(drawPoints.Count < 2)
        {
            return;
        }

        for (var i = 1; i < drawPoints.Count; i++)
        {
            Gizmos.DrawLine(drawPoints[i - 1].position, drawPoints[i].position);
        }
    }
}
