using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour
{
    public GameObject targetPortal; // Assign the target portal in the Inspector
    private bool isTeleporting = false;
    [SerializeField] SoundManager soundManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTeleporting)
        {
            StartCoroutine(Teleport(other));
        }
    }

    public IEnumerator Teleport(Collider player) // Change to public
    {
        isTeleporting = true;
        Vector3 targetPosition = targetPortal.transform.position;
        player.transform.position = targetPosition;

        // Set the target portal to be teleporting
        Portal targetPortalScript = targetPortal.GetComponent<Portal>();
        targetPortalScript.isTeleporting = true;

        // SFX
        soundManager.PlayPortalTeleportSFX();

        // Prevent the player from teleporting immediately again
        BallPortal ball = player.GetComponent<BallPortal>();
        if (ball != null)
        {
            StartCoroutine(ball.Cooldown(1f));
        }

        // Add a small delay to prevent immediate re-teleportation
        yield return new WaitForSeconds(1f);

        // Ensure player exits the target portal collider
        yield return new WaitForSeconds(1f);

        // Allow teleportation again
        isTeleporting = false;
        targetPortalScript.isTeleporting = false;
    }
}
