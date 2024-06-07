using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各階層の進行状況処理を継承元の関数を使用して実装する
/// </summary>

public class Floor1StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// このChapter内の進行度Enum
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
        //list[0].SetActive(true);                    // 本番用
        list[(int)stateFloor1].SetActive(true);     // テスト用
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor1);
        stateFloor1 = (STATE_FLOOR_1)Enum.ToObject(typeof(STATE_FLOOR_1), (int)stateFloor1 + 1);
    }
}
