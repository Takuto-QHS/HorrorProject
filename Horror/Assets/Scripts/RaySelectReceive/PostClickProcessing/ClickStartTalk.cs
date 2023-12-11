using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Select中に左クリックするとチャットが出るスクリプト
/// </summary>
public class ClickStartTalk : SelectRayOutline
{
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    private bool isTalkNow = false;

    // Option
    private CinemachineVirtualCamera cam;

    public override void HitNow()
    {
        if(Input.GetMouseButtonDown(0) && !isTalkNow)
        {
            StartTalk();
        }
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

    ///
    /// 以下、オプション機能
    ///
    public void SelectCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
    public void ChangeCamera(CinemachineVirtualCamera changeCam)
    {
        cam = changeCam;
        cam.gameObject.SetActive(true);
    }
    public void ResetCamera()
    {
        cam.gameObject.SetActive(false);
    }
}
