using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public List<Vector2Int> path;
    public Vector3 NextCellPos;
    public Interactable interaction = null;
    public Transform avatar;
    public Animator anim;
    public bool CanMove = true;

    private void Start()
    {
        NextCellPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = Vector3.MoveTowards(transform.position, NextCellPos, moveSpeed * Time.deltaTime);
        transform.position = newPosition;
        if (Mathf.Approximately(Vector3.Distance(newPosition, NextCellPos), 0.0f))
        {
            if (path.Count > 0)
            {
                NextCellPos = path[0].MakeVector3();
                path.RemoveAt(0);
                if (avatar != null)
                {
                    anim.SetBool("Walking", true);
                    Vector2Int direction = (transform.position - NextCellPos).MakeVector2Int();
                    if (direction == Vector2Int.down)
                    {
                        avatar.transform.rotation = Quaternion.Euler(0, 0, 0);
                    }
                    else if (direction == Vector2Int.up)
                    {
                        avatar.transform.rotation = Quaternion.Euler(0, 0, 180);
                    }
                    else if (direction == Vector2Int.right)
                    {
                        avatar.transform.rotation = Quaternion.Euler(0, 0, 90);
                    }
                    else if (direction == Vector2Int.left)
                    {
                        avatar.transform.rotation = Quaternion.Euler(0, 0, -90);
                    }
                }

                if (interaction != null && path.Count == 0)
                {
                    Interactable.InteractionType type = interaction.getType();
                    // should we move onto it???
                    if (type == Interactable.InteractionType.Attack || type == Interactable.InteractionType.Talk)
                    {
                        NextCellPos = transform.position;
                    }
                }
            }
            else
            {
                if (interaction != null)
                {
                    Interactable.InteractionType type = interaction.getType();
                    switch (type)
                    {
                        case Interactable.InteractionType.Switch:
                        case Interactable.InteractionType.Talk:
                            interaction.OnUse();
                            interaction = null;
                            break;
                        default:
                            CanMove = false;
                            anim.SetInteger("Interaction", (int)type);
                            break;
                    }
                }
                anim.SetBool("Walking", false);
                NextCellPos = transform.position;
            }
        }
    }

    public void TriggerInteraction()
    {
        if (interaction != null)
        {
            interaction.OnUse();
            interaction = null;
            anim.SetInteger("Interaction", 0);
            CanMove = true;
        }
    }
}
