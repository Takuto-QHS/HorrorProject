using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStartTalk : MonoBehaviour
{

    [SerializeField]
    private Fungus.Flowchart flowchart = null;
    [SerializeField]
    private string strMessage = null;

    private void OnTriggerEnter(Collider other)
    {
        StartTalk();
    }

    private void StartTalk()
    {
        // ‰ï˜bŠJŽn
        flowchart.SendFungusMessage(strMessage);
    }
}
