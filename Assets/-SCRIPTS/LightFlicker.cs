using UnityEngine;

[RequireComponent(typeof(Light))]
public class LightFlicker : MonoBehaviour
{
    [Header("Flicker Settings")]
    [Tooltip("Base brightness of the torch.")]
    public float baseIntensity = 2f;

    [Tooltip("How much the intensity can vary above and below the base.")]
    public float flickerAmplitude = 0.5f;

    [Tooltip("How fast the flicker changes (higher = faster changes).")]
    public float flickerSpeed = 2f;

    [Tooltip("Random offset for each torch so they don't sync up.")]
    public float randomOffset = 0f;

    private Light torchLight;
    public float noiseOffset;

    void Start()
    {
        torchLight = GetComponent<Light>();
        noiseOffset = Random.Range(0f, 100f); // ensures each torch flickers differently
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(noiseOffset, Time.time * flickerSpeed);
        float intensity = baseIntensity + (noise - 0.5f) * 2f * flickerAmplitude;
        torchLight.intensity = intensity;
    }
}
