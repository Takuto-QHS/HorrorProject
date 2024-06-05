using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Select中に左クリックするとチャットが出るスクリプト
/// </summary>
public class ClickStartTalkComponent : IPlayerSelectRayReceive
{
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    public bool isTalking = false;      // 話せるか用フラグ

    public override void HitNow()
    {
        if (Input.GetMouseButtonDown(0) && !isTalking)
            StartTalk();
    }

    private void StartTalk()
    {
        // 準備
        isTalking = true;   // 会話中、再度会話を開始させない
        GameManager.gameManager.LockPlayer();

        // 会話開始
        flowchart.SendFungusMessage(strMessage);
    }

    public void FinishTalk()
    {
        isTalking = false;  // 再度会話可能
        GameManager.gameManager.UnLockPlayer();
    }
}
