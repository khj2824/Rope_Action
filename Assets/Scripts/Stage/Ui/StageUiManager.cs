using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class StageUiManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject optionpanel;
    public GameObject Player;
    public GameObject ResultPanel;
    public List<Sprite> Number;
    public List<Image> Score;

    int Player_y;
    int finalscore;
    void Start()
    {
        Score[0].gameObject.SetActive(true);
        optionpanel.SetActive(false);
        finalscore = 0;
    }
    
    void Update()
    {
        Player_y = (int)Player.transform.position.y;
        if(Player_y>finalscore)
        {
            finalscore = Player_y;
            Result();
        }

        ResultPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Score : " + finalscore.ToString();
        ResultPanel.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Gain Coint : " + (finalscore / 10).ToString();
    }

    void Result()
    {
        int count = 0;
        while(true)
        {
            if (finalscore / ((int)Mathf.Pow(10 , count)) != 0)
                count++;
            else break;
        }
        for(int i=0;i<count;i++)
        {
            Score[i].gameObject.SetActive(true);
            Score[i].sprite = Number[(finalscore / (int)Mathf.Pow(10, i)) % 10];
        }
    }

    public void Option()
    {
        if (optionpanel.activeSelf == true)
        {
            Time.timeScale = 1;
            optionpanel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            optionpanel.SetActive(true);
        }
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        ResultPanel.SetActive(false);
    }
}
