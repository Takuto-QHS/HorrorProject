using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの視線がオブジェクトに当たった時に
/// そのオブジェクトの全ての子のアウトラインを表示するスクリプト
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
