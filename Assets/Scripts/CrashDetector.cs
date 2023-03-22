using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;
    bool hasCrashed = false;
    CircleCollider2D collider2DD;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ground" && hasCrashed == false)
        {
            hasCrashed = true;
            Debug.Log("Kafam yere çarpti");
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            Invoke("ReloadScene",loadDelay);
            collider2DD = GetComponent<CircleCollider2D>();
            collider2DD.isTrigger  = false;
        }
        
    }

    void ReloadScene()
    {
         SceneManager.LoadScene(0);
    }
}
