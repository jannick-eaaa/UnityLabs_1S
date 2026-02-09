using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    Light spotLight;

    [SerializeField]
    float maxLightDelayTime = 3f;

    float lightFlickerTimer = 0f;

    [SerializeField]
    float lightFlickerThreshold = 0.2f;
    
    float lightFlickerInterval = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spotLight = GetComponent<Light>();
        lightFlickerTimer = Random.Range(0f, maxLightDelayTime);
    }

    // Update is called once per frame
    void Update()
    {
        lightFlickerTimer += Time.deltaTime;
        if (lightFlickerTimer > maxLightDelayTime){
            lightFlickerInterval += Time.deltaTime;
            if (lightFlickerInterval > lightFlickerThreshold){
                spotLight.intensity = Random.Range(0f, 1f);
                lightFlickerInterval = 0f;
            }

            if (lightFlickerTimer > maxLightDelayTime + 1f){
                lightFlickerTimer = Random.Range(0f, maxLightDelayTime);
                lightFlickerInterval = 0f;
                spotLight.intensity = 1f;
            }
        }
    }
}
