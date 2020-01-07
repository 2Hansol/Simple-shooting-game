using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour {

   
   void Start () {
        GameObject.Find("MainScript").GetComponent<InitScene>().SpeedUp();
    }

   void Update () {
       transform.Translate(Vector3.down * GameObject.Find("MainScript").GetComponent<InitScene>().moveSpeed * Time.deltaTime);
       if (gameObject.transform.position.y < -10){
           Destroy(gameObject);
       }
   }
}