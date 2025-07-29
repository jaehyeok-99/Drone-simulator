using UnityEngine;

public class InterferenceZone : MonoBehaviour
{
    public float slowMultiplier = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Drone"))
        {
            Debug.Log("드론이 Interference Zone에 진입");
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
            Debug.Log("드론이 Interference Zone을 벗어남");
            var droneMovement = other.GetComponent<DroneController.DroneMovement>();
            if (droneMovement != null)
            {
                droneMovement.speedMultiplier = 1f;
            }
        }
    }
}
