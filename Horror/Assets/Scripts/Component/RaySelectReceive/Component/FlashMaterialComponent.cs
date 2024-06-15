using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// このコンポーネント下にある子のMeshRendererを全部拾って
/// Emissionを使用してflashColorの色で点滅させる
/// フェード時間やflashColorの強弱はAnimationCurveで設定する
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

        // マテリアルの変更するパラメータを事前に知らせる
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
        // このスクリプトの子のMeshRendererを全部拾う
        MeshRenderer[] meshRenderers = this.GetComponentsInChildren<MeshRenderer>();

        // 各MeshRendererの中にあるマテリアルをリスト変数に全部入れる
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

        // 内部時刻をfadeTimeで折り返す
        if (time > fadeTime)
            //Mathf.Repeatで0～fadeTimeの範囲の値が得られる
            time = Mathf.Repeat((float)time, fadeTime);

        // アニメーションカーブに従ったアルファ値計算
        float alpha = _intensityCurve.Evaluate((float)time);


        // 内部時刻timeにおける明滅状態を反映
        foreach (Material material in target_material)
        {
            material.SetColor("_EmissionColor", new Color(flashColor.r * alpha, flashColor.g * alpha, flashColor.b * alpha));
        }
    }

    public void ResetFlashMaterialEmission()
    {
        // 明滅状態を0にリセット
        foreach (Material material in target_material)
        {
            material.SetColor("_EmissionColor", new Color(RESET_ALPHA_VALUE, RESET_ALPHA_VALUE, RESET_ALPHA_VALUE));
        }
    }
}
