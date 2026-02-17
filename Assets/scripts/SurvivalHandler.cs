using UnityEngine;


public class SurvivalHandler : MonoBehaviour
{
    Transform player;
    WaterHandler waterHandler;

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
        waterHandler = GetComponent<WaterHandler>();
    }

    void Update() {
        if (Vector3.Distance(transform.position, player.position) <= 1.5f){
            Transform puzzleObject = player.GetComponentInChildren<RaycastSurvival>().DropCarriedObject();

            if (puzzleObject){
                if (puzzleObject.tag == "water"){
                    // Handle Water
                    waterHandler.add(3);
                } else if (puzzleObject.tag == "food"){
                    // Handle Food
                } else {
                    // Handle Other
                }
                Destroy(puzzleObject.gameObject);
            }
        }
    }
}