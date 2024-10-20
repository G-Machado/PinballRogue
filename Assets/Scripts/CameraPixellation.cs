using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraPixellation : MonoBehaviour
{
    public static CameraPixellation instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public Action OnScreenFaded;

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
            //pixelAnimator.Play("Pixel_Collision");
            SceneLoaderManager.instance.TriggerNextSceneLoad();
        }
    }

    public void TriggerScreenFaded()
    {
        OnScreenFaded?.Invoke();
    }

    public void PlayCollision()
    {
        pixelAnimator.Play("Pixel_Collision");
    }
    public void PlayFadeOut()
    {
        pixelAnimator.Play("Pixel_FadeOut");
    }
    public void PlayFadeIn()
    {
        pixelAnimator.Play("Pixel_FadeIn");
    }
    
}
