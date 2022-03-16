using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Took help from: https://www.youtube.com/watch?v=TAGZxRMloyU
public class DisplayData : MonoBehaviour
{

    public Transform ball;
    public Text distanceText;
    public Text speedText;

  
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = ball.GetComponent<BallPhysics>().ballDistanceFromStand + " m";
        speedText.text = ball.GetComponent<BallPhysics>().ballSpeed + " m/s";
        

    }
}
