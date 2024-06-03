using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject objectToToggle;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToToggle.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            objectToToggle.SetActive(false);
        }
    }
}
