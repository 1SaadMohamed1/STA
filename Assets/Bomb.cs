using UnityEngine;
using StarterAssets;
using System.Collections;

public class Bomb : MonoBehaviour
{
    private ThirdPersonController movement;
    private Animator anim;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            player = other.gameObject;
            movement = player.GetComponent<ThirdPersonController>();
            anim = player.GetComponent<Animator>();
            StartCoroutine(FreezePlayer());

        }
    }

    IEnumerator FreezePlayer()
    {

        anim.SetFloat("Speed", 0.0f);
        anim.SetFloat("MotionSpeed", 0.0f);
        movement.enabled = false;
        yield return new WaitForSeconds(5f);
        movement.enabled = true;
        gameObject.SetActive(false);
    }
}