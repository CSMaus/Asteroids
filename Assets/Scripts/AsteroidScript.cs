using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;//spin
    public Rigidbody2D rb;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public int asteroidSize; //3, 1.5 & 1

    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    private List<GameObject> asteroids;

    // Start is called before the first frame update
    void Start()
    {
        //add a random amount of torque and thrust to the asteroid
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

        //asteroidSize = 3;

    }

    // Update is called once per frame
    void Update()
    {
        //Screen Wrapping (cheking coords)
        Vector2 newPos = transform.position;
        if (transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        transform.position = newPos;
    }

    //make one prefub for all asteroid's types

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //check to see if its a bullet
        if(collision.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            
            //check size of the asteroid and spawn the next smaller size
            if(asteroidSize == 3)
            {
                //spawn smaller
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                Instantiate(asteroidMedium, transform.position, transform.rotation);
                //asteroid1.GetComponent<AsteroidScript>().asteroidSize = 2;
                //asteroid2.GetComponent<AsteroidScript>().asteroidSize = 2;
            }
            else if (asteroidSize == 2)
            {
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                Instantiate(asteroidSmall, transform.position, transform.rotation);
                //asteroid1.GetComponent<AsteroidScript>().asteroidSize = 1;
                //asteroid2.GetComponent<AsteroidScript>().asteroidSize = 1;
            }
            else if(asteroidSize == 1)
            {
                //destroy the asteroid
                

            }

            Destroy(gameObject);
        }

    }

    //every 3 second we will create new asteroid
    //asteroid's sprite will choise randomly from folder Asteroids
    //while creating asteroid size will choise randomly
    private void FixedUpdate()
    {
        if (Time.time)
        //Instantiate(asteroidMedium, transform.position, transform.rotation);
        //Instantiate(asteroidMedium, transform.position, transform.rotation);
    }

}
