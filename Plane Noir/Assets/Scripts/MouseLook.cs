using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public PlayerMovement player;
    public InventoryHandler inventoryManager;

    private float xRotation = 0f;

    public int inventorySpot = 1;

    // Start is called before the first frame update
    void Start()
    {


        LeanTween.init(100);
        Cursor.lockState = CursorLockMode.Locked;

    }


    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        rayCaster();
    }
    public void rayCaster()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {

            RaycastHit hit;
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 5))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

                if (hit.transform.tag == "Key")
                {

                    Key currentKey = hit.transform.gameObject.GetComponent<Key>();

                    Debug.Log("Interacted");
                    hit.transform.gameObject.SetActive(false);
                    player.inventory.Add(hit.transform.gameObject.name);
                    inventoryManager.activateImage(inventorySpot);
                    inventoryManager.inventoryImage[inventorySpot].sprite = currentKey.inventorySprite;
                    inventorySpot++;
                    //Preform interactble logic
                    // Might check for special logic 
                }
                else if (hit.transform.tag == "Lock")
                {

                    Lock targetLock = hit.transform.gameObject.GetComponent<Lock>();

                    if (player.inventory.Contains(targetLock.Key))
                    {
                        int arrayId = player.inventory.IndexOf(targetLock.Key);
                        player.inventory.Remove(targetLock.Key);
                        inventoryManager.deactivateImage(arrayId);
                        targetLock.lockEvent.Invoke();
                    }


                }
            }
        }
    }
}
