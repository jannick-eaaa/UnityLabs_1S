using UnityEngine;

public class WaterHandler : MonoBehaviour
{

    public Color emissionColor = new Color(0f, 1f, 0f);

    [SerializeField]
    float maxWaterLevel = 5f;

    float waterLevel;

    Material mat;

    void Start() {
        waterLevel = maxWaterLevel;

        // https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Material.SetColor.html
        mat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        mat.SetColor("_EmissionColor", emissionColor);
        if (waterLevel > 0f){
            waterLevel -= Time.deltaTime * 0.25f;
        }

        float percentageWaterLevel = waterLevel / maxWaterLevel;
        emissionColor.g = percentageWaterLevel;
        emissionColor.r = 1 - percentageWaterLevel;
    }

    public void add(float amount) {
        // waterLevel = waterLevel + amount
        waterLevel += amount;
    }
}
