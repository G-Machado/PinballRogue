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
        if (SceneLoaderManager.instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        instance = this;
        currentIndex = SceneManager.GetActiveScene().buildIndex;
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
        if (isLoading) return;
        isLoading = true;

        if (currentIndex >= SceneManager.sceneCountInBuildSettings-1) 
        {
            currentIndex = 0;
        }
        else
        {
            currentIndex++;
        }

        CameraPixellation.instance.PlayFadeOut();
    }
    private void HandleScreenFaded()
    {
        isLoading = false;
        Debug.Log(currentIndex);
        LoadScence(currentIndex);
        CameraPixellation.instance.PlayFadeIn();
    }

    private void TriggerSceneReload()
    {
        if (isLoading) return;
        isLoading = true;
        CameraPixellation.instance.PlayFadeOut();
    }
    public void TriggerSceneOver()
    {
        if (isLoading) return;
        isLoading = true;

        currentIndex = SceneManager.sceneCountInBuildSettings - 1;
        CameraPixellation.instance.PlayFadeOut();
    }
}
