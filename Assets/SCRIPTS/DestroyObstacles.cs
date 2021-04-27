using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObstacles : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -2f)
            Destroy(gameObject);
    }
}
