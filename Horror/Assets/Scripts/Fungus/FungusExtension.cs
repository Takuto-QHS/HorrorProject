using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

/// <summary>
/// Fungus用関数拡張スクリプト
/// カーソルオンオフ等、Fungusに用意されてるものでは
/// 対応出来ないオプション関数をここにまとめていく
/// </summary>

public class FungusExtension : MonoBehaviour
{
    private CinemachineVirtualCamera cam;   // カメラ移動用

    public void ChangeCamera(CinemachineVirtualCamera changeCam)
    {
        cam = changeCam;
        cam.gameObject.SetActive(true);
    }
    public void ResetCamera()
    {
        cam.gameObject.SetActive(false);
    }
    public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
    public void PlayTimeLine(PlayableDirector director)
    {
        director.played += DirectorPlayed;
        director.stopped += DirectorStopped;
        director.Play();
    }
    private void DirectorPlayed(PlayableDirector obj)
    {
        Debug.Log("Timeline開始");
    }
    private void DirectorStopped(PlayableDirector obj)
    {
        Debug.Log("Timeline終了");
    }
}