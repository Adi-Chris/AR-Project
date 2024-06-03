using UnityEngine;

public class ButtonToggle : MonoBehaviour
{
    public GameObject objectToToggle;
    public bool state = true;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (state)
            {
                objectToToggle.SetActive(false);
                state = false;
            }
            else
            {
                objectToToggle.SetActive(true);
                state = true;
            }
        }
    }
}
