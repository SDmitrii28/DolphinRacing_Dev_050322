using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Volume_sounds : MonoBehaviour
{
    private int sound;
    public GameObject btn_on;
    public GameObject btn_off;
    public string tag_volume;
    public string tag_mixer;
    //public AudioSource aud;
    public AudioMixerGroup mixer;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(tag_volume))
        {
            sound = PlayerPrefs.GetInt(tag_volume);
        }
        else
            sound = 0;
        //////////////////
        if (sound == 0)
        {
            Off();
        }
        if (sound == 1)
        {
            On();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Click_on()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            Handheld.Vibrate();
        }
        //aud.Play();
        sound = 1;
        On();
    }
    public void Click_off()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            Handheld.Vibrate();
        }
        //aud.Play();
        sound = 0;
        Off();
    }
    private void On()
    {
        mixer.audioMixer.SetFloat(tag_mixer, -80);
        PlayerPrefs.SetInt(tag_volume, sound);
        PlayerPrefs.Save();
        btn_on.SetActive(false);
        btn_off.SetActive(true);
    }
    private void Off()
    { 
        mixer.audioMixer.SetFloat(tag_mixer, 0);
        PlayerPrefs.SetInt(tag_volume, sound);
        PlayerPrefs.Save();
        btn_on.SetActive(true);
        btn_off.SetActive(false);
    }
}
