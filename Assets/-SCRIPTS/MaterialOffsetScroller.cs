using UnityEngine;

public class MaterialOffsetScroller : MonoBehaviour
{
    [Header("Scrolling Settings")]
    [Tooltip("How fast to scroll the texture in the X direction.")]
    public float scrollSpeedX = 0.5f;

    [Tooltip("How fast to scroll the texture in the Y direction.")]
    public float scrollSpeedY = 0.0f;

    [Tooltip("Whether to use a shared material or an instance.")]
    public bool useSharedMaterial = false;

    private Renderer rend;
    private Material mat;
    private Vector2 offset;

    void Start()
    {
        rend = GetComponent<Renderer>();

        // Choose whether to modify the shared or instance material
        mat = useSharedMaterial ? rend.sharedMaterial : rend.material;

        // Start with the current offset
        offset = mat.mainTextureOffset;
    }

    void Update()
    {
        offset.x += scrollSpeedX * Time.deltaTime;
        offset.y += scrollSpeedY * Time.deltaTime;

        // Keep offset looping between 0–1
        if (offset.x > 1f) offset.x -= 1f;
        if (offset.y > 1f) offset.y -= 1f;

        mat.mainTextureOffset = offset;
    }
}
