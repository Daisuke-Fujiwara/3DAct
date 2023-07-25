using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI hpText;
    [SerializeField] PlayerStatusSO playerStatusSO;
    public int currentHP;
    [SerializeField] GameObject itemBoxManager;
    // Start is called before the first frame update

    public AudioClip getClip;
    void Start()
    {
        hpText.SetText("HP : " + currentHP);
        currentHP = playerStatusSO.HP;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.SetText("HP : " + currentHP);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            currentHP -= 10;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            itemBoxManager.GetComponent<ItemBoxManager>().GetItem(other.gameObject.GetComponent<ItemManager>().itemNo);
            GetComponent<AudioSource>().PlayOneShot(getClip);
        }
    }
}
