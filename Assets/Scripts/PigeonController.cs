using UnityEngine;

public class PigeonController : MonoBehaviour
{
    public float speed = 15.0f;
    private float originalHeight;

    void Start()
    {
        originalHeight = transform.position.y;
    }

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        HandleMovement(moveHorizontal, moveVertical);
        ReturnToOriginalHeight(moveVertical);
    }

    void HandleMovement(float moveHorizontal, float moveVertical)
    {
        // Adjust the movement direction to use Unity's standard mapping
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
    }

    void ReturnToOriginalHeight(float moveVertical)
    {
        if (Mathf.Abs(moveVertical) < 0.001f)
        {
            Vector3 returnPosition = new Vector3(transform.position.x, originalHeight, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, returnPosition, Time.deltaTime * speed);
        }
    }
}
