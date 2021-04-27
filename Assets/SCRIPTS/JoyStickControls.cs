using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickControls : MonoBehaviour
{
    public Rigidbody player;
    public float movementSpeed = 300f;
    private Vector2 A, B;
    private bool touchStart = false;
    public PlayerMovement playerMovement;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            A = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        if(Input.GetMouseButton(0))
        {
            touchStart = true;
            B = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z));
        }
        else
        {
            touchStart = false;
        }
    }
    private void FixedUpdate()
    {
        if(touchStart)
        {
            Vector2 offset = B - A;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            //moveCharacter(direction * -1);
        }
    }
    /*void moveCharacter(Vector2 direction)
    {
        if (direction.x > 0)
            playerMovement.MoveRight();
        if (direction.x < 0)
            playerMovement.MoveLeft();
    }*/
}
