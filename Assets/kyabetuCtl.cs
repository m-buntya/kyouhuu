using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
public class kyabetuCtl : MonoBehaviour
{
    public float jumpForce = 1f;//跳ねる高さ

    void Start()
    {
      Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //速度初期化
        rb.velocity = Vector2.zero;

        //左上に跳ねる
        Vector2 jumpDirection=new Vector2(10f,10f).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
            Destroy (this.gameObject, 10.0f);//一定時間後に削除
    }



}