using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsUIManager : MonoBehaviour
{
    [SerializeField] Animator creditsAnim;
    [SerializeField] SoundManager soundManager;

    public void ShowCredits() {
        soundManager.PlayUIButtonSFX();
        creditsAnim.SetTrigger("FadeInTrigger");
    }

    public void HideCredits() {
        soundManager.PlayUIButtonSFX();
        creditsAnim.SetTrigger("FadeOutTrigger");
    }
}
