using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool canTeleport = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Portal") && canTeleport)
        {
            Portal portal = other.GetComponent<Portal>();
            if (portal != null)
            {
                StartCoroutine(portal.Teleport(gameObject.GetComponent<Collider>()));
            }
        }
    }

    public IEnumerator Cooldown(float cooldownTime)
    {
        canTeleport = false;
        yield return new WaitForSeconds(cooldownTime);
        canTeleport = true;
    }
}
