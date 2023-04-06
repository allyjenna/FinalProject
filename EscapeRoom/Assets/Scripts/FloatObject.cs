using UnityEngine;

public class FloatObject : MonoBehaviour
{
    [SerializeField] private float floatHeight = 0.5f;  // The height that the object will float above its initial position
    [SerializeField] private float floatSpeed = 0.5f;   // The speed at which the object will float

    private Vector3 startPos;                          // The object's initial position

    private void Start()
    {
        startPos = transform.position;                 // Store the object's initial position
    }

    private void Update()
    {
        // Calculate the new position for the object based on the current time and the float speed
        float newYPos = Mathf.Sin(Time.time * floatSpeed) * floatHeight + startPos.y;

        // Update the object's position with the new y coordinate
        transform.position = new Vector3(transform.position.x, newYPos, transform.position.z);
    }
}
