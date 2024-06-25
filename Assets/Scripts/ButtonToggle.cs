using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject objectToToggle;
    public bool state = true;
    public SoundManager soundManager;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (state)
            {
                ToggleDisable();
            }
            else
            {
                ToggleEnable();
            }
        }
    }

    public void ToggleDisable()
    {
        soundManager.PlayWallButtonSFX();
        objectToToggle.SetActive(false);
        state = false;
    }

    public void ToggleEnable()
    {
        soundManager.PlayWallButtonSFX();
        objectToToggle.SetActive(true);
        state = true;
    }
}
