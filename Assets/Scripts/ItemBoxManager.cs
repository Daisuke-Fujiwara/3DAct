using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemBoxManager : MonoBehaviour
{
    [SerializeField] ItemSO itemSO;
    [SerializeField] GameObject player;
    [SerializeField] GameObject inventory;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int[] itemQtyArray;
    // Start is called before the first frame update
    void Start()
    {
        itemQtyArray = new int[itemSO.ItemList.Count];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetItem(int itemNo)
    {
        itemQtyArray[itemNo] += 1;
    }

    public void UseItem(int itemNo)
    {
        if (itemQtyArray[itemNo] <= 0) return;

        var itemType = itemSO.ItemList[itemNo].ItemTypeName.ToString();

        switch (itemType)
        {
            case "recovery":
                if (player.GetComponent<PlayerStatusManager>().currentHP == playerStatusSO.HP)
                {
                    break;
                }
                if (player.GetComponent<PlayerStatusManager>().currentHP + itemSO.ItemList[itemNo].ItemEffect > playerStatusSO.HP )
                {
                    player.GetComponent<PlayerStatusManager>().currentHP = playerStatusSO.HP;
                }
                else
                {
                    player.GetComponent<PlayerStatusManager>().currentHP += itemSO.ItemList[itemNo].ItemEffect;
                }
                GetComponent<AudioSource>().Play();
                itemQtyArray[itemNo] -= 1;
                inventory.GetComponent<InventoryWindowManager>().DisplayStatus();
                break;
            default:
                break;
        }


    }
}
