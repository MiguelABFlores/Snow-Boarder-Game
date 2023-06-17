using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelayFL = 2f;
    [SerializeField] ParticleSystem finishEffect;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player") {
            Debug.Log("You finished!");
            finishEffect.Play();
            Invoke("ReloadScene", loadDelayFL);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
