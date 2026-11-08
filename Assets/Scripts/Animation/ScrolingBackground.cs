using UnityEngine;

public class ScrolingBackground : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.1f;
    [SerializeField] private Renderer _backgroundRenderer;

    // Update is called once per frame
    void Update()
    {
        _backgroundRenderer.material.mainTextureOffset += new Vector2(_scrollSpeed * Time.deltaTime, 0);
    }
}
