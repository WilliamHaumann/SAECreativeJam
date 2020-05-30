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

    public DialougeHandler dialougeHandler;

    private bool seenBomb = false;
    private bool firstBombPiece = false;




    // Start is called before the first frame update
    void Start()
    {


        LeanTween.init(10000);
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

        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, 5))
        {

            Lock targetLock = hit.transform.gameObject.GetComponent<Lock>();
            Key currentKey = hit.transform.gameObject.GetComponent<Key>();

            //Continues Raycast
            #region
            if (hit.transform.name == "Bomb")
            {
                if (!seenBomb)
                {

                    dialougeHandler.playAudioClip(2);
                    seenBomb = true;

                }
            }

            #endregion
            // Mouse klick interactions
            if (Input.GetKey(KeyCode.Mouse0))
            {
                if (hit.transform.tag == "Silo")
                {

                    if (hit.transform.name == "David")
                    {


                    }

                }

                if (hit.transform.tag == "Key")
                {
                    dialougeHandler.playVFXSound(0);
                    if (!firstBombPiece)
                    {
                        dialougeHandler.playAudioClip(3);
                        firstBombPiece = true;
                    }
                    hit.transform.gameObject.SetActive(false);
                    player.inventory.Add(hit.transform.gameObject.name);
                    int arrayId = player.inventory.IndexOf(hit.transform.gameObject.name);
                    inventoryManager.activateImage(arrayId);
                    inventoryManager.inventoryImage[arrayId].sprite = currentKey.inventorySprite;

                }
                else if (hit.transform.tag == "Lock")
                {

                    if (player.inventory.Contains(targetLock.Key))
                    {
                        int arrayId = player.inventory.IndexOf(targetLock.Key);
                        player.inventory.Remove(targetLock.Key);
                        inventoryManager.deactivateImage(arrayId);
                        targetLock.lockEvent.Invoke();
                    }
                }
                else if (hit.transform.name == "Bomb")
                {

                    if (player.inventory.Contains("Bomb1") && player.inventory.Contains("Bomb2") && player.inventory.Contains("Bomb3"))
                    {

                        targetLock.AddToBombPieceCount();
                    }
                    else
                    {
                        dialougeHandler.playAudioClip(6); // add clip incase they don't have all peices
                    }
                }
            }
        }
    }
}
