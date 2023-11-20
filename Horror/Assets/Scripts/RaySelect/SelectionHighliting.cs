using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̎������I�u�W�F�N�g�ɓ�����������
/// ���̃I�u�W�F�N�g�S�ẴA�E�g���C����\������X�N���v�g
/// ���łɃI�u�W�F�N�g�̓_�ł�������
/// </summary>
public class SelectionHighliting : IPlayerSelectRayReceive
{
    private Outline outline;

    [SerializeField]
    private List<Material> target_material;
    [SerializeField]
    private AnimationCurve _intensityCurve = AnimationCurve.Linear(0, 0, 1, 1);
    [SerializeField]
    Color flashColor = Color.red;
    [SerializeField]
    Color outlineColor = Color.cyan;

    private float fadeTime = 0.0f;
    private float time = 0.0f;

    void Start()
    {
        GetMaterials();

        // �}�e���A���̕ύX����p�����[�^�����O�ɒm�点��
        foreach (Material material in target_material)
        {
            material.EnableKeyword("_EMISSION");
        }

        int length = _intensityCurve.length;
        if (length < 1)
            return;

        fadeTime = _intensityCurve.keys[length - 1].time;

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

    void Update()
    {
        FlashMaterialEmission();
    }

    void FlashMaterialEmission()
    {
        time += Time.deltaTime;

        // ����������fadeTime�Ő܂�Ԃ�
        if (time > fadeTime)
        {
            // Mathf.Repeat��0�`fadeTime�͈̔͂̒l��������
            time = Mathf.Repeat((float)time, fadeTime);
        }

        // �A�j���[�V�����J�[�u�ɏ]�����A���t�@�l�v�Z
        float alpha = _intensityCurve.Evaluate((float)time);
        

        // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
        foreach (Material material in target_material)
        {
            material.SetColor("_EmissionColor", new Color(flashColor.r * alpha, flashColor.g * alpha, flashColor.b * alpha));
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

    void SwitchOutline(bool enable)
    {
        if (enable)
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
