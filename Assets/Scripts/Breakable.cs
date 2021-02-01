using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Breakable : MonoBehaviour
{
    public int health = 2;
    public AudioClip hitSound;
    public AudioClip breakSound;
    public float volume = 0.3f;

    public UnityEvent onBreak;

    public void TakeHit()
    {
        health -= 1;
        if (health <= 0)
        {
            if (breakSound != null)
            {
                AudioSource.PlayClipAtPoint(breakSound, transform.position, volume);
                onBreak.Invoke();
            }
            Destroy(this.gameObject);
        }
        else
        {
            if (hitSound != null)
            {
                AudioSource.PlayClipAtPoint(hitSound, transform.position, volume);
            }
        }
    }
}
