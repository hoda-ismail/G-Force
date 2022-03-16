using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float stayOnSceneTime = 4f;
    public int nextSceneIndex;

    private void Start()
    {
        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(stayOnSceneTime);
        SceneManager.LoadScene(WormHoleLoader.NextLevel);
    }

}
