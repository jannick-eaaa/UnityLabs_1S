using UnityEngine;

public class NPCDialogueScript : MonoBehaviour
{

    [SerializeField]
    UIConrollerScript uiControllerScript;

    [SerializeField]
    [TextArea(3, 10)]
    string dialogue;
    [SerializeField]
    [TextArea(3, 10)]
    string dialogueOnItem;
    [SerializeField]
    [TextArea(3, 10)]
    string dialogueOnRevisit;

    bool hasBeenHelped = false;

    void OnTriggerEnter2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        { 
            if (Inventory.hasItem("brick") && !hasBeenHelped){
                uiControllerScript.setDialogueText(gameObject.name, dialogueOnItem);
                hasBeenHelped = true;
            } else if (hasBeenHelped) {
                uiControllerScript.setDialogueText(gameObject.name, dialogueOnRevisit);
            } else {
                uiControllerScript.setDialogueText(gameObject.name, dialogue);
            }
        } 
    } 

    void OnTriggerExit2D(Collider2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        { 
            uiControllerScript.hideDialogueText();
        } 
    } 
}
