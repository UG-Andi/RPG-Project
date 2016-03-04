using UnityEngine;
using System.Collections;

public class thirdPersonCam : MonoBehaviour {

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private const float yAngleMin = 0.0f;
    private const float yAngleMax = 50.0f;

    public float distance;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 10.0f;
    private float sensitivityY = 2.0f;

    void Start()
    {
        camTransform = transform;
        cam = Camera.main;
    }

    void Update()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");

        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);

        // Zoom
        if (Input.GetAxis("Mouse ScrollWheel") > 0.0f && distance > 1f)
        {
            distance -= 0.5f;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0.0f && distance < 3)
        {
            distance += 0.5f;
        }
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
