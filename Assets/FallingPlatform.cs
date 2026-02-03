using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class FallingPlatform : MonoBehaviour
{
    [Header("Settings")]
    public float fallDelay = 0.5f;
    public float destroyDelay = 2.0f;

    [Tooltip("How hard to push the platform down. 0 = normal gravity. 10 = fast drop.")]
    public float fallSpeed = 10.0f; // NEW SETTING

    private Rigidbody rb;
    private bool isFalling = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isFalling)
        {
            StartCoroutine(StartFall());
        }
    }

    IEnumerator StartFall()
    {
        isFalling = true;

        yield return new WaitForSeconds(fallDelay);

        rb.isKinematic = false;
        rb.useGravity = true;

        // NEW: Apply an instant downward push
        rb.linearVelocity = Vector3.down * fallSpeed;

        Destroy(gameObject, destroyDelay);
    }
}