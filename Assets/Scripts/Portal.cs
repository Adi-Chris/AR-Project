using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform otherPortal;
    public GameObject ball; // Assuming the ball is a separate GameObject

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportBall(other.transform);
        }
    }

    void TeleportBall(Transform ballTransform)
    {
        Vector3 portalToBall = ballTransform.position - transform.position;
        float dotProduct = Vector3.Dot(transform.forward, portalToBall);

        if (dotProduct > 0f) // Ball is moving towards the portal
        {
            Vector3 newPosition = otherPortal.position + (otherPortal.forward * portalToBall.magnitude);
            ballTransform.position = newPosition;

            // Adjust ball's rotation based on portal orientation
            Quaternion rotationDiff = Quaternion.FromToRotation(transform.forward, otherPortal.forward);
            ballTransform.rotation = rotationDiff * ballTransform.rotation;
        }
    }
}
