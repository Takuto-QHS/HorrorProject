using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̎������I�u�W�F�N�g�ɓ�����������
/// ���̃I�u�W�F�N�g�̑S�Ă̎q�̃A�E�g���C����\������X�N���v�g
/// </summary>
public class SelectRayOutlineComponent : IPlayerSelectRayReceive
{
    [SerializeField]
    private Color outlineColor = Color.cyan;
    private Outline outline;

    void Start()
    {
        // �A�E�g���C����ǉ����Ċe��ݒ�
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 0.0f;
    }

    public override void FirstHit()
    {
        SwitchOutline(true);
    }

    public override void HitNow(){}

    public override void NotHit()
    {
        SwitchOutline(false);
    }

    void SwitchOutline(bool isEenable)
    {
        if (isEenable)
        {
            if (outline.OutlineMode == Outline.Mode.OutlineAll) return;
            outline.OutlineWidth = 2.0f;
        }
        else
        {
            outline.OutlineWidth = 0.0f;
        }
    }
}
