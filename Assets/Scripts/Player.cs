using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
	public Animator anim;
	public GameObject panel_gameover;
	private int count = 0;
	private int lives = 0;
	public Text text_count;
	public GameObject[] live;
	public Button[] btn;
	public AudioSource aud_fish;
	public AudioSource aud_buoy;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (PlayerPrefs.HasKey("language"))
		{
			text_count.text = "Score: " + count;
		}
		else
			text_count.text = "Счёт: " + count;
	}
	public void ActiveBtn()
	{
		btn[0].interactable = true;
		btn[1].interactable = true;
	}
	public void ClickTap()
	{
		anim.SetTrigger("player");
		btn[0].interactable = false;
		btn[1].interactable = false;
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.CompareTag("fish1"))
		{
			aud_fish.Play();
			Destroy(collision.gameObject);
			count += 1;
		}
		if (collision.collider.CompareTag("fish2"))
		{
			aud_fish.Play();
			Destroy(collision.gameObject);
			count += 2;
		}
		if (collision.collider.CompareTag("fish3"))
		{
			aud_fish.Play();
			Destroy(collision.gameObject);
			count += 3;
		}
		if (collision.collider.CompareTag("buoy"))
		{
			aud_buoy.Play();
			Destroy(collision.gameObject);
			lives++;
			if (lives == 1)
			{
				live[2].SetActive(false);
			}
			if (lives == 2)
			{
				live[1].SetActive(false);
			}
			if (lives == 3)
			{
				live[0].SetActive(false);
				Time.timeScale = 0f;
				FindObjectOfType<Game>().text_score.text += " " + count.ToString();
				PlayerPrefs.SetInt("record", count);
				if (PlayerPrefs.HasKey("max_record"))
				{
					if (count < PlayerPrefs.GetInt("max_record"))
					{
						FindObjectOfType<Game>().text_score_record.text += " " + PlayerPrefs.GetInt("max_record");
					}
					else
						FindObjectOfType<Game>().text_score_record.text += " " + count;
				}
				else
					FindObjectOfType<Game>().text_score_record.text += " " + count;

				PlayerPrefs.Save();
				panel_gameover.SetActive(true);
			}

		}
	}

}
