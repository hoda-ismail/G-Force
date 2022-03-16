using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class WormHoleLoader : XRGrabInteractable
{

    public Transform ball;
    public int wormHoleSceneIndex;

    private SerialListener ballSerialListener;

    public static int NextLevel { get; private set; }

    private void Start()
    {
        ballSerialListener = ball.GetComponent<SerialListener>();
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {
        
        if (ballSerialListener.kicked)
        {
            ballSerialListener.kicked = false;
            NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(wormHoleSceneIndex);
        }
        
    }

}
