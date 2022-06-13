using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float translationSpeed = 5.0f;
    public float rotationalSpeed = 10f;
    public GameObject playerCamera;

    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f; // rotation around the up/y axis
    private float rotX = 0.0f; // rotation around the right/x axis

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = playerCamera.transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(playerCamera.transform.forward * v * Time.deltaTime * translationSpeed, Space.World);
        transform.Translate(playerCamera.transform.right * h * Time.deltaTime * translationSpeed, Space.World);
        MouseLook();
    }

    void MouseLook()
    {
        if (!UnityEngine.XR.XRSettings.enabled)
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = -Input.GetAxis("Mouse Y");

            rotY += mouseX * mouseSensitivity * Time.deltaTime;
            rotX += mouseY * mouseSensitivity * Time.deltaTime;

            rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

            Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
            playerCamera.transform.rotation = localRotation;
        }
    }
}