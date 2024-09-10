using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DogCtl : MonoBehaviour
{
    public float jumpForce = 1f;//跳ねる高さ
    public float minWalkTime = 1.0f;//最小歩行時間
    public float maxWalkTime = 4.0f;//最大歩行時間
    public float walkSpeed = 3f;//歩く速度

    private Rigidbody2D rb;

    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WalkAndJumpCycle());
        Destroy(this.gameObject, 10.0f);//一定時間後に削除
    }
    private IEnumerator WalkAndJumpCycle()
    {
        while (true)
        {
            //ランダムな時間歩く
            float walkTime = Random.Range(minWalkTime, maxWalkTime);
            float endTime = Time.time + walkTime;

            while (Time.time < endTime)
            {
                rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
                yield return null;
            }

            //歩行停止
            rb.velocity = Vector2.zero;




            //右上にジャンプ
            Vector2 jumpDirection = new Vector2(10f, 10f).normalized;
            rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);

            // ジャンプ後に少し待ってから次のループ
            yield return new WaitForSeconds(0.5f); // ジャンプの処理が終わるまで少し待つ

        }
    }

  


}
