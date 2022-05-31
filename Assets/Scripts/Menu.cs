using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject language_rus;
    public GameObject language_eng;
    public GameObject vibration_on;
    public GameObject vibration_off;
    public Text text_play;
    public Text text_rating;
    public Text text_setting;
    public Text text_name_rating;
    public Text text_name_setting;
    public Text text_score1;
    public Text text_score2;
    public Text text_score3;
    private int[] array_record;
    // Start is called before the first frame update
    void Start()
    {
	array_record = new int[4];
        if (PlayerPrefs.HasKey("vibrate"))
        {
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }
        else
        {
            vibration_on.SetActive(true);
            vibration_off.SetActive(false);
        }
        if (PlayerPrefs.HasKey("language"))
        {
            Translate();
            language_rus.SetActive(false);
            language_eng.SetActive(true);
        }
        else
        {
            language_rus.SetActive(true);
            language_eng.SetActive(false);
        }
	if (PlayerPrefs.HasKey("record"))
        {
            array_record[3] = PlayerPrefs.GetInt("record");
            PlayerPrefs.DeleteKey("record");
        }
        else
            array_record[3] = 0;

	for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.HasKey("r" + i.ToString()))
            {
                array_record[i] = PlayerPrefs.GetInt("r" + i.ToString());
            }
            else
                array_record[i] = 0;
	}
	sort();
        for(int i = 0; i < 3; i++)
        {
            PlayerPrefs.SetInt("r" + i.ToString(), array_record[i]);
        }
	text_score1.text="1. " + array_record[0];
	text_score2.text="2. " + array_record[1];
	text_score3.text="3. " + array_record[2];
    }
    private void sort()
    {
        for (int j = 0; j < array_record.Length; j++)
            for (int k = 0; k < array_record.Length - 1; k++)
            {
                if (array_record[k] < array_record[k + 1])
                {
                    int temp = array_record[k];
                    array_record[k] = array_record[k + 1];
                    array_record[k + 1] = temp;
                }
            }
    }
    private void Translate()
    {
        text_play.text = "Play";
        text_rating.text = "Rating";
        text_setting.text = "Settings";
        text_name_rating.text = "Best Players";
        text_name_setting.text = "Settings";
        //text_score1.text = "Player 1";
        //text_score2.text = "Player 2";
        //text_score3.text = "Player 3";
    }
    private void Translate_rus()
    {
        text_play.text = "Играть";
        text_rating.text = "Рейтинг";
        text_setting.text ="Настройки";
        text_name_rating.text = "Лучшие игроки";
        text_name_setting.text = "Настройки";
        //text_score1.text = "Игрок 1";
        //text_score2.text = "Игрок 2";
        //text_score3.text = "Игрок 3";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
   public void ClickPlay(){
	PlayerPrefs.SetInt("max_record", array_record[0]);
	SceneManager.LoadScene(1);
}
    public void PlayVibrate()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            Handheld.Vibrate();
        }
    }
    public void Vibration_on()
    {
        if (!PlayerPrefs.HasKey("vibrate"))
        {
            PlayerPrefs.SetInt("vibrate", 1);
            PlayerPrefs.Save();
            vibration_on.SetActive(false);
            vibration_off.SetActive(true);
        }
    }
    public void Vibration_off()
    {
        if (PlayerPrefs.HasKey("vibrate"))
        {
            PlayerPrefs.DeleteKey("vibrate");
            Handheld.Vibrate();
            vibration_on.SetActive(true);
            vibration_off.SetActive(false);
        }
    }
    public void Language_rus()
    {
        if (!PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.SetInt("language", 1);
            PlayerPrefs.Save();
            if (!PlayerPrefs.HasKey("vibrate"))
            {
                Handheld.Vibrate();
            }
            Translate();
            language_rus.SetActive(false);
            language_eng.SetActive(true);
        }
    }
    public void Language_eng()
    {
        if (PlayerPrefs.HasKey("language"))
        {
            PlayerPrefs.DeleteKey("language");
            if (!PlayerPrefs.HasKey("vibrate"))
            {
                Handheld.Vibrate();
            }
            Translate_rus();
            language_rus.SetActive(true);
            language_eng.SetActive(false);
        }
    }
}
