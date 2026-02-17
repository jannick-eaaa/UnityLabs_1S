using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastSurvival : MonoBehaviour
{
    Transform carriedSurvivalObject;

    [SerializeField]
    Transform carriedObjectAnchor;

    Transform oldObjectAnchor;


    void GrabSurvivalObject(Transform SurvivalObject) {
        if (carriedSurvivalObject){
            return;
        }

        carriedSurvivalObject = SurvivalObject;
        oldObjectAnchor = SurvivalObject.parent;
        carriedSurvivalObject.GetComponent<Rigidbody>().isKinematic = true;
        carriedSurvivalObject.GetComponent<BoxCollider>().enabled = false;

        carriedSurvivalObject.SetParent(carriedObjectAnchor);
        carriedSurvivalObject.localPosition = Vector3.zero;
        carriedSurvivalObject.localRotation = Quaternion.identity;
    }

    public Transform DropCarriedObject(){
        // Har vi noge vi kan droppe?????????????
        if (!carriedSurvivalObject){
            return null;
        }

        Transform survivalObject = carriedSurvivalObject;
        survivalObject.SetParent(oldObjectAnchor);
        survivalObject.GetComponent<Rigidbody>().isKinematic = false;
        survivalObject.GetComponent<BoxCollider>().enabled = true;
        survivalObject.localRotation = Quaternion.identity;

        oldObjectAnchor = null;
        carriedSurvivalObject = null;

        return survivalObject;
    }

    void Update() {
        if ( Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                if (hit.collider.CompareTag("water"))
                {
                    GrabSurvivalObject(hit.collider.transform);
                }
            }
        } else if (Mouse.current.rightButton.wasPressedThisFrame){
            DropCarriedObject();
        }
    }
}