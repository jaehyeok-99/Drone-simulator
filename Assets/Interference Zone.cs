using UnityEngine;

public class SlowZone : MonoBehaviour
{
    public float slowMultiplier = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Debug.Log("����� Interference Zone�� �����߽��ϴ�!");
            var droneMovement = other.GetComponent<DroneController.DroneMovement>();
            if (droneMovement != null)
            {
                droneMovement.speedMultiplier = slowMultiplier;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Debug.Log("����� Interference Zone�� ������ϴ�!");
            var droneMovement = other.GetComponent<DroneController.DroneMovement>();
            if (droneMovement != null)
            {
                droneMovement.speedMultiplier = 1f;
            }
        }
    }
}
