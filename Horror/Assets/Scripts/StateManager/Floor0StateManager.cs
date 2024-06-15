using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class Floor0StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_0
    {
        OPENING,
        DOOR_OPEN,
        BOTTLE_FALL,
        BOY_CUT_1,
        BOY_CUT_2,
        GENERATOR_BOOT,
        ELEBATOR_TORRIGER
    }
    [SerializeField]
    private STATE_FLOOR_0 stateFloor0;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloor0].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor0);
        stateFloor0 = (STATE_FLOOR_0)Enum.ToObject(typeof(STATE_FLOOR_0), (int)stateFloor0 + 1);
    }
}
