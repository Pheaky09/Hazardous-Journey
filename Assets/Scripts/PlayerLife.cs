using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private AudioSource deathSound;
    private Rigidbody2D rb;
    private Animator anim;
    private void Start() {
        anim=GetComponent<Animator>();
        rb=GetComponent<Rigidbody2D>();
    }
   private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Trap")){
            Die();
        }
   }
   private void Die(){
        deathSound.Play();
        rb.bodyType=RigidbodyType2D.Static;
        anim.SetTrigger("death");
   }
    private void Restart(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
