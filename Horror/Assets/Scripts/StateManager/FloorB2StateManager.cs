using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各階層の進行状況処理を継承元の関数を使用して実装する
/// </summary>

public class FloorB2StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// このChapter内の進行度Enum
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
        //list[0].SetActive(true);                    // 本番用
        list[(int)stateFloorB2].SetActive(true);     // テスト用
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloorB2);
        stateFloorB2 = (STATE_FLOOR_B2)Enum.ToObject(typeof(STATE_FLOOR_B2), (int)stateFloorB2 + 1);
    }
}
