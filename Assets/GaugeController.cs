using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject _gauge;  // �̗̓Q�[�W��UI�I�u�W�F�N�g
    [SerializeField] private int _HP = 100;      // �ő�HP
    private float _HP1;                          // HP1������̕�
    private bool _isGaugeDepleted = false;       // �Q�[�W��0�ɂȂ������ǂ����̃t���O

    void Awake()
    {
        // �X�v���C�g�̕����ő�HP�Ŋ�����HP1������̕����v�Z
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    void Start()
    {
        // 29�b��ɃN���A�V�[��1�ւ̑J�ڂ��`�F�b�N����R���[�`�����J�n
        StartCoroutine(CheckGaugeAfterTime(29f));
    }

    // �_���[�W���󂯂��Ƃ��ɌĂяo����郁�\�b�h
    public void BeInjured(int damage)
    {
        // �_���[�W�ɑΉ�����Q�[�W�̌��������v�Z
        float damageWidth = _HP1 * damage;

        // �̗̓Q�[�W�̌��݂̕����擾
        Vector2 currentSize = _gauge.GetComponent<RectTransform>().sizeDelta;

        // �Q�[�W�̕�������������
        currentSize.x -= damageWidth;

        // �Q�[�W�̕����X�V
        _gauge.GetComponent<RectTransform>().sizeDelta = currentSize;

        // �c��̃Q�[�W��0�ȉ��ɂȂ����ꍇ
        if (currentSize.x <= 0 && !_isGaugeDepleted)
        {
            _isGaugeDepleted = true;  // �Q�[�W��0�ɂȂ������Ƃ��t���O�ŋL�^
            OnGaugeDepleted();
        }
    }

    // �Q�[�W��0�ɂȂ����Ƃ��̏���
    private void OnGaugeDepleted()
    {
        Debug.Log("Gauge is empty! Transitioning to Clear Scene.");
        SceneManager.LoadScene("ClearScene");  // "ClearScene"�ɑJ��
    }

    // 29�b��ɃQ�[�W���`�F�b�N���ăN���A�V�[��1�ɑJ�ڂ���
    private IEnumerator CheckGaugeAfterTime(float time)
    {
        // �w�肳�ꂽ�b���҂�
        yield return new WaitForSeconds(time);

        // �Q�[�W��1�ȏ�c���Ă��āA�܂��ʏ�̃N���A�V�[���ɑJ�ڂ��Ă��Ȃ��ꍇ
        if (!_isGaugeDepleted && _gauge.GetComponent<RectTransform>().sizeDelta.x > 0)
        {
            Debug.Log("29 seconds passed, Gauge is not empty! Transitioning to Clear Scene 1.");
            SceneManager.LoadScene("ClearScene1");  // "ClearScene1"�ɑJ��
        }
    }
}