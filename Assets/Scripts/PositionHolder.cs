using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class PositionHolder : MonoBehaviour
{
    public bool destroyOnStart = true;
    private void Start()
    {
        if(Application.isPlaying && destroyOnStart)
        {
            Destroy(this);
        }
    }
    void Update()
    {
        transform.position = new Vector3(Mathf.FloorToInt(transform.position.x),
        Mathf.FloorToInt(transform.position.y),
        transform.position.z);
    }
}
