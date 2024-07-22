using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject portal;
    
    private void Start() {
        player = GameObject.FindWithTag("Player");
        
    }
   private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
        }
   }
        
    

}
