using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoaderManager : MonoBehaviour
{
    public static SceneLoaderManager instance;
    [SerializeField] private int initialIndex = 0;
    [SerializeField] private CameraPixellation cameraPixelation;
    private int currentIndex;
    private bool isLoading = false; 
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        instance = this;
        currentIndex = initialIndex;
    }

    private void OnEnable()
    {
        cameraPixelation.OnScreenFaded += HandleScreenFaded;
    }

    private void OnDisable()
    {
        cameraPixelation.OnScreenFaded -= HandleScreenFaded;
    }

    public void LoadScence(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void TriggerNextSceneLoad()
    {
        if (currentIndex >= SceneManager.sceneCountInBuildSettings-1) return;
        if (isLoading) return;

        currentIndex++;

        isLoading = true;
        CameraPixellation.instance.PlayFadeOut();
    }
    private void HandleScreenFaded()
    {
        isLoading = false;
        LoadScence(currentIndex);
        CameraPixellation.instance.PlayFadeIn();
    }
}
