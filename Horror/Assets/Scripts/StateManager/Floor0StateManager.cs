using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各階層の進行状況処理を継承元の関数を使用して実装する
/// </summary>

public class Floor0StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// このChapter内の進行度Enum
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
        //list[0].SetActive(true);                    // 本番用
        list[(int)stateFloor0].SetActive(true);     // テスト用
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor0);
        stateFloor0 = (STATE_FLOOR_0)Enum.ToObject(typeof(STATE_FLOOR_0), (int)stateFloor0 + 1);
    }
}
