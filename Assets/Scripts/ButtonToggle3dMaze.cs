using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToggle3dMaze : ButtonToggle
{
    [SerializeField] Rigidbody playerRb;

    [Header("Animations")]
    [SerializeField] Animator mazeAnimController;
    [SerializeField] AnimationClip maze3dPhase2Anim;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!state)
            {
                soundManager.PlayWallButtonSFX();
                objectToToggle.SetActive(true);
                state = true;
                
                // Animations
                mazeAnimController.SetTrigger("Phase2Trigger");
                playerRb.constraints = RigidbodyConstraints.FreezePosition;
                StartUnfreezeCoroutine(maze3dPhase2Anim.length);
            }
        }
    }

    // Coroutine to unfreeze the player after a delay
    public IEnumerator UnfreezePlayerAfterDelay(float duration)
    {
        yield return new WaitForSeconds(duration);

        playerRb.constraints = RigidbodyConstraints.None;
    }

    // Example usage: Start the coroutine with a specified duration
    public void StartUnfreezeCoroutine(float duration)
    {
        StartCoroutine(UnfreezePlayerAfterDelay(duration));
    }
}
