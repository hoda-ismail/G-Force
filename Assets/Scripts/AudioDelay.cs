using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDelay : MonoBehaviour
{
    public float delayTime = 30f;

    private AudioSource audioIntro;

    // Start is called before the first frame update
    private void Start()
    {
        audioIntro = GetComponent<AudioSource>();
        StartCoroutine(StartAudio());
    }

    IEnumerator StartAudio()
    {
        yield return new WaitForSeconds(delayTime);
        audioIntro.Play();
    }

}