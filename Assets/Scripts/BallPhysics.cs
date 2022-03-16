using System;
using System.Collections;
using System.Collections.Generic;
using AirResistance;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR;

//Took help from: https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
//Took help from: https://www.youtube.com/watch?v=Kc6GfZwLQp0
//Took help from: https://stackoverflow.com/questions/13062481/how-to-remove-decimal-part-from-a-number-in-c-sharp
//Took help from: https://answers.unity.com/questions/61270/calculating-speed-of-rigidbody.html
public class BallPhysics : MonoBehaviour
{
    private Rigidbody ballBody;
    private TrailRenderer trail;
    public Gravity gravity;

    private float earthGravity = -9.81f;
    private float moonGravity = -1.62f;
    private float marsGravity = -3.72f;
    private float saturnGravity = -10.44f;
    
    public Transform ball;
    public Transform ballStand;
    public double ballDistanceFromStand;
    public float mass;
    
    public InputActionProperty velocityProperty;
    public Vector3 Velocity;
    public float force;
    public float controllerSpeed;
    public double ballSpeed;


    public Text forceText;
    public Text ballSpeedText;
    public Text distanceText;

    private AudioSource ballKicking;

    public InputActionProperty triggerProperty;

    
    void Start() // Start is called before the first frame update
    {
        ballKicking = GetComponent<AudioSource>();
        ballBody = GetComponent<Rigidbody>();
        mass = ballBody.GetComponent<Rigidbody>().mass;
        trail = ballBody.GetComponent<TrailRenderer>();

    }
    //This is for handling gravity, can also be done by going to Edit->Project settings->Physics
    //Took help from:: https://learn.unity.com/tutorial/working-with-switch-statements#
    public enum Gravity
    {
        EarthGravity, MoonGravity, MarsGravity, SaturnGravity
    }
    
    void Update() // Update is called once per frame
    {


        

        ballSpeed = Math.Round(ballBody.velocity.magnitude, 2);
        ballSpeedText.text = ballSpeed.ToString();

        ballDistanceFromStand = Math.Truncate(Vector3.Distance(ballStand.position, ball.position));
        ballDistanceFromStand = (float)Math.Round(ballDistanceFromStand, 2);
        distanceText.text = ballDistanceFromStand.ToString();

        switch (gravity)
        {
            case Gravity.EarthGravity:
                Physics.gravity = new Vector3(0, earthGravity, 0);
                break;
            case Gravity.MoonGravity:
                Physics.gravity = new Vector3(0, moonGravity, 0);
                break;
            case Gravity.MarsGravity:
                Physics.gravity = new Vector3(0, marsGravity, 0);
                break;
            case Gravity.SaturnGravity:
                Physics.gravity = new Vector3(0, saturnGravity, 0);
                break;
                
            default:
                Physics.gravity = new Vector3(0, 0, 0);
                break;
        }

        //Stop the ball if the speed is less then 0.1
        /*if (ballSpeed != 0 && ballSpeed <= 0.6)
        {
            ballBody.velocity = Vector3.zero;
            ballSpeed = 0;
            force = 0;
        }*/


    }
    
    //Took help from: https://answers.unity.com/questions/802181/trying-to-understand-rigidbody-forcemode-derivatio.html
    //Took help from: https://www.youtube.com/watch?v=De0PoxaKlww to make the ball spin
    public void KickBall()
    {
        ballKicking.Play();
        controllerSpeed = velocityProperty.action.ReadValue<Vector3>().magnitude;
        force = controllerSpeed * mass * 10;
        force = (float)Math.Round(force, 2);
        forceText.text = force.ToString();

        ballBody.AddForce(Vector3.up * force,ForceMode.Impulse);
        ballBody.velocity += Vector3.forward * force / ballBody.mass;
        ballBody.AddTorque(transform.right * force, ForceMode.Impulse); //for spinning the ball on X axis
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Ground"))
        {
            trail.Clear();
            trail.enabled = false;
        }
    }

}