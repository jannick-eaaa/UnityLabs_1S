using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField]
    string itemName;

    [SerializeField]
    UIConrollerScript uiControllerScript;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player")) 
        { 
            uiControllerScript.aquireInventory(itemName);
            Inventory.addItem(itemName);
            gameObject.SetActive(false);
        } 
    } 
}
