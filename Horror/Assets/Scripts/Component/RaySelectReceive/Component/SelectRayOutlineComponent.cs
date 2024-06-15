using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̎������I�u�W�F�N�g�ɓ�����������
/// ���̃I�u�W�F�N�g�̑S�Ă̎q�̃A�E�g���C����\������X�N���v�g
/// 
/// ���uNot allowed to access vertex data on mesh...�v�Ƃ����G���[���o���ꍇ�A
/// �ȉ���URL���Q�l��FBX��Read/Write��ҏW���鎖�ŏC���o���܂�
/// https://qiita.com/supertask/items/c4e116255fa81fc26590
/// </summary>
public class SelectRayOutlineComponent : IPlayerSelectRayReceive
{
    private const float DEFAULT_OUTLINE_WIDTH = 0.0f;

    public bool isDisplay = true ;  // �O�����炱�̋@�\�̃I���E�I�t��M��p

    [SerializeField]
    private Color outlineColor = Color.cyan;
    [SerializeField]
    private float outlineWidth = 2.0f;
    private Outline outline;

    void Start()
    {
        // �A�E�g���C����ǉ����Ċe��ݒ�
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = DEFAULT_OUTLINE_WIDTH;
    }

    public override void FirstHit()
    {
        if (!isDisplay) return;
        SwitchOutline(true);
    }

    public override void HitNow(){}

    public override void NotHit()
    {
        if (!isDisplay) return;
        SwitchOutline(false);
    }

    void SwitchOutline(bool isEnable)
    {
        if (isEnable)
        {
            if (outline.OutlineMode == Outline.Mode.OutlineAll) return;
            outline.OutlineWidth = outlineWidth;
            return;
        }
        outline.OutlineWidth = DEFAULT_OUTLINE_WIDTH;
    }
}
