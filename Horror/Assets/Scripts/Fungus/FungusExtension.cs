using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using StarterAssets;

/// <summary>
/// Fungus�p�֐��g���X�N���v�g
/// �J�[�\���I���I�t���AFungus�ɗp�ӂ���Ă���̂ł�
/// �Ή��o���Ȃ��I�v�V�����֐��������ɂ܂Ƃ߂Ă���
/// </summary>

public class FungusExtension : MonoBehaviour
{
    private CinemachineVirtualCamera cam;   // �J�����ړ��p

    /// <summary>
    /// �v���C���[�J�������m�x���_�C�A���O�p�J�����J��
    /// </summary>
    /// <param name="changeCam"></param>
    public void ChangeCamera(CinemachineVirtualCamera changeCam)
    {
        cam = changeCam;
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.Cut;
        cam.gameObject.SetActive(true);
    }

    /// <summary>
    /// �m�x���_�C�A���O�p�J�������v���C���[�J�����J��
    /// </summary>
    public void ResetCamera()
    {
        cam.gameObject.SetActive(false);
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
    }

    /// <summary>
    /// �J�[�\���̃I���I�t
    /// </summary>
    /// <param name="isCursol"></param>
    public void ShowCursol(bool isCursol)
    {
        Cursor.lockState = (isCursol) ? CursorLockMode.None : Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>
    /// �J�b�g�V�[���N��
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
        Debug.Log("Timeline�J�n");
    }
    private void DirectorFinished(PlayableDirector obj)
    {
        Debug.Log("Timeline�I��");
    }
    
    /// <summary>
    /// �J�b�g�V�[���̃J�����u�����h�^�C����ύX
    /// </summary>
    public void ChangeCamBlendSpead(float speed)
    {
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Style = CinemachineBlendDefinition.Style.EaseInOut;
        GameManager.gameManager.GetCinemachineBrain().m_DefaultBlend.m_Time = speed;
    }

    /// <summary>
    /// �w��̃Q�[���I�u�W�F�N�g��j��
    /// </summary>
    /// <param name="obj"></param>
    public void DestroyObj(GameObject obj)
    {
        Destroy(obj.gameObject);
    }

    /// <summary>
    /// PlayerCapsule��PlayerCapsuleRoot��Rotation��ύX
    /// ��Timeline�I����̃v���C���[�J�����ʒu���Ⴄ�ꍇ����
    ///   ���炩�̌`�ŃJ�����ʒu��ύX�������ꍇ�Ɏg�p
    /// </summary>
    public void SetPlayerCameraRotation(float x,float y)
    {
        // Capsule��y������ύX
        Vector3 temp = GameManager.gameManager.playerCupsule.transform.localEulerAngles;
        temp.y = y;
        GameManager.gameManager.playerCupsule.transform.localEulerAngles = temp;

        // CapsuleRoot��x������ύX
        temp = GameManager.gameManager.playerCupsule.transform.GetChild(0).transform.localEulerAngles;
        temp.x = x;
        GameManager.gameManager.playerCupsule.transform.GetChild(0).transform.localEulerAngles = temp;

        // �J�b�g�V�[����A�}�E�X�G��n�߂�x�̒l�����������Ȃ�̂��C��(�K�N�b�ƂȂ錴��)
        GameManager.gameManager.GetFirstPersonCtr().SetCinemachineTargetPitch(x);
    }

    /// <summary>
    /// �i�s�x��1�i�߂�
    /// </summary>
    public void OneStepProgressing()
    {
        GameManager.gameManager.OneStepProgressing();
    }

    /// <summary>
    /// �w�肵���A�j���[�V�������N��
    /// </summary>
    public void SetAnimation(Animator animator, string stateName, float crossFadeTime = 0.1f)
    {
        animator.CrossFade(stateName, crossFadeTime);
    }

    /// <summary>
    /// Ray�𓖂Ă��ۂ�Outline�\���I���I�t�X�C�b�`�p
    /// </summary>
    public void SwitchDisplaySelectRayOutline(bool isDisplay,SelectRayOutlineComponent script)
    {
        script.isDisplay = isDisplay;
        SwitchEnableScript(isDisplay, script);
    }

    /// <summary>
    /// FlashMaterial�@�\�̃I���I�t�X�C�b�`�p
    /// </summary>
    public void SwitchEnableFlashMaterial(bool isEnable,FlashMaterialComponent script)
    {
        if(!isEnable) script.ResetFlashMaterialEmission();
        SwitchEnableScript(isEnable, script);
    }

    /// <summary>
    /// StartTalk�@�\�̃I���I�t�X�C�b�`�p
    /// ��Script��Enable��؂邾���ł͊ђʂ��ē����Ă��܂��ׁAisTalking�Ŏ~�߂Ă��܂�
    /// </summary>
    public void SwitchEnableStartTalk(bool isEnable, ClickStartTalkComponent script)
    {
        script.isTalking = !isEnable;
        SwitchEnableScript(isEnable, script);
    }

    /// <summary>
    /// �w��X�N���v�g�̋@�\�I���I�t�X�C�b�`
    /// </summary>
    public void SwitchEnableScript(bool isEnable, MonoBehaviour script)
    {
        script.enabled = isEnable;
    }
}