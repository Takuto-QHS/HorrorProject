using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Select���ɍ��N���b�N����ƃ`���b�g���o��X�N���v�g
/// </summary>
public class ClickStartTalkComponent : IPlayerSelectRayReceive
{
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    public bool isTalking = false;      // �b���邩�p�t���O

    public override void HitNow()
    {
        if (Input.GetMouseButtonDown(0) && !isTalking)
            StartTalk();
    }

    private void StartTalk()
    {
        // ����
        isTalking = true;   // ��b���A�ēx��b���J�n�����Ȃ�
        GameManager.gameManager.LockPlayer();

        // ��b�J�n
        flowchart.SendFungusMessage(strMessage);
    }

    public void FinishTalk()
    {
        isTalking = false;  // �ēx��b�\
        GameManager.gameManager.UnLockPlayer();
    }
}
