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
    public Text Score;

    int Player_y;
    int finalscore;
    void Start()
    {
        optionpanel.SetActive(false);
        finalscore = 0;
    }
    
    void Update()
    {
        Player_y = (int)Player.transform.position.y;
        if(Player_y>finalscore)
        {
            finalscore = Player_y;
            Score.text = finalscore.ToString();
        }

        ResultPanel.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = "Score : " + finalscore.ToString();
        ResultPanel.transform.GetChild(0).GetChild(2).GetComponent<Text>().text = "Gain Coint : " + (finalscore / 10).ToString();
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
