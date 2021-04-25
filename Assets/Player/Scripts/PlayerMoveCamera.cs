using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Control Script/Player Move Camera")]
public class PlayerMoveCamera : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXandY,
        MouseX,
        MouseY
    }

    public RotationAxes axes = RotationAxes.MouseXandY;
    public float sensitivity = 9.0f;
    public float verticalRange = .0f;
    private Vector3 _rotation;

    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if(body != null)
            body.freezeRotation = true;

        _rotation = transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if(axes == RotationAxes.MouseX)
        {
            _rotation = new Vector3(_rotation.x, _rotation.y + Input.GetAxis("Mouse X") * sensitivity, _rotation.z);
        }
        else if(axes == RotationAxes.MouseY)
        {
            float rotY = _rotation.x;
            rotY = Mathf.Clamp(rotY - Input.GetAxis("Mouse Y") * sensitivity, -verticalRange, verticalRange);
            _rotation = new Vector3(rotY, _rotation.y, _rotation.z);
        }
        else
        {
            float rotY = _rotation.x;
            rotY = Mathf.Clamp(rotY - Input.GetAxis("Mouse Y") * sensitivity, -verticalRange, verticalRange);
            _rotation = new Vector3(rotY, _rotation.y + Input.GetAxis("Mouse X") * sensitivity, _rotation.z);
        }

        transform.localEulerAngles = _rotation;
        _rotation = new Vector3(_rotation.x % 360, _rotation.y % 360, _rotation.z % 360);
    }
}
