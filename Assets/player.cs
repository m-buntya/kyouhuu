using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 500.0f;
    public GaugeController gaugeController;  // �����ǉ�

    private bool canJump = false;  // �W�����v�ł��邩�ǂ����̃t���O

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Dog")
        {
            Debug.Log("��");
            gaugeController.BeInjured(20);  // ���ɓ���������20����
        }
        else if (other.gameObject.tag == "kyabetu")
        {
            Debug.Log("�L���x�c");
            gaugeController.BeInjured(10);  // �L���x�c�ɓ���������10����
        }
        else if (other.gameObject.tag == "sinbunsi")
        {
            Debug.Log("�V��");
            gaugeController.BeInjured(5);  // �V���ɓ���������5����
        }

        Destroy(other.gameObject);
    }

    // �ڒn�����Ƃ��̏���
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;  // �ڒn������W�����v�\�ɂ���
        }
    }

    // �{�^���ȊO�̉�ʂ��N���b�N/�^�b�v�����Ƃ��ɃW�����v����
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            if (!IsPointerOverUIObject())  // UI��i�{�^����j�ŃN���b�N/�^�b�v����Ă��Ȃ����Ƃ��m�F
            {
                rb.AddForce(Vector2.up * jumpForce);
                canJump = false;  // �W�����v��̓W�����v�s�ɂ���
            }
        }
    }

    public void rightBottonDown()
    {
        transform.Translate(3, 0, 0);
    }

    public void leftBottonDown()
    {
        transform.Translate(-3, 0, 0);
    }

    // UI��ł̃N���b�N/�^�b�v���ǂ����𔻒肷�郁�\�b�h
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        // UI�i�{�^���j��ŃN���b�N���ꂽ���ǂ������m�F
        return results.Count > 0;
    }
}