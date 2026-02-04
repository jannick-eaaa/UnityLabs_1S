using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastPuzzle : MonoBehaviour
{
    Transform carriedPuzzleObject;

    [SerializeField]
    Transform carriedObjectAnchor;

    Transform oldObjectAnchor;


    void GrabPuzzleObject(Transform puzzleObject) {
        if (carriedPuzzleObject){
            return;
        }

        carriedPuzzleObject = puzzleObject;
        oldObjectAnchor = puzzleObject.parent;
        carriedPuzzleObject.GetComponent<Rigidbody>().isKinematic = true;
        carriedPuzzleObject.GetComponent<BoxCollider>().enabled = false;

        carriedPuzzleObject.SetParent(carriedObjectAnchor);
        carriedPuzzleObject.localPosition = Vector3.zero;
        carriedPuzzleObject.localRotation = Quaternion.identity;
    }

    public Transform DropCarriedObject(){
        // Har vi noge vi kan droppe?????????????
        if (!carriedPuzzleObject){
            return null;
        }

        Transform puzzleObject = carriedPuzzleObject;
        puzzleObject.SetParent(oldObjectAnchor);
        puzzleObject.GetComponent<Rigidbody>().isKinematic = false;
        puzzleObject.GetComponent<BoxCollider>().enabled = true;
        puzzleObject.localRotation = Quaternion.identity;

        oldObjectAnchor = null;
        carriedPuzzleObject = null;

        return puzzleObject;
    }

    void Update() {
        if ( Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                if (hit.collider.GetComponent<Puzzle>())
                {
                    GrabPuzzleObject(hit.collider.transform);
                }
            }
        } else if (Mouse.current.rightButton.wasPressedThisFrame){
            DropCarriedObject();
        }
    }
}