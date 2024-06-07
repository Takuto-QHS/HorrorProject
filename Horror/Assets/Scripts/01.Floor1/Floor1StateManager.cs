using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class Floor1StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_1
    {
        OPENING,
        DOOR_OPEN,
        BOY_CUT_1,
        BOY_CUT_2,
        GENERATOR_BOOT,
        ELEBATOR_TORRIGER
    }
    [SerializeField]
    private STATE_FLOOR_1 stateFloor1;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloor1].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor1);
        stateFloor1 = (STATE_FLOOR_1)Enum.ToObject(typeof(STATE_FLOOR_1), (int)stateFloor1 + 1);
    }
}
