using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
public class kyabetuCtl : MonoBehaviour
{
    public float jumpForce = 1f;//’µ‚Ë‚é‚‚³

    void Start()
    {
      Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //‘¬“x‰Šú‰»
        rb.velocity = Vector2.zero;

        //¶ã‚É’µ‚Ë‚é
        Vector2 jumpDirection=new Vector2(10f,10f).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
            Destroy (this.gameObject, 10.0f);//ˆê’èŠÔŒã‚Éíœ
    }



}