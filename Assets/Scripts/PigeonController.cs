using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonController : MonoBehaviour
{
    public float speed = 15.0f;
    public float tiltAngle = 15.0f;
    private float originalHeight = 60;

    void Start()
    {
        originalHeight = transform.position.y;
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Handle horizontal and vertical movements
        Vector3 movementHorizontal = new Vector3(0.0f, 0.0f, moveHorizontal);
        Vector3 movementVertical = new Vector3(0.0f, moveVertical, 0.0f);
        transform.Translate((movementHorizontal + movementVertical) * speed * Time.deltaTime, Space.World);

        // Calculate combined tilt
        float horizontalTilt = moveHorizontal * tiltAngle;
        float verticalTilt = moveVertical * tiltAngle;
        
        Quaternion targetRotation = Quaternion.Euler(horizontalTilt - 90, 0, -90);
        
        // Apply the combined rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);

        // Return to original height if no vertical input
        if (Mathf.Abs(moveVertical) < 0.001f)
        {
            Vector3 returnPosition = new Vector3(transform.position.x, originalHeight, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, returnPosition, Time.deltaTime * speed);
        }

        // Reset to upright rotation if no input
        if (Mathf.Abs(moveVertical) < 0.001f && Mathf.Abs(moveHorizontal) < 0.001f)
        {
            Quaternion uprightRotation = Quaternion.Euler(-90, 0, -90);
            transform.rotation = Quaternion.Slerp(transform.rotation, uprightRotation, Time.deltaTime * 7.0f);
        }
    }
}