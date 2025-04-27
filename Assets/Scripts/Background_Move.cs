using UnityEngine;

public class Background_Move : MonoBehaviour
{
    [SerializeField] private float scrollMultiplier = 0.5f;
    private Renderer _renderer;
    private Vector2 offset;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        if (_renderer == null)
        {
            Debug.LogError("Renderer not found on background!");
        }
    }

    private void Update()
    {
        offset.x += scrollMultiplier * Time.deltaTime;
        _renderer.material.mainTextureOffset = offset;
    }
}
