using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainManager : MonoBehaviour
{
    public GameObject[] Panel;
    public AudioMixer audioMixer;
    public GameObject Characterlist;
    public CharacterData CharacterData;
    public int count = 0;
    public Text Coin;
    public Text Ruby;

    public static int powerRes = 0;
    public static int luckRes = 0;
    public static int shieldRes = 0;
    public static int countRes = 0;

    List<int> power = new List<int>();
    List<int> powerMax = new List<int>();
    List<int> luck = new List<int>();
    List<int> luckMax = new List<int>();
    List<int> shield = new List<int>();
    List<int> shieldMax = new List<int>();
    List<int> upgrade = new List<int>();

    int check;

    // Start is called before the first frame update
    void Start()
    {
        check = count;
        CharacterData = GameObject.Find("GameManager").GetComponent<CharacterData>();

        power = CharacterData._power;
        powerMax = CharacterData._powerMax;
        luck = CharacterData._luck;
        luckMax = CharacterData._luckMax;
        shield = CharacterData._shield;
        shieldMax = CharacterData._shieldMax;
        upgrade = CharacterData._upgrade;
        Coin.text = CharacterData.Coin_;
        Ruby.text = CharacterData.Ruby_;

        powerRes = power[count];
        luckRes = luck[count];
        shieldRes = shield[count];
        countRes = count;

        for (int i = 0; i < Characterlist.transform.childCount; i++)
        {
            //Power
            Characterlist.transform.GetChild(i).GetChild(0).GetChild(0).GetComponent<RectTransform>().
                sizeDelta = new Vector2(powerMax[i] * 30, 40);
            Characterlist.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<RectTransform>().
                sizeDelta = new Vector2(power[i] * 30, 40);
            //Luck
            Characterlist.transform.GetChild(i).GetChild(1).GetChild(0).GetComponent<RectTransform>().
                sizeDelta = new Vector2(luckMax[i] * 30, 40);
            Characterlist.transform.GetChild(i).GetChild(1).GetChild(1).GetComponent<RectTransform>().
                sizeDelta = new Vector2(luck[i] * 30, 40);
            //Shield
            Characterlist.transform.GetChild(i).GetChild(2).GetChild(0).GetComponent<RectTransform>().
                sizeDelta = new Vector2(shieldMax[i] * 30, 40);
            Characterlist.transform.GetChild(i).GetChild(2).GetChild(1).GetComponent<RectTransform>().
                sizeDelta = new Vector2(shield[i] * 30, 40);
            //name
            Characterlist.transform.GetChild(i).GetChild(7).GetComponent<Text>().
                text = CharacterData._name[i];
            //upgrade
            Characterlist.transform.GetChild(i).GetChild(6).GetChild(0).GetComponent<Text>().text =
                "Upgrade : " + (upgrade[i] * 500).ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (check != count)
        {
            powerRes = power[count];
            luckRes = luck[count];
            shieldRes = shield[count];
            countRes = count;
            check = count;
        }
    }

    public void start()
    {
        SceneManager.LoadScene(1);
    }

    public void Option()
    {
        Panel[1].SetActive(true);
    }

    public void OptionExit()
    {
        Panel[1].SetActive(false);
    }

    public void RubyIn()
    {
        Panel[0].SetActive(true);
    }

    public void RubyExit()
    {
        Panel[0].SetActive(false);
    }

    public void CoinIn()
    {
        Panel[2].SetActive(true);
    }

    public void CoinExit()
    {
        Panel[2].SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void StartExit()
    {
        Panel[2].SetActive(false);
    }

    public void StageStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Setvolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void Upgrade()
    {
        count = (-(int)Characterlist.GetComponent<RectTransform>().offsetMax.x+3410) / 680;
        Text text = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Text>();


        if(power[count]<powerMax[count])
        {
            if (int.Parse(Coin.text) >= upgrade[count] * 500)
            {
                Coin.text = (int.Parse(Coin.text) - upgrade[count] * 500).ToString();
                upgrade[count]++;
                power[count]++;
                text.text = "Upgrade : " + (upgrade[count] * 500).ToString();
                Characterlist.transform.GetChild(count).GetChild(0).GetChild(1).GetComponent<RectTransform>().
                    sizeDelta = new Vector2(power[count] * 30, 40);
                powerRes = power[count];
                CharacterData.Coin_ = Coin.text;
            }
        }
        else if(luck[count]<luckMax[count])
        {
            if (int.Parse(Coin.text) >= upgrade[count] * 500)
            {
                Coin.text = (int.Parse(Coin.text) - upgrade[count] * 500).ToString();
                upgrade[count]++;
                luck[count]++;
                text.text = "Upgrade : " + (upgrade[count] * 500).ToString();
                Characterlist.transform.GetChild(count).GetChild(1).GetChild(1).GetComponent<RectTransform>().
                    sizeDelta = new Vector2(luck[count] * 30, 40);
                luckRes = luck[count];
                CharacterData.Coin_ = Coin.text;
            }
        }
        else if(shield[count]<shieldMax[count])
        {
            if (int.Parse(Coin.text) >= upgrade[count] * 500)
            {
                Coin.text = (int.Parse(Coin.text) - upgrade[count] * 500).ToString();
                upgrade[count]++;
                shield[count]++;
                text.text = "Upgrade : " + (upgrade[count] * 500).ToString();
                Characterlist.transform.GetChild(count).GetChild(2).GetChild(1).GetComponent<RectTransform>().
                    sizeDelta = new Vector2(shield[count] * 30, 40);
                shieldRes = shield[count];
                CharacterData.Coin_ = Coin.text;
            }
        }
    }

    public void buyRuby()
    {
        string ruby;
        ruby = EventSystem.current.currentSelectedGameObject.transform.parent.name;
        Ruby.text = (int.Parse(Ruby.text) + int.Parse(ruby)).ToString();
        CharacterData.Ruby_ = Ruby.text;
    }

    public void buyCoin()
    {
        string coin;
        coin = EventSystem.current.currentSelectedGameObject.transform.parent.name;

        if (int.Parse(Ruby.text) - int.Parse(coin) / 10 >= 0)
        {
            Coin.text = (int.Parse(Coin.text) + int.Parse(coin)).ToString();
            Ruby.text = (int.Parse(Ruby.text) - int.Parse(coin) / 10).ToString();
            CharacterData.Coin_ = Coin.text;
            CharacterData.Ruby_ = Ruby.text;
        }
    }
}
