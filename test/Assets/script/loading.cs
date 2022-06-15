using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loading : MonoBehaviour
{
    public int sceneID;
    public GameObject loadingScreen;
    public Slider loadSlider;

    private void Start()
    {
        loadingScreen.SetActive(true);

        StartCoroutine(LoadNextScene());
    }

    IEnumerator LoadNextScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
        while (!operation.isDone)
        {
            loadSlider.value = operation.progress;

            if(operation.progress >= .9f && !operation.allowSceneActivation)
            {
                yield return new WaitForSeconds(2.2f);
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
