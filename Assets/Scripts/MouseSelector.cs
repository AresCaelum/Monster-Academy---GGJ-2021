using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseSelector : MonoBehaviour
{
    public LayerMask layerMask;
    Ray ray;
    RaycastHit hitData;
    Vector3 worldPosition;
    public ControllerMovement player;
    WorldMap map;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && player != null && player.CanMove && !IsMouseOverUI())
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitData, 1000, layerMask))
            {
                worldPosition = hitData.point + Vector3.one * 0.5f;

                if(player != null)
                {
                    player.interaction = hitData.collider.gameObject.GetComponentInChildren<Interactable>(false);
                    if (player.interaction != null)
                    {
                        transform.position = player.interaction.transform.position.MakeVector2Int().MakeVector3(transform.position.z);
                    }
                    else
                    {
                        transform.position = worldPosition.MakeVector2Int().MakeVector3(transform.position.z);
                    }

                    Vector2Int startPosition = player.NextCellPos.MakeVector2Int();
                    player.path.Clear();
                    if(map == null)
                    {
                        map = FindObjectOfType<WorldMap>();
                    }
                    // if instead of else so it can run the first time getting...
                    if(map != null)
                    {
                        AIPathFinding.GetPath(startPosition,
                                              transform.position.MakeVector2Int(),
                                              out player.path,
                                              map.IsTileBlocked, map.ShouldTryToPath);
                        if(player.path.Count == 0)
                        {
                            player.interaction = null;
                        }
                    }
                }
            }
        }
    }


    bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}