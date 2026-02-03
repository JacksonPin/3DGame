using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [Header("Platform Settings")]
    public float speed = 2.0f;
    public float distance = 3.0f;
    public Vector3 moveDirection = Vector3.right;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        float oscillation = Mathf.Sin(Time.time * speed);
        transform.position = startPosition + (moveDirection.normalized * oscillation * distance);
    }

    // ---------------------------------------------------------
    // TRIGGER LOGIC (Better than Collision)
    // ---------------------------------------------------------

    // Use OnTrigger instead of OnCollision
    private void OnTriggerEnter(Collider other)
    {
        // "other" is the object that entered the trigger
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}