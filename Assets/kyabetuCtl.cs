using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 
public class kyabetuCtl : MonoBehaviour
{
    public float jumpForce = 1f;//���˂鍂��

    void Start()
    {
      Rigidbody2D rb = GetComponent<Rigidbody2D>();

        //���x������
        rb.velocity = Vector2.zero;

        //����ɒ��˂�
        Vector2 jumpDirection=new Vector2(10f,10f).normalized;
        rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);
    }

    private void Update()
    {
            Destroy (this.gameObject, 10.0f);//��莞�Ԍ�ɍ폜
    }



}