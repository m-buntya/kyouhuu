using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sinbunsiCtl : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        this.player = GameObject.Find("player_0");
    }

    // Update is called once per frame
    void Update()
    {
        //フレームレートごとに等速で移動させる
        transform.Translate(0.1f, 0, 0);
        Destroy(this.gameObject, 10.0f);//一定時間後に削除
        


    }
}
