using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class Floor2StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_2
    {
        ELEVATOR_START,
        ELEVATOR_SHUTDOWN,
        GHOSTCUT_01,
        GHOSTCUT_02,
        GENERATOR_BOOT,
        GHOSTATTACKED,
        ESCAPE,
        ELEVATOR_END
    }
    [SerializeField]
    private STATE_FLOOR_2 stateFloor2;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloor2].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor2);
        stateFloor2 = (STATE_FLOOR_2)Enum.ToObject(typeof(STATE_FLOOR_2), (int)stateFloor2 + 1);
    }
}
