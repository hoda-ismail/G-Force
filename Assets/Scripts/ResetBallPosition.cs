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
    

    // Start is called before the first frame update
    void Start()
    {
        ballRigidBody = ball.GetComponent<Rigidbody>();
        ballTrailRenderer = ball.GetComponent<TrailRenderer>();
        ballSerialListener = ball.GetComponent<SerialListener>();

        startPos = ball.position;
    }

    public void ResetBallToStand()
    {
        ballTrailRenderer.Clear();
        ballRigidBody.velocity = Vector3.zero;
        ballRigidBody.transform.right = Vector3.zero;
        ball.position = startPos;
        ballSerialListener.kicked = false;
    }
}
