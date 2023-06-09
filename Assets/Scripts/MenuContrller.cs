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
  [SerializeField] private TMP_Dropdown resolutionDropdown;

  private Resolution[] resolutions;
  private List<Resolution> filteredResolutions;

  private int currentResolutionIndex = 0;
  private float currentRefreshRate;

  private int qualityLevel;
  private bool isFullScreen;
  private float brightnessLevel;

  private void Start()
  {
    resolutions = Screen.resolutions;
    filteredResolutions = new List<Resolution>();

    resolutionDropdown.ClearOptions();
    currentRefreshRate = Screen.currentResolution.refreshRate;

    for (int i = 0; i < resolutions.Length; i++)
    {
        if (resolutions[i].refreshRate == currentRefreshRate)
        {
            filteredResolutions.Add(resolutions[i]);
        }
    }

    List<string> options = new List<string>();
    for (int i = 0; i < filteredResolutions.Count; i++)
    {
      string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
      options.Add(resolutionOption);
      if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
      {
          currentResolutionIndex = i;
      }
    }

    resolutionDropdown.AddOptions(options);
    resolutionDropdown.value = currentResolutionIndex;
    
  }

  public void SetResolution(int resolutionIndex)
  {
     Resolution resolution = filteredResolutions[resolutionIndex];
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
