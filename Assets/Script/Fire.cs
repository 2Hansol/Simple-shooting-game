using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fire : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public GameObject bang;
    private GameObject instance;

    // Start is called before the first frame update
    void Start()
    {
        bang = (GameObject)Resources.Load("Bang");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > 15)
            Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "enemy")
        {
            instance = (GameObject)Instantiate(bang, gameObject.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(instance, 2f);
            Destroy(gameObject);
            
        }
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

        }

    }
}
