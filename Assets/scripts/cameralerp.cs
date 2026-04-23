using UnityEngine;

public class cameralerp : MonoBehaviour
{
    [SerializeField]
    Transform anchor;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, anchor.position, Time.deltaTime);
    }
}
