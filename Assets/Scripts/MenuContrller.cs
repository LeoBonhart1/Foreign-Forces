using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuContrller : MonoBehaviour
{

  [Header("Volume Settings")]
  [SerializeField] private TMP_Text volumeTextValue = null;
  [SerializeField] private Slider volumeSlider = null;

  [Header("Graphic Settings")]
  [SerializeField] private TMP_Text brightnessTextValue = null;
  [SerializeField] private Slider brightnessSlider = null;
  [SerializeField] private float defaultBrightness = 1;

  [Header("Resolution Dropdown")]
  public TMP_Dropdown resolutionDropdown;
  private Resolution[] resolutions;

  private int qualityLevel;
  private bool isFullScreen;
  private float brightnessLevel;

  private void Start()
  {
    resolutions = Screen.resolutions;
    resolutionDropdown.ClearOptions();

    List<string> options = new List<string>();

    int currentResolutionIndex = 0;

    for (int i = 0; i< resolutions.Length; i++)
    {
       string option = resolutions[i].width + " x " + resolutions[i].height;
       options.Add(option);

       if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
       {
          currentResolutionIndex =i;
       }
    }

  }

  public void SetResolution(int resolutionIndex)
  {
     Resolution resolution = resolutions[resolutionIndex];
     Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
  }

  public void StartGame()
  {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }

  public void QuitGame()
  {
    Application.Quit();
  }  
      
  public void SetVolume(float volume)
  {
    AudioListener.volume = volume;
    volumeTextValue.text = volume.ToString("0.0");
  }    
  
  public void SetBrightness(float brightness)
  {
    brightnessLevel = brightness;
    brightnessTextValue.text = brightness.ToString("0.0");
  }

  public void SetFullScreen(bool isFullscreen) 
  {
    isFullScreen = isFullscreen;
  }
  
  public void SetQuality(int qualityIndex)
  {
    qualityLevel = qualityIndex;
  }

  public void GraphicsApply()
  {
    PlayerPrefs.SetFloat("masterBrightness",brightnessLevel);

    PlayerPrefs.SetInt("masterQuality", qualityLevel);
    QualitySettings.SetQualityLevel(qualityLevel);

    PlayerPrefs.SetInt("masterFullscreen",(isFullScreen ? 1 : 0));
    Screen.fullScreen = isFullScreen;
  }
}
