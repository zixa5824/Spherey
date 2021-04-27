using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    Rigidbody rb;
    public static float speed = 500f;
    private float fastness = 1.0005f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }
    private void FixedUpdate()
    {
        rb.AddForce(0, 0, -speed * Time.deltaTime, ForceMode.Acceleration);
    }
    public void nextWave()
    {
        speed += Time.timeSinceLevelLoad * fastness;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public void SaveSpeed(float tempSpeed)
    {
        speed = tempSpeed;
    }
}
