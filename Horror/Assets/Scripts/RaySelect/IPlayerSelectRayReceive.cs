using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[���I�u�W�F�N�g�Ɏ����𓖂Ă����p�̊e���΃X�N���v�g
/// </summary>
public class IPlayerSelectRayReceive : MonoBehaviour
{
    /// <summary>
    /// �v���C���[�̎����̓�����n��
    /// </summary>
    public virtual void FirstHit(){}

    /// <summary>
    /// �v���C���[�̎������������Ă�Œ�
    /// </summary>
    public virtual void HitNow(){}

    /// <summary>
    /// �v���C���[�̎����̓�����I���
    /// </summary>
    public virtual void NotHit(){}
}
