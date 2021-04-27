using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public static CollisionDetection instance = null;
    PlayerMovement player;
    bool check;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            return;
        player = GetComponent<PlayerMovement>();
        check = true;
    }
    private void Update()
    {
        if (player.transform.position.y < -1 && check)
        {
            check = false;
            FindObjectOfType<GameManager>().GameEnded();
        }
    }
    void OnCollisionEnter(Collision collison)
    {
        if (collison.collider.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameEnded();
        }
        if (collison.collider.name == "Ground")
        {
            player.setCheckJump(true);
        }
        if (player.getCheckJump() == true && collison.collider.tag == "JumpPad")
        {
            player.Jump();
        }
    }
}
