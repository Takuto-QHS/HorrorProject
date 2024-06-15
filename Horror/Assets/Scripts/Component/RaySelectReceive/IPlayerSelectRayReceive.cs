using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーがオブジェクトに視線を当てた時用の各発火スクリプト
/// </summary>
public class IPlayerSelectRayReceive : MonoBehaviour
{
    /// <summary>
    /// プレイヤーの視線の当たり始め
    /// </summary>
    public virtual void FirstHit(){}

    /// <summary>
    /// プレイヤーの視線が当たってる最中
    /// </summary>
    public virtual void HitNow(){}

    /// <summary>
    /// プレイヤーの視線の当たり終わり
    /// </summary>
    public virtual void NotHit(){}
}
