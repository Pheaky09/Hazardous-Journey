using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Finish : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;
    private AudioSource finishSound;
    private bool isFinished = false;
    private void Start() {
        finishSound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player" && !isFinished) {
            finishSound.Play();
            isFinished = true;
            gameOverText.text = "You Win!";
            Invoke("CompleteLevel", 2f);
        }
    }
    private void CompleteLevel() {
        SceneManager.LoadScene(0);
    }
}
