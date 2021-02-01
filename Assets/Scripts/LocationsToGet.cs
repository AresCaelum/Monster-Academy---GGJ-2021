using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class LocationsToGet : MonoBehaviour
{
    public ControllerMovement player;
    void Update()
    {
        if (player != null && player.path.Count > 0)
        {
            PathShower.path = player.path;
            PathShower.updatePoints = true;
        }
    }
}
