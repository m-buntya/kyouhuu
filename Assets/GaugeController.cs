using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject _gauge;  // 体力ゲージのUIオブジェクト
    [SerializeField] private int _HP = 100;      // 最大HP
    private float _HP1;                          // HP1あたりの幅
    private bool _isGaugeDepleted = false;       // ゲージが0になったかどうかのフラグ

    void Awake()
    {
        // スプライトの幅を最大HPで割ってHP1あたりの幅を計算
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    void Start()
    {
        // 29秒後にクリアシーン1への遷移をチェックするコルーチンを開始
        StartCoroutine(CheckGaugeAfterTime(29f));
    }

    // ダメージを受けたときに呼び出されるメソッド
    public void BeInjured(int damage)
    {
        // ダメージに対応するゲージの減少幅を計算
        float damageWidth = _HP1 * damage;

        // 体力ゲージの現在の幅を取得
        Vector2 currentSize = _gauge.GetComponent<RectTransform>().sizeDelta;

        // ゲージの幅を減少させる
        currentSize.x -= damageWidth;

        // ゲージの幅を更新
        _gauge.GetComponent<RectTransform>().sizeDelta = currentSize;

        // 残りのゲージが0以下になった場合
        if (currentSize.x <= 0 && !_isGaugeDepleted)
        {
            _isGaugeDepleted = true;  // ゲージが0になったことをフラグで記録
            OnGaugeDepleted();
        }
    }

    // ゲージが0になったときの処理
    private void OnGaugeDepleted()
    {
        Debug.Log("Gauge is empty! Transitioning to Clear Scene.");
        SceneManager.LoadScene("ClearScene");  // "ClearScene"に遷移
    }

    // 29秒後にゲージをチェックしてクリアシーン1に遷移する
    private IEnumerator CheckGaugeAfterTime(float time)
    {
        // 指定された秒数待つ
        yield return new WaitForSeconds(time);

        // ゲージが1以上残っていて、まだ通常のクリアシーンに遷移していない場合
        if (!_isGaugeDepleted && _gauge.GetComponent<RectTransform>().sizeDelta.x > 0)
        {
            Debug.Log("29 seconds passed, Gauge is not empty! Transitioning to Clear Scene 1.");
            SceneManager.LoadScene("ClearScene1");  // "ClearScene1"に遷移
        }
    }
}