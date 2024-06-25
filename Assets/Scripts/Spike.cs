using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour
{
    [SerializeField] SoundManager soundManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] PC_Gyro playerController;
    [SerializeField] ParticleSystem playerDeathParticle;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            soundManager.PlaySpikeHitSFX();
            playerController.gameObject.SetActive(false);

            playerController.Rb.velocity = new Vector3(0, 0, 0);
            soundManager.SetRollingBallSFXVolume(0);
            
            playerDeathParticle.transform.position = other.transform.position;
            playerDeathParticle.Play();

            gameManager.VibratePhone();

            StartCoroutine(PlayDeathAnimation());
        }
        // Ide: Ball didisable, particle maen, delay, restart ball & restart timer dr gamemanager
    }

    private IEnumerator PlayDeathAnimation() {
        yield return new WaitForSeconds(playerDeathParticle.main.duration + 0.5f);
        playerController.gameObject.SetActive(true);
        gameManager.Restart();
    }
    // TODO: Tambahi delay sebelum restart disini
}
