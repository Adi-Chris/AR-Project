using UnityEngine;

public class Wall : MonoBehaviour
{
    public GameObject objectToToggle;
    [SerializeField] SoundManager soundManager;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundManager.PlayWallButtonSFX();
            objectToToggle.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            soundManager.PlayWallButtonSFX();
            objectToToggle.SetActive(false);
        }
    }
}
