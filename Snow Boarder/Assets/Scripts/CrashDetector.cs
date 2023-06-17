using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float loadDelayHit = 0.5f;
    [SerializeField] ParticleSystem crashEffect;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Terrain") {
            Debug.Log("Ouch!");
            crashEffect.Play();
            Invoke("ReloadScene", loadDelayHit);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }

}
