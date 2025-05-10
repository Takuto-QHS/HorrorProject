using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各階層の進行状況処理を継承元の関数を使用して実装する
/// </summary>

public class Floor3StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// このChapter内の進行度Enum
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
        //list[0].SetActive(true);                    // 本番用
        list[(int)stateFloor3].SetActive(true);     // テスト用
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor3);
        stateFloor3 = (STATE_FLOOR_3)Enum.ToObject(typeof(STATE_FLOOR_3), (int)stateFloor3 + 1);
    }
}
