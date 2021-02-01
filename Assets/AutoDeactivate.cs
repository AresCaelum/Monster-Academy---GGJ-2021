using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDeactivate : MonoBehaviour
{
    public float deactivateTimer = 5.0f;
    float timer = 0.0f;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > deactivateTimer)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        timer = 0.0f;
    }
}
