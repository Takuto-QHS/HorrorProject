using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// �e�K�w�̐i�s�󋵏������p�����̊֐����g�p���Ď�������
/// </summary>

public class FloorB1StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// ����Chapter���̐i�s�xEnum
    /// </summary>
    private enum STATE_FLOOR_B1
    {
        
    }
    [SerializeField]
    private STATE_FLOOR_B1 stateFloorB1;

    void Start()
    {
        //list[0].SetActive(true);                    // �{�ԗp
        list[(int)stateFloorB1].SetActive(true);     // �e�X�g�p
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloorB1);
        stateFloorB1 = (STATE_FLOOR_B1)Enum.ToObject(typeof(STATE_FLOOR_B1), (int)stateFloorB1 + 1);
    }
}
