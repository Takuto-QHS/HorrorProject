using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// TimelineのSignalEmitterで使用する関数
/// </summary>

public class TimelineEmitter : MonoBehaviour
{
    private Animator animator;              // アニメーション起動用
    private float crossFadeTime = 0.1f;     // アニメーション起動用

    /// <summary>
    /// 進行度を1つ進め、指定ゲームオブジェクトを破棄
    /// </summary>
    public void NextStep(GameObject obj)
    {
        GameManager.gameManager.OneStepProgressing();
        Destroy(obj);
    }

    /// <summary>
    /// プレイヤーの操作をアンロック(受け付ける)
    /// </summary>
    public void UnLockPlayer()
    {
        GameManager.gameManager.UnLockPlayer();
    }

    /// <summary>
    /// animator変数にセットする(SetAnimationと併用)
    /// </summary>
    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    /// <summary>
    /// stateNameにAnimator内のアニメーション名を入れる事で起動
    /// </summary>
    public void SetAnimation(string stateName)
    {
        animator.CrossFade(stateName, crossFadeTime);
    }
}
