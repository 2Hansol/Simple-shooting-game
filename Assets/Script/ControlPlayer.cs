using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPlayer : MonoBehaviour
{
    public float moveSpeed;
    public GameObject missile, bang, instance;

    public static bool leftButtion = false;
    public static bool rightButton = false;

    // Start is called before the first frame update
    void Awake()
    {
        moveSpeed = 3.0f;
        bang = (GameObject)Resources.Load("Bang");
        missile = (GameObject)Resources.Load("missile");
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enemy")
        {
            GameObject.Find("MainScript").GetComponent<InitScene>().PlayAudioDestroy();
            GameObject.Find("MainScript").GetComponent<InitScene>().Score -= 300;
     
            instance = (GameObject)Instantiate(bang, transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(instance, 2f);
            GameObject.Find("MainScript").GetComponent<InitScene>().ActiveOn();

            if (GameObject.Find("MainScript").GetComponent<InitScene>().Score < 0)
            {
                GameObject.Find("MainScript").GetComponent<InitScene>().cancleInvoke();
                Destroy(gameObject);
                GameObject.Find("MainScript").GetComponent<InitScene>().Lose();
            }
        }

        if(other.gameObject.tag == "Coin")
        {
            GameObject.Find("MainScript").GetComponent<InitScene>().PlayAudioCoin();
            GameObject.Find("MainScript").GetComponent<InitScene>().Score += 100;
            Destroy(other.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)||leftButtion)
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow)||rightButton)
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject.Find("MainScript").GetComponent<InitScene>().PlayAudioMissile();
            GameObject.Find("MainScript").GetComponent<InitScene>().Score -= 1;
            Vector3 pos = gameObject.transform.position;
            pos.y += 2f;
            instance = (GameObject)Instantiate(missile, pos, Quaternion.identity);
            instance.GetComponent<Rigidbody>().AddForce(transform.up * 500);
            if (GameObject.Find("MainScript").GetComponent<InitScene>().Score < 0)
            {
                GameObject.Find("MainScript").GetComponent<InitScene>().cancleInvoke();
                Destroy(gameObject);

            }
        }

    }
    public void ButtonDown(int i)
    {
        if(i ==1)
        {
            leftButtion = true;
        }
        else if(i == 2)
        {
            rightButton = true;
        }
    }

    public void ButtonUp(int i)
    {
        if (i == 1)
        {
            leftButtion = false;
        }
        else if (i == 2)
        {
            rightButton = false;
        }
    }

    public void SpeedUp()
    {
        moveSpeed += 1;
    }

    public void shoot()
    {
        bang = (GameObject)Resources.Load("Bang");
        missile = (GameObject)Resources.Load("missile");
        GameObject.Find("MainScript").GetComponent<InitScene>().PlayAudioMissile();
        GameObject.Find("MainScript").GetComponent<InitScene>().Score -= 1;
        Vector3 pos = gameObject.transform.position;
        pos.y += 2f;
        instance = (GameObject)Instantiate(missile, pos, Quaternion.identity);
        instance.GetComponent<Rigidbody>().AddForce(transform.up * 500);
        if (GameObject.Find("MainScript").GetComponent<InitScene>().Score < 0)
        {
            GameObject.Find("MainScript").GetComponent<InitScene>().cancleInvoke();
            Destroy(gameObject);
        }
    }

}
