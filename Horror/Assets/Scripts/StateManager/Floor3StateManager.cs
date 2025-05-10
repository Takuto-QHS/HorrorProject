using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class Floor3StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_3
    {
        ELEVATOR_START,
        GHOSTCUT_1,
        NOVEL_1,
        ELEVATOR_END,
    }
    [SerializeField]
    private STATE_FLOOR_3 stateFloor3;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloor3].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor3);
        stateFloor3 = (STATE_FLOOR_3)Enum.ToObject(typeof(STATE_FLOOR_3), (int)stateFloor3 + 1);
    }
}
