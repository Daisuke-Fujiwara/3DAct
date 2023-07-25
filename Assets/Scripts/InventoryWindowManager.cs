using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InventoryWindowManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpValue;
    [SerializeField] TextMeshProUGUI potionValue;
    [SerializeField] PlayerStatusSO playerStatusSO;
    [SerializeField] GameObject statusWindow;
    [SerializeField] GameObject player;
    [SerializeField] GameObject itemBoxManager;
    private bool isActiveWindow = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        hpValue.SetText(playerStatusSO.HP.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            GameObject cam = GameObject.Find("PlayerCamera");
            Transform camera = cam.transform.Find("CM vcam1");
            switch (isActiveWindow)
            {
                case false:
                    camera.gameObject.SetActive(false);
                    Cursor.lockState = CursorLockMode.Confined;
                    DisplayStatus();
                    statusWindow.SetActive(true);
                    Time.timeScale = 0;
                    isActiveWindow = true;
                    break;
                case true:
                    camera.gameObject.SetActive(true);
                    Cursor.lockState = CursorLockMode.Locked;
                    statusWindow.SetActive(false);
                    Time.timeScale = 1;
                    isActiveWindow = false;
                    break;
            }
        }
    }

    public void DisplayStatus()
    {
        hpValue.SetText(player.GetComponent<PlayerStatusManager>().currentHP.ToString()) ;
        potionValue.SetText(itemBoxManager.GetComponent<ItemBoxManager>().itemQtyArray[0].ToString());
    }
}
