using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipControls : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    private float thrustInput;
    private float turnInput;

    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public float bulletForce;

    public float deathForce;
    

    public GameObject bullet;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Check for input from the keyboard
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        //Check for input from the fire key and make bullets
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);

            Destroy(newBullet, 3.5f);
        }

        //rotate the ship; z axis = Vector3.forward
        transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * -turnThrust);


        //Screen Wrapping (cheking coords)
        
        Vector2 newPos = transform.position;
        if(transform.position.y > screenTop)
        {
            newPos.y = screenBottom;
        }
        else if(transform.position.y < screenBottom)
        {
            newPos.y = screenTop;
        }
        if (transform.position.x < screenLeft)
        {
            newPos.x = screenRight;
        }
        else if (transform.position.x > screenRight)
        {
            newPos.x = screenLeft;
        }
        transform.position = newPos;
    }

    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector2.up * thrustInput);
        rb.AddTorque(-turnInput);
    }

    // acteroids impact (столкновение с астероидами)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.magnitude > deathForce)
        {
            Debug.Log("Death");
        }
    }

}
