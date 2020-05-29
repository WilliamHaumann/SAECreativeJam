using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scenehandler : MonoBehaviour
{

    public CanvasGroup fadeCanvas;

    bool isCanvasActive;

    public float fadeTime;
    public bool switchScene;

    DialougeHandler dialougeHandler;

    private void Start()
    {
        fadeIn(fadeTime);
    }

    public void fadeIn(float fadetime)
    {
        LeanTween.alphaCanvas(fadeCanvas, 0, fadetime).setOnComplete(canvasActivator);
    }
    public void fadeOut(float fadetime)
    {

        if (!dialougeHandler.dialogueSource.isPlaying)
        {
            LeanTween.alphaCanvas(fadeCanvas, 1, fadetime).setOnComplete(() =>
            {
                canvasActivator();
                loadScene("GameScene");
            });
        }
       
    }
    public void canvasActivator()
    {

        if (isCanvasActive)
        {
            fadeCanvas.gameObject.SetActive(false);
        }
        else
        {
            fadeCanvas.gameObject.SetActive(true);
        }
    }
    public void loadScene(string sceneToLoad)
    {
        Debug.Log("LoadingScene");
        SceneManager.LoadScene(sceneToLoad);
    }
}
