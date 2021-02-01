using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float RotationSpeed = 15.0f;
    public Vector3 offset;
    public Transform FollowTransform;
    public Toggle RotationScale;
    float scale = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }
    void LateUpdate()
    {
        if (FollowTransform != null)
        {
            transform.position = FollowTransform.position + offset;
        }
        float rotation = Input.GetAxis("Horizontal");
        if(RotationScale != null)
        {
            if(RotationScale.isOn)
            {
                scale = -1.0f;
            }
            else
            {
                scale = 1.0f;
            }
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
        transform.rotation.eulerAngles.y,
        transform.rotation.eulerAngles.z - (rotation * Time.deltaTime * RotationSpeed * scale));
    }
}
