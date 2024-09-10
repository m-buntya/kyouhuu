using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float jumpForce = 500.0f;
    public GaugeController gaugeController;  // これを追加

    private bool canJump = false;  // ジャンプできるかどうかのフラグ

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
            Debug.Log("犬");
            gaugeController.BeInjured(20);  // 犬に当たったら20減少
        }
        else if (other.gameObject.tag == "kyabetu")
        {
            Debug.Log("キャベツ");
            gaugeController.BeInjured(10);  // キャベツに当たったら10減少
        }
        else if (other.gameObject.tag == "sinbunsi")
        {
            Debug.Log("新聞");
            gaugeController.BeInjured(5);  // 新聞に当たったら5減少
        }

        Destroy(other.gameObject);
    }

    // 接地したときの処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;  // 接地したらジャンプ可能にする
        }
    }

    // ボタン以外の画面をクリック/タップしたときにジャンプする
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            if (!IsPointerOverUIObject())  // UI上（ボタン上）でクリック/タップされていないことを確認
            {
                rb.AddForce(Vector2.up * jumpForce);
                canJump = false;  // ジャンプ後はジャンプ不可にする
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

    // UI上でのクリック/タップかどうかを判定するメソッド
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        // UI（ボタン）上でクリックされたかどうかを確認
        return results.Count > 0;
    }
}