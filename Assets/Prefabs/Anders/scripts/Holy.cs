using UnityEngine;

public class Holy : MonoBehaviour
{
    Light lightUp;
    AudioSource holyAudio;
    // Start is 
    // lcalled once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lightUp = GetComponent<Light>();
        lightUp.enabled = false;
        holyAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        lightUp.enabled = true;
        holyAudio.Play();
    }
    void OnTriggerExit(Collider collider)
    {
        lightUp.enabled = false;
        holyAudio.Stop();
    }
}
