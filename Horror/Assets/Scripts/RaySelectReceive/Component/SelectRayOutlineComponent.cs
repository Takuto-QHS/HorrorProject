using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーの視線がオブジェクトに当たった時に
/// そのオブジェクトの全ての子のアウトラインを表示するスクリプト
/// 
/// ※「Not allowed to access vertex data on mesh...」というエラーが出た場合、
/// 以下のURLを参考にFBXのRead/Writeを編集する事で修正出来ます
/// https://qiita.com/supertask/items/c4e116255fa81fc26590
/// </summary>
public class SelectRayOutlineComponent : IPlayerSelectRayReceive
{
    private const float DEFAULT_OUTLINE_WIDTH = 0.0f;

    public bool isDisplay = true ;  // 外部からこの機能のオン・オフを弄る用

    [SerializeField]
    private Color outlineColor = Color.cyan;
    [SerializeField]
    private float outlineWidth = 2.0f;
    private Outline outline;

    void Start()
    {
        // アウトラインを追加して各種設定
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
