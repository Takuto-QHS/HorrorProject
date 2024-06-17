using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class TriggerObjAddImpulseComponent : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rBObj;

    [SerializeField]
    float waitTime = 3.0f;

    [SerializeField]
    float add_X;
    [SerializeField]
    float add_Y;
    [SerializeField]
    float add_Z;

    async void OnTriggerEnter(Collider other)
    {
        if(rBObj == null) return;
        AddImpulse(rBObj, add_X, add_Y, add_Z);
        rBObj = null;

        await UniTask.Delay(TimeSpan.FromSeconds(waitTime));

        GameManager.gameManager.OneStepProgressing();
    }

    /// <summary>
    /// ボトルを倒す等、瞬間的に力を加える用
    /// </summary>
    public void AddImpulse(Rigidbody rigidbody, float x, float y, float z)
    {
        rigidbody.AddForce(x, y, z, ForceMode.Impulse);
    }
}
