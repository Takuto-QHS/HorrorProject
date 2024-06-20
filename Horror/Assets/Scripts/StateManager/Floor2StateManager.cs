using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// 各階層の進行状況処理を継承元の関数を使用して実装する
/// </summary>

public class Floor2StateManager : FloorStateManagerTemplate
{
    /// <summary>
    /// このChapter内の進行度Enum
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
        //list[0].SetActive(true);                    // 本番用
        list[(int)stateFloor2].SetActive(true);     // テスト用
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public override void OneStepProgressing(int nowStateIndex = 0)
    {
        base.OneStepProgressing((int)stateFloor2);
        stateFloor2 = (STATE_FLOOR_2)Enum.ToObject(typeof(STATE_FLOOR_2), (int)stateFloor2 + 1);
    }
}
