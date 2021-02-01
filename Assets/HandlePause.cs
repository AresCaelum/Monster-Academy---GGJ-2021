using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandlePause : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0.0f;
    }

    public void Unpause()
    {
        Time.timeScale = 1.0f;
    }
}
