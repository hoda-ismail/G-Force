/**
 * Ardity (Serial Communication for Arduino + Unity)
 * Author: Daniel Wilches <dwilches@gmail.com>
 * Modifications for InterfaceLab 2020 to move a cube
 *
 * This work is released under the Creative Commons Attributions license.
 * https://creativecommons.org/licenses/by/2.0/
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class KickBall : MonoBehaviour
{
    //GameObject cubeModifier;
    private Rigidbody ballBody;
    public int force;
    public float gravity;


    void Start() // Start is called before the first frame update
    {
        //cubeModifier = GameObject.Find("Cube");
        ballBody = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravity, 0);


        //This is for handling gravity, can also be done by going to Edit->Project settings->Physics
        //Physics.gravity = new Vector3(0, -3.721F, 0);

    }
    void Update() // Update is called once per frame
    {

        //Comment below if using data from Arduino
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BallKick();
        }

    }
    //Took help from: https://answers.unity.com/questions/802181/trying-to-understand-rigidbody-forcemode-derivatio.html
    //Took help from: https://www.youtube.com/watch?v=De0PoxaKlww to make the ball spin
    void BallKick()
    {
        ballBody.AddForce(Vector3.up * force, ForceMode.Impulse);
        ballBody.velocity += Vector3.forward * force / ballBody.mass;
        ballBody.AddTorque(transform.up * force, ForceMode.Impulse); //for spinning the ball forward
    }

    void OnMessageArrived(string msg)
    {
        //For testing with Arduino data
        /*int detected = int.Parse(msg);
        if (detected == 1)
        {
            KickBall();
        }*/
        Debug.Log(msg);
    }

    // Invoked when a connect/disconnect event occurs. The parameter 'success'
    // will be 'true' upon connection, and 'false' upon disconnection or
    // failure to connect.
    void OnConnectionEvent(bool success)
    {
        Debug.Log(success ? "Device connected" : "Device disconnected");
    }
}