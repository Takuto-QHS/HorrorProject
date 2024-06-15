using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���̃R���|�[�l���g���ɂ���q��MeshRenderer��S���E����
/// Emission���g�p����flashColor�̐F�œ_�ł�����
/// �t�F�[�h���Ԃ�flashColor�̋����AnimationCurve�Őݒ肷��
/// </summary>

public class FlashMaterialComponent : MonoBehaviour
{
    const float RESET_ALPHA_VALUE = 0.0f;

    [SerializeField]
    Color flashColor = Color.white;
    [SerializeField]
    private AnimationCurve _intensityCurve = AnimationCurve.Linear(0, 0, 1, 1);

    private List<Material> target_material = new List<Material>();
    private float fadeTime = 0.0f;
    private float time = 0.0f;

    void Awake()
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
    }

    void Update()
    {
        FlashMaterialEmission();
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

    void FlashMaterialEmission()
    {
        time += Time.deltaTime;

        // ����������fadeTime�Ő܂�Ԃ�
        if (time > fadeTime)
            //Mathf.Repeat��0�`fadeTime�͈̔͂̒l��������
            time = Mathf.Repeat((float)time, fadeTime);

        // �A�j���[�V�����J�[�u�ɏ]�����A���t�@�l�v�Z
        float alpha = _intensityCurve.Evaluate((float)time);


        // ��������time�ɂ����閾�ŏ�Ԃ𔽉f
        foreach (Material material in target_material)
        {
            material.SetColor("_EmissionColor", new Color(flashColor.r * alpha, flashColor.g * alpha, flashColor.b * alpha));
        }
    }

    public void ResetFlashMaterialEmission()
    {
        // ���ŏ�Ԃ�0�Ƀ��Z�b�g
        foreach (Material material in target_material)
        {
            material.SetColor("_EmissionColor", new Color(RESET_ALPHA_VALUE, RESET_ALPHA_VALUE, RESET_ALPHA_VALUE));
        }
    }
}
