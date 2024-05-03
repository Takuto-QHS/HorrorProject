using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// デザインパターン「TemplateMethod」に則り、
/// 関数をここで定義し共通処理を含め、継承先で処理を実装
/// 基本的にStateManagerで使用するのはここの関数のみ
/// </summary>

public class FloorStateManagerTemplate : MonoBehaviour
{
    /// <summary>
    /// 各ChapterのEnum
    /// </summary>
    //private enum STATE_CHAPTER_TYPE
    //{
    //    TITLE,
    //    FLOOR_1,
    //    FLOOR_2,
    //    FLOOR_3,
    //    FLOOR_4,
    //    FLOOR_5,
    //    BACEMENT_FLOOR_1
    //}
    //[SerializeField]
    //private STATE_CHAPTER_TYPE stateChapter;

    public List<GameObject> list = new List<GameObject>();

    void Awake()
    {
        // list内の親Objを全てオフにする
        foreach (GameObject obj in list)
            obj.SetActive(false);
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public virtual void OneStepProgressing(int nowStateIndex = 0)
    {
        list[nowStateIndex].SetActive(false);
        list[nowStateIndex + 1].SetActive(true);
    }
}
