using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryHandler : MonoBehaviour
{

    public List<Image> inventoryImage = new List<Image>();

 
    public void activateImage(int arrayId)
    {
        inventoryImage[arrayId].gameObject.SetActive(true);
    }
    public void deactivateImage(int arrayId)
    {
        inventoryImage[arrayId].gameObject.SetActive(false);
    }
}
