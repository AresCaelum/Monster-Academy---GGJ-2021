using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteAlways]
[RequireComponent(typeof(LineRenderer))]
public class PathShower : MonoBehaviour
{
    LineRenderer line;
    public static List<Vector2Int> path = new List<Vector2Int>();
    public static bool updatePoints = false;
    private void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (updatePoints)
        {
            updatePoints = false;
            line.positionCount = 0;
            UpdatePath();
        }
    }

    public void UpdatePath()
    {
        List<Vector3> points = new List<Vector3>();
        foreach (Vector2Int v in path)
        {
            Vector3 point = v.MakeVector3();
            point.z = transform.position.z;
            points.Add(point);
        }
        line.positionCount = points.Count;
        if (points.Count > 0)
        {
            line.SetPositions(points.ToArray());
        }
    }
}
