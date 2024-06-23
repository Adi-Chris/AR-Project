using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource sfxAudioSource;

    [Header("Gameplay")]
    [SerializeField] AudioClip portalTeleportSFX;
    [SerializeField] AudioClip wallButtonSFX;
    [SerializeField] AudioClip spikeHitSFX;
    [SerializeField] AudioClip finishSFX;

    [Header("UI")]
    [SerializeField] AudioClip UIButtonSFX;

    // Gameplay
    public void PlayPortalTeleportSFX() {
        sfxAudioSource.PlayOneShot(portalTeleportSFX);
    }

    public void PlayWallButtonSFX()
    {
        sfxAudioSource.PlayOneShot(wallButtonSFX);
    }

    public void PlaySpikeHitSFX()
    {
        sfxAudioSource.PlayOneShot(spikeHitSFX);
    }

    public void PlayFinishSFX()
    {
        sfxAudioSource.PlayOneShot(finishSFX);
    }

    // UI
    public void PlayUIButtonSFX()
    {
        sfxAudioSource.PlayOneShot(UIButtonSFX);
    }
}
