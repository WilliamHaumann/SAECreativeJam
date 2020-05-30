using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{

    public UnityEvent lockEvent;

    public string Key; // Name the gameobject you want to unlock this item

    private int bombPieces = 0;
    private int maxPieces = 3;

    public int siloCount = 0;
    public int maxSilos = 4;

    private bool hasToolkit = false;

    public Scenehandler sceneHandler;
    public DialougeHandler dialougeHandler;
    public MouseLook mouseScript;

    public int audioClipIndex;


    // Start is called before the first frame update
    void Start()
    {
        //sceneChanger = GetComponent<Scenehandler>();
    }


    // make functions here for the events you want to have    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AddToBombPieceCount()
    {

        Debug.Log("I have all my pieces");
        dialougeHandler.playAudioClip(4);
        Invoke("switchToScene2", dialougeHandler.AudioClipArray[4].length);

    }
    public void switchToScene2()
    {
        if (!dialougeHandler.dialogueSource.isPlaying)
        {
            dialougeHandler.playAudioClip(5);
            dialougeHandler.clipIsPlaying = true;
            sceneHandler.switchScene = true;

            mouseScript.scene2 = true;
        }

    }
    public void CheckForToolkit()
    {
        dialougeHandler.playAudioClip(3);
        Invoke("switchToScene3", dialougeHandler.AudioClipArray[3].length);
    }
    public void switchToScene3()
    {
        if (!dialougeHandler.dialogueSource.isPlaying)
        {
            dialougeHandler.playAudioClip(4);
            dialougeHandler.clipIsPlaying = true;
            sceneHandler.switchScene = true;

            mouseScript.scene3 = true;
        }

    }

    public void CheckForCorrectItem()
    {
        siloCount++;

        dialougeHandler.playAudioClip(audioClipIndex);
        if(siloCount >= maxSilos)
        {
            Invoke("switchToEndGame", dialougeHandler.AudioClipArray[audioClipIndex].length);
        }
    }
    public void SwitchToEndGame()
    {
        if (!dialougeHandler.dialogueSource.isPlaying)
        {
            dialougeHandler.playAudioClip(4);
            dialougeHandler.clipIsPlaying = true;
            sceneHandler.switchScene = true;

            mouseScript.scene3 = true;
        }

    }
}
