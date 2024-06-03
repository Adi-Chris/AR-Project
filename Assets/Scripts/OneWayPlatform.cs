using UnityEngine;

public class OneWayPlatform3D : MonoBehaviour
{
    private Collider platformCollider;

    void Start()
    {
        platformCollider = GetComponent<Collider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Masuk");
            Physics.IgnoreCollision(other, platformCollider, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("KELUAR");
            Physics.IgnoreCollision(other, platformCollider, false);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("STAY");
            if (collision.transform.position.x > transform.position.x)
            {
                Physics.IgnoreCollision(collision.collider, platformCollider, false);
            }
            else
            {
                Physics.IgnoreCollision(collision.collider, platformCollider, true);
            }
        }
    }
}
