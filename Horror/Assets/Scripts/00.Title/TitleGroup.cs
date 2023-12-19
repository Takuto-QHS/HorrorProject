using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleGroup : MonoBehaviour
{
    [SerializeField]
    private GameObject groupTitle;
    [SerializeField]
    private GameObject groupSelect;

    public void OnClick()
    {
        groupTitle.SetActive(false);
        groupSelect.SetActive(true);
    }
}
