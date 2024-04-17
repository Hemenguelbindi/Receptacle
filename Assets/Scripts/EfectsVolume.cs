using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class EfectsVolume : MonoBehaviour
{

    [SerializeField] private AudioSource audioMixer;
    [SerializeField] private Slider _efectsVolume;
    private bool _isPlaying = false;


    void Awake()
    {
        if (PlayerPrefs.HasKey("efects"))
        {
            LoadVolume();
        }
        else
        {
            SetVolume();
        }
    }

    public void SetVolume()
    {
        float volume = _efectsVolume.value;
        audioMixer.volume = volume;
        PlayerPrefs.SetFloat("efects", volume);
    }

    void LoadVolume()
    {
        _efectsVolume.value = PlayerPrefs.GetFloat("efects");

        SetVolume();
        _isPlaying = true;
    }
}