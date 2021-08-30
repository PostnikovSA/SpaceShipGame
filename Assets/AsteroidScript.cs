using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float speed;
    public float angularSpeed;
    

    public GameObject asteroidExplotionEffect;
    public GameObject playerExplotionEffect;

    float randomSize;

    Rigidbody asteroid;
    // Start is called before the first frame update
    void Start()
    {
        randomSize = Random.Range(0.5f, 2.0f);
        asteroid = GetComponent<Rigidbody>();
        transform.localScale *= randomSize;
        asteroid.velocity = new Vector3(0, 0, -speed);
        asteroid.velocity /= randomSize;
        asteroid.angularVelocity = Random.insideUnitSphere * angularSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Asteroid")
        {
            return;
        }

        if (other.tag == "GameBoundary") 
        {
            return;
        }

        Instantiate(asteroidExplotionEffect, transform.position, Quaternion.identity);
        

        if (other.tag == "Player") 
        {
            Instantiate(playerExplotionEffect, other.transform.position, Quaternion.identity);
        }

        GameControllerScript.score += (int)(10 * randomSize);

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
