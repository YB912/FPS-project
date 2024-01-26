using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Controller : MonoBehaviour
{
    public GameObject _settingPanel, _exitButton, _audioSlider, _exitButton2, _aboutUsPanel;
    public AudioSource _audioSource;
    private bool _isPlaying = false;


    void Start()
    {
        _audioSource = this.GetComponent<AudioSource>();
    }

    void Update()
    {
        _audioSource.volume = _audioSlider.GetComponent<Slider>().value;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }
    public void SettingButton()
    {
        _settingPanel.SetActive(true);
        _exitButton.SetActive(true);
    }
    public void AboutUsButton()
    {
        _exitButton2.SetActive(true);
        _aboutUsPanel.SetActive(true);
    }
    public void ExitButton()
    {
        _exitButton.SetActive(false);
        _settingPanel.SetActive(false);
    }
    public void ExitButton2()
    {
        _exitButton2.SetActive(false);
        _aboutUsPanel.SetActive(false);
    }

    public void AudioButton()
    {
        if( _isPlaying == false )
        {
            _audioSource.Play();
            _isPlaying = true;
        }
        else if( _isPlaying == true )
        {
            _audioSource.Stop();
            _isPlaying = false;
        }

    }
   
}
