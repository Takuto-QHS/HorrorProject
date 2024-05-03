using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Timeline��SignalEmitter�Ŏg�p����֐�
/// </summary>

public class TimelineEmitter : MonoBehaviour
{
    private Animator animator;              // �A�j���[�V�����N���p
    private float crossFadeTime = 0.1f;     // �A�j���[�V�����N���p

    /// <summary>
    /// �i�s�x��1�i�߁A�w��Q�[���I�u�W�F�N�g��j��
    /// </summary>
    public void NextStep(GameObject obj)
    {
        GameManager.gameManager.OneStepProgressing();
        Destroy(obj);
    }

    /// <summary>
    /// �v���C���[�̑�����A�����b�N(�󂯕t����)
    /// </summary>
    public void UnLockPlayer()
    {
        GameManager.gameManager.UnLockPlayer();
    }

    /// <summary>
    /// animator�ϐ��ɃZ�b�g����(SetAnimation�ƕ��p)
    /// </summary>
    public void SetAnimator(Animator _animator)
    {
        animator = _animator;
    }

    /// <summary>
    /// stateName��Animator���̃A�j���[�V�����������鎖�ŋN��
    /// </summary>
    public void SetAnimation(string stateName)
    {
        animator.CrossFade(stateName, crossFadeTime);
    }
}
