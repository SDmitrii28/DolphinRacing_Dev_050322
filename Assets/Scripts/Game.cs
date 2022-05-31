using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Game : MonoBehaviour
{
    public Text text_score;
    public Text text_name_score;
    public Text text_score_record;
    //public Text text_name_rating;
    public Text text_menu;
    public GameObject[] tap;
    private int p = 0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        if (PlayerPrefs.HasKey("language"))
        {
            Translate();
        }
    }
    private void Translate()
    {
        text_score.text = "Your Score:";
        text_name_score.text = "Score:";
        text_score_record.text = "Your Record:";
        text_menu.text = "Menu:";
        //text_count.text="Score:";
        tap[0].SetActive(false);
        tap[1].SetActive(true);
    }
    public void ClickMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        if (p == 0)
        {
            p = 1;
            FindObjectOfType<Player>().btn[0].interactable = false;
            FindObjectOfType<Player>().btn[1].interactable = false;
            Time.timeScale = 0f;
        }
        else
        {
            FindObjectOfType<Player>().btn[0].interactable = true;
            FindObjectOfType<Player>().btn[1].interactable = true;
            p = 0;
            Time.timeScale = 1f;
        }

    }
}
