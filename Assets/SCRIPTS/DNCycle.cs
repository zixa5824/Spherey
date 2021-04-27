
using UnityEngine;

public class DNCycle : MonoBehaviour
{
    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 10f*Time.deltaTime); 
    }
}
