using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowMultiplier = 0.5f; // ���ϴ� ��ŭ ������
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity *= slowMultiplier;
                rb.linearDamping = 5f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearDamping = 0f;
            }
        }
    }
}
