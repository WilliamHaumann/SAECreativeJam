using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    public List<Image> inventoryImage = new List<Image>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void activateImage(int arrayId)
    {
        inventoryImage[arrayId].gameObject.SetActive(true);
    }
}
