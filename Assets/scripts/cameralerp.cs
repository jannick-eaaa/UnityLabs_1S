using UnityEngine;

public enum CameraState
{
    Fixed,
    Follow,
    Orbit
}

public class cameralerp : MonoBehaviour
{
    [SerializeField]
    Transform fixedAnchor;

    [SerializeField]
    Transform followAnchor;

    [SerializeField]
    CameraState cameraState;

    float orbitTimer = 0f;
    float orbitRadius = 2f;

    public void setCameraState (CameraState state) {
        cameraState = state;
    }

    void Update()
    {
        switch(cameraState){
            case CameraState.Fixed:
                transform.position = fixedAnchor.position;
                transform.localRotation = fixedAnchor.localRotation;
                break;

            case CameraState.Follow:
                transform.position = Vector3.Lerp(transform.position, followAnchor.position, Time.deltaTime);
                break;

            case CameraState.Orbit:

                // Orbit using sine and cosine
                orbitTimer += Time.deltaTime;
                // Copy followanchor to a new variable
                Vector3 newPos = followAnchor.position;
                // We put some "offsets" into the new copy, so, followAnchor + the code below
                newPos.y += orbitRadius;
                newPos.x += Mathf.Cos(orbitTimer) * orbitRadius;
                newPos.z += Mathf.Sin(orbitTimer) * orbitRadius;

                // Lerp to calculated pos
                transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime);
                transform.LookAt(followAnchor);
                break;
        }
    }
}