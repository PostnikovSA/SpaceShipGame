using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSourceScript : MonoBehaviour
{
    public GameObject asteroid;
    public float delay;

    float nextTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.isStarted) 
            return;

        if (Time.time > nextTime) 
        {
            float leftPosition = -(transform.localScale.x / 2);
            float rightPosition = transform.localScale.x / 2;
            float randomX = Random.Range(leftPosition, rightPosition);

            Vector3 randomPosition = new Vector3(randomX, 0, transform.position.z);
           

            Instantiate(asteroid, randomPosition, Quaternion.identity);
            nextTime = Time.time + delay;
        }
    }
}
