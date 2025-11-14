using Unity.Burst.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Ship : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 thrustDirection = new Vector2(1, 0);

    private const float ThrustForce = 25f;

    private float colliderRadius;


    private float screenLeft;

    private float screenRight;

    private float screenTop;

    private float screenBottom;

    private const float RotateDegreesPerSecond = 15f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;


        //we put these variables here so they can get reused later 
        screenLeft = ScreenUtils.ScreenLeft;
        screenRight = ScreenUtils.ScreenRight;
        screenTop = ScreenUtils.ScreenTop;
        screenBottom = ScreenUtils.ScreenBottom;
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

/// <summary>
/// This method is used to wrap the ship to the opposite side of the screen
/// </summary>
    void OnBecameInvisible()
    {

        float thrustInput = Input.GetAxis("Thrust");
        
        Vector2 position = transform.position;

        if (position.x < screenLeft)
        {
            position.x = screenRight + colliderRadius;

        }

        else if (position.x > screenRight)
        {
            position.x = screenLeft - colliderRadius;

            
        }

        if (position.y < screenBottom)
        {
            position.y = screenTop + colliderRadius;

        }

        else if (position.x > screenTop)
        {
            position.x = screenBottom - colliderRadius;

            
        }
        transform.position = position;
        
    }
    // Update is called once per frame
    void Update()
    {

        float rotationInput = Input.GetAxis("Rotate");
        // calculate rotation amount and apply rotation


        //this was added so the ship rotates only when one of the keys are pressed
        if (rotationInput!=0)
        
        {

        float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0) {
            rotationAmount *= -1;
            }

        transform.Rotate(Vector3.forward, rotationAmount);

        //rotation happens on the z axis because we are in a 2d game
        float angleInDegrees = transform.eulerAngles.z;

        //you need to convert the angles from degrees to radians because you're using trig formulas

        float angleInRadiants =angleInDegrees * Mathf.Deg2Rad;
        
        //these values are used on the thrustDirection on the fixedUpdate function
        thrustDirection.x = Mathf.Cos(angleInRadiants);

        thrustDirection.y =Mathf.Sin(angleInRadiants);

        }
    }
}
