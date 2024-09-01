using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class FloorB2StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_B2
    {
        ELEVATOR_START,
        SUPICA_FOUND
    }
    [SerializeField]
    private STATE_FLOOR_B2 stateFloorB2;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloorB2].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloorB2);
        stateFloorB2 = (STATE_FLOOR_B2)Enum.ToObject(typeof(STATE_FLOOR_B2), (int)stateFloorB2 + 1);
    }
}
