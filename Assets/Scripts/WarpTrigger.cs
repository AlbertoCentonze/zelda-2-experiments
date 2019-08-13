using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WarpTrigger : MonoBehaviour
{
    public EncounterRule info;

    public IEnumerator LoadScene(int sceneIndex)
    {
        AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(sceneIndex);
        while (!sceneLoading.isDone)
        {
            Debug.Log(sceneLoading.progress);

            yield return null;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadScene(1));
            Debug.Log(1);
        }
    }
}
