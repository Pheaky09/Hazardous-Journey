using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float distance;
    private void Start()
    {
        distance = transform.position.y - player.position.y;
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x+4, player.position.y + distance, transform.position.z);
    }

}
