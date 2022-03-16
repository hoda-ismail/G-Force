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
using AirResistance;
using Newtonsoft.Json.Linq;
using UnityEngine;
public class SerialListener : MonoBehaviour
{
    private BallPhysics ballPhysics;
    public bool kicked = false;

    void Start() // Start is called before the first frame update
    {
        ballPhysics = GetComponent<BallPhysics>();
    }
   
    //Reading data from Arduino
    void OnMessageArrived(string msg)
    {
        //For testing with Arduino data
        int detected = int.Parse(msg);
        
        if (detected == 5 && kicked == false)
        {
            ballPhysics.KickBall();
            kicked = true;
        }
            
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