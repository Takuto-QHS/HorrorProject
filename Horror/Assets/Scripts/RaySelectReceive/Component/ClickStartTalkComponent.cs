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

    private bool isTalkNow = false;

    public override void HitNow()
    {
        if (Input.GetMouseButtonDown(0) && !isTalkNow)
            StartTalk();
    }

    private void StartTalk()
    {
        // 準備
        isTalkNow = true;   // 会話中、再度会話を開始させない
        GameManager.gameManager.LockPlayer();

        // 会話開始
        flowchart.SendFungusMessage(strMessage);
    }

    public void FinishTalk()
    {
        isTalkNow = false;  // 再度会話可能
        GameManager.gameManager.UnLockPlayer();
    }
}
