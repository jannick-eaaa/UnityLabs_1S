using UnityEngine;


public class PuzzleHandler : MonoBehaviour
{
    [SerializeField]
    string correctObjectName;

    [SerializeField]
    Transform objectAnchor;
    
    Transform oldObjectAnchor;
    Transform player;

    Color whiteBG = new Color(1f, 1f, 1f);
    Color greenBG = new Color(0.5f, 1f, 0.5f);

    public void SetSolved(bool state) {
        Camera.main.backgroundColor = state ? greenBG : whiteBG;
    }

    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }

    void Update() {
        if (Vector3.Distance(transform.position, player.position) <= 1.5f){
            Transform puzzleObject = player.GetComponentInChildren<RaycastPuzzle>().DropCarriedObject();

            if (puzzleObject){
                oldObjectAnchor = puzzleObject.parent;
                puzzleObject.GetComponent<Rigidbody>().isKinematic = true;
                puzzleObject.position = objectAnchor.position;

                bool isSolved = puzzleObject.name == correctObjectName;

                SetSolved(isSolved);
            }
        }
    }
}