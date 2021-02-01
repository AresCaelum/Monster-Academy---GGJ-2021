using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class WorldMap : MonoBehaviour
{
    public List<Vector2Int> blockedTiles; // I know its slow but we can optimize later
    public List<Vector2Int> interactableTile; // I know its slow but we can optimize later
    public Color blockedTilesColor = Color.black;
    public Color interactableColor = Color.blue;

    public float blockedTileScale = 1.0f;
    public bool GetAllBlockedTile = false;

    private void Update()
    {
        if(GetAllBlockedTile)
        {
            GetAllBlockedTile = false;
            blockedTiles.Clear();
            BlockTile[] blocked = FindObjectsOfType<BlockTile>();
            foreach(BlockTile b in blocked)
            {
                blockedTiles.Add(b.transform.position.MakeVector2Int());
            }
        }
    }
    public bool IsTileInteractable(Vector2Int tile)
    {
        return interactableTile.Contains(tile);
    }

    public bool MakeInteractable(Vector2Int loc)
    {
        if (interactableTile.Contains(loc))
        {
            return false;
        }
        else
        {
            interactableTile.Add(loc);
            return true;
        }
    }

    public void RemoveInteractable(Vector2Int loc)
    {
        interactableTile.Remove(loc);
    }

    public bool IsTileBlocked(Vector2Int tile)
    {
        return blockedTiles.Contains(tile);
    }

    public bool MakeBlock(Vector2Int loc)
    {
        if(blockedTiles.Contains(loc))
        {
            return false;
        }
        else
        {
            blockedTiles.Add(loc);
            return true;
        }
    }

    public void RemoveBlock(Vector2Int loc)
    {
        blockedTiles.Remove(loc);
    }

    public bool ShouldTryToPath(Vector2Int loc)
    {
        return !IsTileBlocked(loc) || IsTileInteractable(loc);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = blockedTilesColor;
        Vector2Int[] tiles = new Vector2Int[blockedTiles.Count];

        // Prevent an issue when looping through...
        blockedTiles.CopyTo(tiles);
        foreach(Vector2Int v in tiles)
        {
            Gizmos.DrawCube(v.MakeVector3(), Vector3.one * blockedTileScale);
        }

        tiles = new Vector2Int[blockedTiles.Count];

        Gizmos.color = interactableColor;

        // Prevent an issue when looping through...
        interactableTile.CopyTo(tiles);
        foreach (Vector2Int v in tiles)
        {
            Gizmos.DrawCube(v.MakeVector3(), Vector3.one * blockedTileScale);
        }
    }
}
