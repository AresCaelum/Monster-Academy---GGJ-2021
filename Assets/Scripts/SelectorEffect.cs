using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SelectorEffect : MonoBehaviour
{
    public float baseScale = 0.75f;
    public float maxScaleOffset = 0.15f;
    public float scaleSpeed = 1.0f;
    float elapsedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newScale = Vector3.zero;
        elapsedTime += Time.deltaTime * scaleSpeed;

        newScale.x = newScale.z = baseScale + Mathf.Sin(elapsedTime) * maxScaleOffset;
        newScale.y = transform.localScale.y;
        transform.localScale = newScale;
    }

}
