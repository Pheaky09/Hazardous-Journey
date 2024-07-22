using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CollectedItems : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI cherriesText;
    [SerializeField] private TextMeshProUGUI appleText;
    [SerializeField] private TextMeshProUGUI pineappleText;
    [SerializeField] private AudioSource collectedItemSound;
    private int collectedCherries = 0;
    private int collectedApples = 0;
    private int collectedPineapples = 0;

    private void OnTriggerEnter2D(Collider2D collison) {
       if(collison.gameObject.CompareTag("Cherry")) {
            collectedItemSound.Play();
           Destroy(collison.gameObject);
            collectedCherries++;
            cherriesText.text = collectedCherries.ToString(": "+collectedCherries);
       }
         if(collison.gameObject.CompareTag("Apple")) {
            collectedItemSound.Play();
              Destroy(collison.gameObject);
                collectedApples++;
                appleText.text = collectedApples.ToString(": "+collectedApples);
         }
        if(collison.gameObject.CompareTag("Pineapple")) {
            collectedItemSound.Play();
                 Destroy(collison.gameObject);
                    collectedPineapples++;
                    pineappleText.text = collectedPineapples.ToString(": "+collectedPineapples);
            }
    }
        

}
