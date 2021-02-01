using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods 
{
    public static Vector3 MakeVector3(this Vector2Int vector2Int, float z = 0.0f)
    {
        Vector3 result;
        result.x = vector2Int.x;
        result.y = vector2Int.y;
        result.z = z;

        return result;
    }

    public static Vector3 MakeVector3(this Vector3Int vector3Int)
    {
        Vector3 result;
        result.x = vector3Int.x;
        result.y = vector3Int.y;
        result.z = vector3Int.z;

        return result;
    }

    public static Vector2Int MakeVector2Int(this Vector2 vec)
    {
        Vector2Int result = Vector2Int.zero;
        result.x = Mathf.FloorToInt(vec.x);
        result.y = Mathf.FloorToInt(vec.y);

        return result;
    }

    public static Vector2Int MakeVector2Int(this Vector3 vec3)
    {
        Vector2Int result = Vector2Int.zero;
        result.x = Mathf.FloorToInt(vec3.x);
        result.y = Mathf.FloorToInt(vec3.y);
        return result;
    }

    public static Vector3Int MakeVector3Int(this Vector2 vec)
    {
        Vector3Int result = Vector3Int.zero;
        result.x = Mathf.FloorToInt(vec.x);
        result.y = Mathf.FloorToInt(vec.y);
        return result;
    }

    public static Vector3Int MakeVector3Int(this Vector3 vec3)
    {
        Vector3Int result = Vector3Int.zero;
        result.x = Mathf.FloorToInt(vec3.x);
        result.y = Mathf.FloorToInt(vec3.y);
        return result;
    }
}
