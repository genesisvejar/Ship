using Unity.Burst.CompilerServices;
using UnityEngine;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 thrustDirection = new Vector2(1, 0);

    private const float ThrustForce = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();


    }

    void FixedUpdate()
    {
        //Apply thrust force at a fixed time interval
        
        //this means that the thrust force would be applied when the spacebar is presseed
        float thrustInput = Input.GetAxis("Thrust");
       
        //if the spacebar is 0, the spacebar isn't being pressed
        if (thrustInput > 0)
        {
            rb2d.AddForce(ThrustForce * thrustDirection, ForceMode2D.Force);
            //addForce (forcevector(direction*magnitude), forcemode (how to apply the force) 
            // . force makes sure it's continuous force rather than an impulse)
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
