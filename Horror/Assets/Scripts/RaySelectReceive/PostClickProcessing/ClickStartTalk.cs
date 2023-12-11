using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/// <summary>
/// Select���ɍ��N���b�N����ƃ`���b�g���o��X�N���v�g
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
        // ����
        isTalkNow = true;   // ��b���A�ēx��b���J�n�����Ȃ�
        GameManager.gameManager.LockPlayer();

        // ��b�J�n
        flowchart.SendFungusMessage(strMessage);
    }

    public void FinishTalk()
    {
        isTalkNow = false;  // �ēx��b�\
        GameManager.gameManager.UnLockPlayer();
    }

    ///
    /// �ȉ��A�I�v�V�����@�\
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
