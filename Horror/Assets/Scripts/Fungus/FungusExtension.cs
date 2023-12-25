using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;

/// <summary>
/// Fungus�p�֐��g���X�N���v�g
/// �J�[�\���I���I�t���AFungus�ɗp�ӂ���Ă���̂ł�
/// �Ή��o���Ȃ��I�v�V�����֐��������ɂ܂Ƃ߂Ă���
/// </summary>

public class FungusExtension : MonoBehaviour
{
    private CinemachineVirtualCamera cam;   // �J�����ړ��p

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
        Debug.Log("Timeline�J�n");
    }
    private void DirectorStopped(PlayableDirector obj)
    {
        Debug.Log("Timeline�I��");
    }
}