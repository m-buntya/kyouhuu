using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class DogCtl : MonoBehaviour
{
    public float jumpForce = 1f;//���˂鍂��
    public float minWalkTime = 1.0f;//�ŏ����s����
    public float maxWalkTime = 4.0f;//�ő���s����
    public float walkSpeed = 3f;//�������x

    private Rigidbody2D rb;

    private void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(WalkAndJumpCycle());
        Destroy(this.gameObject, 10.0f);//��莞�Ԍ�ɍ폜
    }
    private IEnumerator WalkAndJumpCycle()
    {
        while (true)
        {
            //�����_���Ȏ��ԕ���
            float walkTime = Random.Range(minWalkTime, maxWalkTime);
            float endTime = Time.time + walkTime;

            while (Time.time < endTime)
            {
                rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
                yield return null;
            }

            //���s��~
            rb.velocity = Vector2.zero;




            //�E��ɃW�����v
            Vector2 jumpDirection = new Vector2(10f, 10f).normalized;
            rb.AddForce(jumpDirection * jumpForce, ForceMode2D.Impulse);

            // �W�����v��ɏ����҂��Ă��玟�̃��[�v
            yield return new WaitForSeconds(0.5f); // �W�����v�̏������I���܂ŏ����҂�

        }
    }

  


}
