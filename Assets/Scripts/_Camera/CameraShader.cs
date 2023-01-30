using UnityEngine;

[ExecuteInEditMode]
public class CameraShader : MonoBehaviour
{
    [SerializeField] Material material;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
