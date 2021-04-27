using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{
    Rigidbody player;
    float dirX;
    float moveSpeed = 35f;
    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        dirX = Input.acceleration.x * moveSpeed;
        moveSpeed += Time.timeSinceLevelLoad / 5000;
    }
    private void FixedUpdate()
    {
        player.velocity = new Vector3(dirX, player.velocity.y, player.velocity.z);
    }
}
