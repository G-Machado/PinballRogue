using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPixellation : MonoBehaviour
{
    [SerializeField] private RenderTexture pixelTexture;
    [SerializeField] private Vector2 referenceSize;
    [Range(0,10)]
    [SerializeField] private float pixelationFactor;
    [SerializeField] private Animator pixelAnimator;

    void Update()
    {
        Vector2 finalSize = referenceSize * pixelationFactor * .1f;
        pixelTexture.Release();
        pixelTexture.width = (int) finalSize.x;
        pixelTexture.height = (int) finalSize.y;

        if(Input.GetKey(KeyCode.P))
        {
            pixelAnimator.Play("Pixel_Collision");
        }
    }
}
