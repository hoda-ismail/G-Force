using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallPosition : MonoBehaviour
{
    public Transform ball;
    private Vector3 startPos;

    private Rigidbody ballRigidBody;
    private TrailRenderer ballTrailRenderer;
    private SerialListener ballSerialListener;
    private BallPhysics ballPhysics;


    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = ball.GetComponent<Rigidbody>();
        ballTrailRenderer = ball.GetComponent<TrailRenderer>();
        ballSerialListener = ball.GetComponent<SerialListener>();
        ballPhysics = ball.GetComponent<BallPhysics>();

        startPos = ball.position;
    }

    public void ResetBallToStand()
    {
        
        ballTrailRenderer.Clear();
        ballRigidBody.transform.right = Vector3.zero;
        ball.position = startPos;
        ballPhysics.force = 0;
        ballPhysics.forceText.text =  0.ToString();


        ballRigidBody.AddForce(Vector3.zero);
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.angularVelocity = Vector3.zero;
        ballRigidBody.AddTorque(Vector3.zero);
        ballRigidBody.constraints = RigidbodyConstraints.None;

        ballSerialListener.kicked = false;
    }
}
