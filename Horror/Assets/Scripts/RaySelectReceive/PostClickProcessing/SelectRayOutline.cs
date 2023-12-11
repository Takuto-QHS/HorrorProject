using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̎������I�u�W�F�N�g�ɓ�����������
/// ���̃I�u�W�F�N�g�̑S�Ă̎q�̃A�E�g���C����\������X�N���v�g
/// </summary>
public class SelectRayOutline : IPlayerSelectRayReceive
{
    private Outline outline;
    private List<Material> target_material = new List<Material>();
    [SerializeField]
    Color outlineColor = Color.cyan;

    void Start()
    {
        GetMaterials();

        // �A�E�g���C����ǉ����Ċe��ݒ�
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 0.0f;
    }

    void GetMaterials()
    {
        // ���̃X�N���v�g�̎q��MeshRenderer��S���E��
        MeshRenderer[] meshRenderers = this.GetComponentsInChildren<MeshRenderer>();

        // �eMeshRenderer�̒��ɂ���}�e���A�������X�g�ϐ��ɑS�������
        foreach (MeshRenderer mesh in meshRenderers)
        {
            foreach (Material material in mesh.materials)
            {
                target_material.Add(material);
            }
        }
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
            if (outline.OutlineMode != Outline.Mode.OutlineAll)
            {
                outline.OutlineWidth = 2.0f;
            }
        }
        else
        {
            outline.OutlineWidth = 0.0f;
        }
    }
}
