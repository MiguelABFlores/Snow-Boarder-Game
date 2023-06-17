using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] float loadDelayFL = 2f;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Debug.Log("You finished!");
            Invoke("ReloadScene", loadDelayFL);
        }
    }

    void ReloadScene() {
        SceneManager.LoadScene(0);
    }
}
