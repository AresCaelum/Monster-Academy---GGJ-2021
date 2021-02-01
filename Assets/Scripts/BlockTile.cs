using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(PositionHolder))]
public class BlockTile : MonoBehaviour
{
    public string tileName = "Tile ";
    private void Update()
    {
        gameObject.name = tileName + transform.position.MakeVector2Int().ToString();
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            WorldMap map = FindObjectOfType<WorldMap>();
            if (map != null)
            {
                map.RemoveBlock(transform.position.MakeVector2Int());
            }
        }
    }

    private void OnEnable()
    {
        if (Application.isPlaying)
        {
            WorldMap map = FindObjectOfType<WorldMap>();
            if (map != null)
            {
                map.MakeBlock(transform.position.MakeVector2Int());
            }
        }
    }
}
