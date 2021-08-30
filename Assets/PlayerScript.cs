using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody ship;
    public float speed;
    public float tilt;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public Transform gunPosition;
    public GameObject LaserShot;

    public float shotDelay;
    private float nextShotTime;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (!GameControllerScript.isStarted) 
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float correctX = Mathf.Clamp(ship.position.x, xMin, xMax);
        float correctZ = Mathf.Clamp(ship.position.z, zMin, zMax);

        ship.position = new Vector3(correctX, 0, correctZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(LaserShot, gunPosition.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;

        }
    }
}
