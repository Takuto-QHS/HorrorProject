using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Select���ɍ��N���b�N����ƃ`���b�g���o��X�N���v�g
/// </summary>
public class ClickStartTalk : SelectionHighliting
{
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    private bool isTalkNow = false;

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
    public void SelectCursolOn()
    {
        bool isCursol = true;
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
    public void SelectCursolOff()
    {
        bool isCursol = false;
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }
}
