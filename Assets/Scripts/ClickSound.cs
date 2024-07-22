using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSound : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    private void Update() {
        if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)){
            clickSound.Play();
        }
    }
}
