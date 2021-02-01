using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class FlickerEffect : MonoBehaviour
{
    public float minIntensity = 3.0f;
    public float maxIntensity = 3.2f;

    public float minRange = 5.0f;
    public float maxRange = 7.0f;

    float timeDelay = 0.05f;
    float timer = 0.0f;

    Light myLight;
    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (myLight != null)
        {
            if (timer > timeDelay)
            {
                timer -= timeDelay;
                myLight.intensity = Random.Range(minIntensity, maxIntensity);
                myLight.range = Random.Range(minRange, maxRange);
            }
        }
    }
}
