using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lock : MonoBehaviour
{

    public UnityEvent lockEvent;

    public string Key; // Name the gameobject you want to unlock this item

    public int bombPieces = 0;
    public int maxPieces = 3;


    // Start is called before the first frame update
    void Start()
    {

    }
    // make functions here for the events you want to have    
    public void Destroy()
    {
        Destroy(gameObject);
    }

    public void AddToBombPieceCount()
    {
        bombPieces++;
        if(bombPieces >= maxPieces)
        {
            Debug.Log("I have all my pieces");
        }
    }
}
