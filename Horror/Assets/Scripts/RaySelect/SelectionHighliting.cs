using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの視線がオブジェクトに当たった時に
/// そのオブジェクト全てのアウトラインを表示するスクリプト
/// ついでにオブジェクトの点滅もさせる
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

        // マテリアルの変更するパラメータを事前に知らせる
        foreach (Material material in target_material)
        {
            material.EnableKeyword("_EMISSION");
        }

        int length = _intensityCurve.length;
        if (length < 1)
            return;

        fadeTime = _intensityCurve.keys[length - 1].time;

        // アウトラインを追加して各種設定
        outline = this.gameObject.AddComponent<Outline>();
        outline.OutlineColor = outlineColor;
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineWidth = 0.0f;
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

    void Update()
    {
        FlashMaterialEmission();
    }

    void FlashMaterialEmission()
    {
        time += Time.deltaTime;

        // 内部時刻をfadeTimeで折り返す
        if (time > fadeTime)
        {
            // Mathf.Repeatで0～fadeTimeの範囲の値が得られる
            time = Mathf.Repeat((float)time, fadeTime);
        }

        // アニメーションカーブに従ったアルファ値計算
        float alpha = _intensityCurve.Evaluate((float)time);
        

        // 内部時刻timeにおける明滅状態を反映
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
