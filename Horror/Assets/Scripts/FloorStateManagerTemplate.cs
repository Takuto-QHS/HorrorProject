using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �f�U�C���p�^�[���uTemplateMethod�v�ɑ���A
/// �֐��������Œ�`�����ʏ������܂߁A�p����ŏ���������
/// ��{�I��StateManager�Ŏg�p����̂͂����̊֐��̂�
/// </summary>

public class FloorStateManagerTemplate : MonoBehaviour
{
    /// <summary>
    /// �eChapter��Enum
    /// </summary>
    //private enum STATE_CHAPTER_TYPE
    //{
    //    TITLE,
    //    FLOOR_1,
    //    FLOOR_2,
    //    FLOOR_3,
    //    FLOOR_4,
    //    FLOOR_5,
    //    BACEMENT_FLOOR_1
    //}
    //[SerializeField]
    //private STATE_CHAPTER_TYPE stateChapter;

    public List<GameObject> list = new List<GameObject>();

    void Awake()
    {
        // list���̐eObj��S�ăI�t�ɂ���
        foreach (GameObject obj in list)
            obj.SetActive(false);
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public virtual void OneStepProgressing(int nowStateIndex = 0)
    {
        list[nowStateIndex].SetActive(false);
        list[nowStateIndex + 1].SetActive(true);
    }
}
