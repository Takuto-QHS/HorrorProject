using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Select中に左クリックするとチャットが出るスクリプト
/// </summary>
public class ClickStartTalk : SelectionHighliting
{
    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    public override void HitNow()
    {
        if(Input.GetMouseButtonDown(0))
        {
            flowchart.SendFungusMessage(strMessage);
        }
    }
}
