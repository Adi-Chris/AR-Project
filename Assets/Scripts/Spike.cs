using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundManager.PlaySpikeHitSFX();
            Destroy(other.gameObject);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name); // TODO: Ubah jadi restart dengan delay
        }
    }

    // TODO: Tambahi delay sebelum restart disini
}
