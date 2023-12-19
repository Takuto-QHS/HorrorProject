using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField]
    TitleGroup titleGroup;

    void Start()
    {
        titleGroup.StartTitle();
    }
}
