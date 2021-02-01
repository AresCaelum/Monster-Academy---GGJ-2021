using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    public ControllerMovement player;
    public AudioClip footSound;
    public void Interact()
    {
        if(player != null)
        {
            player.TriggerInteraction();
        }
    }

    public void PlayFootStep()
    {
        if(footSound != null)
        {
            AudioSource.PlayClipAtPoint(footSound, transform.position, 0.2f);
        }
    }
}
