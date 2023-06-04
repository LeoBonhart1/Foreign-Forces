using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuContrller : MonoBehaviour
{
  [Header("Volume Setting")]
  [SerializeField] private TMP_Text volumeTextValue = null;
  [SerializeField] private Slider volumeSlider = null;

  [Header("Confirmation")]
  [SerializeField] private GameObject confirmationPrompt = null;
  
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
   
  
}
