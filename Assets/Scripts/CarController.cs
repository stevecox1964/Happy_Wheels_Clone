using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


    // [HideInInspector]
    public float fuel = 1;
    public float fuelconsumption = 0.1f;
    public Rigidbody2D carRigidbody;
    public Rigidbody2D backTire;
    public Rigidbody2D frontTire;
    public float speed = 20;
    public float carTorque = 10;

    public float tireTorque = 0;
    
    public float movement;
    public UnityEngine.UI.Image gasCanImage;

    public float thrust = 0f;

    public GameObject thrustingEffect;

    // Use this for initialization
    void Start ()
    {
        //not used
    }
	
	// Update is called once per frame
	void Update ()
    {
     
        if(Input.GetKey(KeyCode.RightArrow) == true)
        {
            thrust += 10f;
            movement = 1;
        }
        else
        {
            movement = 0;
        }

        //Modifiy gas can fill amount
        gasCanImage.fillAmount = fuel;
	}

    private void FixedUpdate()
    {
        
        //Calc tire torque
        tireTorque = -movement * speed * Time.fixedDeltaTime;

        //Add torque to wheels
        backTire.AddTorque(tireTorque);
        frontTire.AddTorque(tireTorque);

        //Decrease thrust over time
        thrust -= 10.0f;

        //Clip to zero
        if (thrust <= 0)
            thrust = 0;

        if (thrust > 0)
        {
            //Turn on rocket thrust effect
            thrustingEffect.SetActive(true);

            //NOTE
            //What we really want I think is to create a force vector
            //and apply that vector to the vehicle based off of vehical angle
            //Not sure how to do this

            //WORKS
            //carRigidbody.AddForce(Vector2.right * thrust);

            //ALSO WORKS
            carRigidbody.AddRelativeForce(Vector2.right * thrust);

        }
        else
        {
            //Turnoff effect
            thrustingEffect.SetActive(false);
        }

        //Decrease fuel based off of movement variable
        fuel -= fuelconsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;
    }


    /* OLD CODE EXPERIMENTS FOR REFERENCE
     if (thrust > 0)
        {

            //Vector3 targetDelta = target.position - transform.position;

            ////get the angle between transform.forward and target delta
            //float angleDiff = Vector3.Angle(transform.forward, targetDelta);

            //// get its cross product, which is the axis of rotation to
            //// get from one vector to the other
            //Vector3 cross = Vector3.Cross(transform.forward, targetDelta);

            //// apply torque along that axis according to the magnitude of the angle.
            //rigidbody.AddTorque(cross * angleDiff * force);


            //Vector2 force = new Vector2(carRigidbody.position.x * -thrust, carRigidbody.position.y);
            //float angle = Mathf.Asin(carRigidbody.position.y) * Mathf.Rad2Deg;

            //float angle = Mathf.Atan2(carRigidbody.position.y, carRigidbody.position.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            //if (carRigidbody.position.x < 0f)
            //    angle = 180 - angle;

            //Debug.Log(angle);

            //gunTransform.localEulerAngles = new Vector3(0f, 0f, angle);

            thrustingEffect.SetActive(true);

            //Vector2 forcePosition = new Vector2(carRigidbody.position.x - 5, carRigidbody.position.y);
            //carRigidbody.AddForceAtPosition(force, forcePosition);

            //Transform carTransform = carRigidbody.transform;
            //carRigidbody.AddForce(carTransform.forward * thrust);

            //WORKS
            //carRigidbody.AddForce(Vector2.right * thrust);

            //ALSO WORKS
            carRigidbody.AddRelativeForce(Vector2.right * thrust);

        } 
     * 
     */


}
