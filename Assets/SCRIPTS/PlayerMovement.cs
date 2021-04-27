using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    public float fallMultiplyer = 2.5f;
    public Rigidbody rb;
    public float speed = 1500f, movementSpeed = 35f, JumpHeight = 700f;
    private bool checkJump = false;
    private void Start()
    {
       Time.timeScale = 1f;
       Time.fixedDeltaTime = 0.02f;
    }
    private void FixedUpdate()
    {
        //print(Time.timeScale+" "+ Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.D))
            MoveRight();
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        if (rb.velocity.y < 0) // Smoother Jump
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplyer - 1) * Time.deltaTime;
        }
        movementSpeed += Time.timeSinceLevelLoad / 1000;
        JumpHeight += Time.timeSinceLevelLoad / 1000;
    }
    public void MoveRight() {
        rb.AddForce(movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    public void MoveLeft()
    {
        rb.AddForce(-movementSpeed * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
    public void Jump()
    {
        if (checkJump == true)
        {
            checkJump = false;
            rb.AddForce(0, JumpHeight, 0);
        }
    }
    public void setCheckJump(bool jump)
    {
        checkJump = jump;
    }
    public bool getCheckJump()
    {
        return checkJump;
    }

}
