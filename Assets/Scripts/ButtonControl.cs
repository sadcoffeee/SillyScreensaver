using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{
    public Slider volumeSlider;
    bool visible = false;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("volume"))
        {
            PlayerPrefs.SetFloat("volume", 0.2f);
            LoadVolume();
        }
        else
        {
            LoadVolume();
        }
    }

   public void UpdateVolume()
    {
        AudioListener.volume = volumeSlider.value;
        SaveVolume();
    }
    public void toggleGraphics()
    {
        if (!visible)
        {
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
            visible = true;
        }
        else 
        { 
            foreach (Transform child in transform) 
            { 
                child.gameObject.SetActive(false); 
            } 
            visible = false;
        }
    }

    public void SaveVolume()
    {
        PlayerPrefs.SetFloat("volume", volumeSlider.value);
    }
    public void LoadVolume()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("volume");
        AudioListener.volume = volumeSlider.value;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void loadScene(string loadedScene)
    {
        SceneManager.LoadScene(loadedScene);
    }
    public void openURL(string URL)
    {
        Application.OpenURL(URL);
    }
}
