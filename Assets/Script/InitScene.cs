using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScene : MonoBehaviour
{
    public GameObject enemy;
    private GameObject instance;
    public Vector3 pos;
    public float moveSpeed = 3.0f;
    public int Score = 1000;
    public float time = 30;
    public GameObject DamageCanvas;
    public static bool DCSet = false;

    public GameObject LoseCanvas;
    public GameObject WinCanvas;

    public Text Score_T;
    public Text Time_T;
    public Text Damage; 
    float checkTime = 0f;

    public AudioSource destroyAudio;
    public AudioSource missileAudio;
    public AudioSource coinAudio;

    // Start is called before the first frame update
    void Start()
    {
        DamageCanvas.SetActive(DCSet);
        LoseCanvas.SetActive(false);
        WinCanvas.SetActive(false);
        InvokeRepeating("CreateEnemy",1.0f, 0.5f);
    }
    void Update()
    {
        if (time > 0)
            time -= Time.deltaTime;
        else
        {
            CancelInvoke("CreateEnemy");
            WinCanvas.SetActive(true);
            Application.Quit();
        }

        if(checkTime > 0)
        {
            checkTime -= Time.deltaTime;
        }
        else
        {
            if(DCSet == true)
            {
                DCSet = false;
                checkTime = 0;
                DamageCanvas.SetActive(DCSet);
            }
        }
        
        Score_T.text = "SCORE : " + Score.ToString();
        Time_T.text = " TIME : " + time.ToString();
        Damage.text = "Damage :-300  Total : " + Score.ToString();
    }

    // Update is called once per frame
    void CreateEnemy()
    {
        int random = Random.Range(0, 5);

        if (random == 0) {
            enemy = (GameObject)Resources.Load("Coin");
        }
        else if(random == 1 || random == 2)
            enemy = (GameObject)Resources.Load("GreenJelly");
        else 
            enemy = (GameObject)Resources.Load("PurpleJelly");
            
        int x = Random.Range(1,6);
        instance = (GameObject)Instantiate(enemy, new Vector3(x * 2.0f - 6, 12.0f, 0), Quaternion.Euler(0, 180, 0));

    }

    public void PlayAudioDestroy()
    {
        destroyAudio.Play();
    }

    public void PlayAudioMissile()
    {
        missileAudio.Play();
    }

    public void PlayAudioCoin()
    {
        coinAudio.Play();
    }

    public void SpeedUp()
    {
        if (moveSpeed < 12)
            moveSpeed += 0.2f;
    }

    public void cancleInvoke()
    {
        CancelInvoke("CreateEnemy");
    }

    public void ActiveOn()
    {
        checkTime = 0.7f;
        DCSet = true;
        DamageCanvas.SetActive(DCSet);
    }
    public void Lose()
    {
        LoseCanvas.SetActive(true);
        Application.Quit();
    }
}
