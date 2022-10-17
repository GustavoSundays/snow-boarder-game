using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip deathSfx;
    [SerializeField] float reloadSceneDelay = 1f;
    PolygonCollider2D bodyCollider;
    bool hasCrashed = false;

    private void Start() {
        bodyCollider = GetComponent<PolygonCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if(other.gameObject.tag == "Ground" && bodyCollider.IsTouching(other.collider) && !hasCrashed) {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(deathSfx);
            Invoke("ReloadScene", reloadSceneDelay);
        }

    }

    private void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
