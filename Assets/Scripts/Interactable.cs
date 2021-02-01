using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public string Description = "";
    public enum InteractionType{
        Switch,
        Attack,
        PickUp,
        Talk,
    }
    public delegate void Interaction();
    public UnityEvent interactions;
    [SerializeField]
    public InteractionType type;
    public void OnUse()
    {
        interactions.Invoke();
    }

    public InteractionType getType()
    {
        return type;
    }

    private void OnDisable()
    {
        if (Application.isPlaying)
        {
            WorldMap map = FindObjectOfType<WorldMap>();
            if (map != null)
            {
                map.RemoveInteractable(transform.position.MakeVector2Int());
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
                map.MakeInteractable(transform.position.MakeVector2Int());
            }
        }
    }
}
