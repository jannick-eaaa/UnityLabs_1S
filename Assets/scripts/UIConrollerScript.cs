using UnityEngine;
using UnityEngine.UIElements;

public class UIConrollerScript : MonoBehaviour
{
    [SerializeField]
    UIDocument uiDocument;

    VisualElement uiRoot;
    Label dialogueLabel;

    void Start()
    {
        uiRoot = uiDocument.rootVisualElement;
        dialogueLabel = uiRoot.Q<Label>("dialogue");
        dialogueLabel.visible = false;

        VisualElement inventoryElement = uiRoot.Q<VisualElement>("brick");
        inventoryElement.visible = false;
    }

    public void aquireInventory(string name) {
        VisualElement inventoryElement = uiRoot.Q<VisualElement>(name);
        inventoryElement.visible = true;
    }

    public void setDialogueText(string npcName, string text) {
        dialogueLabel.text = npcName + " says: " + text;
        dialogueLabel.visible = true;
    }

    public void hideDialogueText(){
        dialogueLabel.visible = false;
    }
}
