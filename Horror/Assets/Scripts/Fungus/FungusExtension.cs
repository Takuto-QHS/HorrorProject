using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using StarterAssets;

/// <summary>
/// Fungus用関数拡張スクリプト
/// カーソルオンオフ等、Fungusに用意されてるものでは
/// 対応出来ないオプション関数をここにまとめていく
/// </summary>

public class FungusExtension : MonoBehaviour
{
    private CinemachineVirtualCamera cam;   // カメラ移動用

    /// <summary>
    /// プレイヤーカメラ→ノベルダイアログ用カメラ遷移
    /// </summary>
    /// <param name="changeCam"></param>
    public void ChangeCamera(CinemachineVirtualCamera changeCam)
    {
        cam = changeCam;
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        cam.gameObject.SetActive(true);
    }

    /// <summary>
    /// ノベルダイアログ用カメラ→プレイヤーカメラ遷移
    /// </summary>
    public void ResetCamera()
    {
        cam.gameObject.SetActive(false);
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
    }

    /// <summary>
    /// カーソルのオンオフ
    /// </summary>
    /// <param name="isCursol"></param>
    public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// カットシーン起動
    /// </summary>
    /// <param name="director"></param>
    public void PlayTimeLine(PlayableDirector director)
    {
        director.played += DirectorPlayed;
        director.stopped += DirectorFinished;
        director.Play();
    }
    private void DirectorPlayed(PlayableDirector obj)
    {
        Debug.Log("Timeline開始");
    }
    private void DirectorFinished(PlayableDirector obj)
    {
        Debug.Log("Timeline終了");
    }
    
    /// <summary>
    /// カットシーンのカメラブレンドタイムを変更
    /// </summary>
    public void ChangeCamBlendSpead(float speed)
    {
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Time = speed;
    }

    /// <summary>
    /// 指定のゲームオブジェクトを破棄
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyObj(GameObject obj)
    {
        Destroy(obj.gameObject);
    }

    /// <summary>
    /// PlayerCapsuleとPlayerCapsuleRootのRotationを変更
    /// ※Timeline終了後のプレイヤーカメラ位置が違う場合等の
    ///   何らかの形でカメラ位置を変更したい場合に使用
    /// </summary>
    public void SetPlayerCameraRotation(float x,float y)
    {
        // Capsuleのy方向を変更
        Vector3 temp = GameManager.gameManager.playerCupsule.transform.localEulerAngles;
        temp.y = y;
        GameManager.gameManager.playerCupsule.transform.localEulerAngles = temp;

        // CapsuleRootのx方向を変更
        temp = GameManager.gameManager.playerCupsule.transform.GetChild(0).transform.localEulerAngles;
        temp.x = x;
        GameManager.gameManager.playerCupsule.transform.GetChild(0).transform.localEulerAngles = temp;

        // カットシーン後、マウス触り始めにxの値がおかしくなるのを修正(ガクッとなる原因)
        GameManager.gameManager.GetFirstPersonCtr().SetCinemachineTargetPitch(x);
    }

    /// <summary>
    /// 進行度を1つ進める
    /// </summary>
    public void OneStepProgressing()
    {
        GameManager.gameManager.OneStepProgressing();
    }

    /// <summary>
    /// 指定したアニメーションを起動
    /// </summary>
    public void SetAnimation(Animator animator, string stateName, float crossFadeTime = 0.1f)
    {
        animator.CrossFade(stateName, crossFadeTime);
    }

    /// <summary>
    /// Rayを当てた際のOutline表示オンオフスイッチ用
    /// </summary>
    public void SwitchDisplaySelectRayOutline(bool isDisplay,SelectRayOutlineComponent script)
    {
        script.isDisplay = isDisplay;
        SwitchEnableScript(isDisplay, script);
    }

    /// <summary>
    /// FlashMaterial機能のオンオフスイッチ用
    /// </summary>
    public void SwitchEnableFlashMaterial(bool isEnable,FlashMaterialComponent script)
    {
        if(!isEnable) script.ResetFlashMaterialEmission();
        SwitchEnableScript(isEnable, script);
    }

    /// <summary>
    /// StartTalk機能のオンオフスイッチ用
    /// ※ScriptのEnableを切るだけでは貫通して動いてしまう為、isTalkingで止めています
    /// </summary>
    public void SwitchEnableStartTalk(bool isEnable, ClickStartTalkComponent script)
    {
        script.isTalking = !isEnable;
        SwitchEnableScript(isEnable, script);
    }

    /// <summary>
    /// 指定スクリプトの機能オンオフスイッチ
    /// </summary>
    public void SwitchEnableScript(bool isEnable, MonoBehaviour script)
    {
        script.enabled = isEnable;
    }
}