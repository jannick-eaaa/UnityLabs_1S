using UnityEngine;

public class Holy : MonoBehaviour
{
    public Light lightUp;
    // Start is 
    // lcalled once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightUp = GetComponent<Light>();
        lightUp.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collidor)
    {
        lightUp.enabled = true;
    }
}
