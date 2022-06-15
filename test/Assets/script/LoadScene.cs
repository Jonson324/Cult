using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class LoadScene : MonoBehaviour
{
    public Text Loadtext;


    public static LoadScene instance;
    private Animator Componentanimator;
    private AsyncOperation loadingSceneOperation;
    private static bool shoutPlayerOpenAnimation = false;
    

    public static void SwitchToScene(string scenename)
    {
        instance.Componentanimator.SetTrigger(name: "Openning");

        instance.loadingSceneOperation = SceneManager.LoadSceneAsync(scenename);
        instance.loadingSceneOperation.allowSceneActivation = false;
    }

    private void Start()
    {
        instance = this;
        Componentanimator = GetComponent<Animator>();

        if (shoutPlayerOpenAnimation) Componentanimator.SetTrigger(name: "End");
    }

    private void Update()
    {
        if (loadingSceneOperation != null)
        {
            Loadtext.text = Mathf.RoundToInt(loadingSceneOperation.progress * 100) + "%";
        }
    }

    public void OnAnimationOver()
    {
        loadingSceneOperation.allowSceneActivation = true;
    }
}
