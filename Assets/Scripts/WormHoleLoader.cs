using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class WormHoleLoader : XRGrabInteractable
{

    public Transform ball;
    public int wormHoleSceneIndex;

    private SerialListener ballSerialListener;
    private DottedOutline dottedOutline;

    public static int NextLevel { get; private set; }

    private void Start()
    {
        ballSerialListener = ball.GetComponent<SerialListener>();
        dottedOutline = GetComponent<DottedOutline>();
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        dottedOutline.isDotted = true;
        dottedOutline.lineWidth = 0.07f;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        dottedOutline.lineWidth = 0f;
    }
    protected override void OnSelectEntering(SelectEnterEventArgs args)
    {

        dottedOutline.isDotted = false;
        dottedOutline.lineWidth = 0.07f;

        if (ballSerialListener.kickedOnce)
        {
            NextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(wormHoleSceneIndex);
        }
        
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        dottedOutline.lineWidth = 0f;
    }

}
