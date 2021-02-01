using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeData
{
    public bool startingNode = false;
    public Vector2Int parent = Vector2Int.zero;
}

public static class AIPathFinding
{
    public static int MaxNodesToCheck = 1000;
    public delegate bool CheckTile(Vector2Int loc);
    public static bool GetPath(Vector2Int start, Vector2Int end, out List<Vector2Int> path, CheckTile isBlocked, CheckTile isInteractable)
    {
        int nodesChecked = 0;
        Dictionary<Vector2Int, NodeData> visited = new Dictionary<Vector2Int, NodeData>();
        List<Vector2Int> nodes = new List<Vector2Int>();

        path = new List<Vector2Int>();
        nodes.Add(start);
        NodeData startingNode = new NodeData();
        startingNode.startingNode = true;
        visited.Add(start, startingNode);
        while (nodes.Count > 0)
        {
            nodesChecked++;
            if (nodesChecked >= MaxNodesToCheck)
            {
                //Stop an infinite loop...
                return false;
            }
            bool found = false;
            int index = 0;
            Vector2Int node = nodes[index];
            nodes.RemoveAt(index);

            found = AddNeighbor(node, node + Vector2Int.up, end, ref nodes, ref visited, isBlocked, isInteractable);
            found = found || AddNeighbor(node, node + Vector2Int.left, end, ref nodes, ref visited, isBlocked, isInteractable);
            found = found || AddNeighbor(node, node + Vector2Int.down, end, ref nodes, ref visited, isBlocked, isInteractable);
            found = found || AddNeighbor(node, node + Vector2Int.right, end, ref nodes, ref visited, isBlocked, isInteractable);

            if (found)
            {
                bool AtStart = false;
                Vector2Int navigationNode = end;
                path.Add(navigationNode);
                while (!AtStart)
                {
                    NodeData parent;
                    if (visited.TryGetValue(navigationNode, out parent))
                    {
                        navigationNode = parent.parent;
                        if (parent.startingNode)
                        {
                            path.Reverse();
                            return true;
                        }
                        else
                        {
                            path.Add(navigationNode);
                        }
                    }
                    else
                    {
                        path.Clear();
                        // Log error
                        return false;
                    }
                }
            }
        }
        return false;
    }

    static bool AddNeighbor(Vector2Int currentNode, Vector2Int neighbor, Vector2Int end, ref List<Vector2Int> nodes, ref Dictionary<Vector2Int, NodeData> visited, CheckTile isBlocked,
                            CheckTile isInteractable)
    {
        NodeData parent;
        if (!visited.TryGetValue(neighbor, out parent))
        {
            parent = new NodeData();
            parent.parent = currentNode;
            parent.startingNode = false;
            if (!isBlocked(neighbor))
            {
                visited.Add(neighbor, parent);
                nodes.Add(neighbor);
                if (neighbor == end)
                {
                    return true;
                }
            }
            else
            {
                if (neighbor == end)
                {
                    if (isInteractable(neighbor))
                    {
                        visited.Add(neighbor, parent);
                        nodes.Add(neighbor);
                        return true;
                    }
                }
            }
        }
        return false;
    }

}
