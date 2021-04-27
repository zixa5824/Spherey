using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunEffect : MonoBehaviour
{
    private float timeBtwSpawns, startTimeBtwSpawns;
    public GameObject runPlayer;
    private void Start()
    {
        startTimeBtwSpawns = 0.05f;
    }
    private void Update()
    {
        if (FindObjectOfType<PlayerMovement>().getCheckJump() == true)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(runPlayer, new Vector3(transform.position.x, transform.position.y-0.3f, transform.position.z), Quaternion.identity);
                Destroy(instance, 0.3f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
