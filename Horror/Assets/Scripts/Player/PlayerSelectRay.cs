using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーカメラから視点の先にレイを飛ばして
/// IPlayerSelectRayReceiveが継承元にあるスクリプトを取ってきて
/// 各タイミングで関数を叩く
/// 
/// ※Physics Raycasterを使いたい所だが、Cursor.lockStateをLockedにすると
/// 　Physics Raycasterが使えなくなる為自作しています。
/// </summary>
public class PlayerSelectRay : MonoBehaviour
{
    public List<IPlayerSelectRayReceive> selectReceiveObj = new List<IPlayerSelectRayReceive>();

    private Camera playerCamera;
    [SerializeField]
    private float distance = 1.0f;

    // Update is called once per frame
    void Update()
    {
        // 準備
        playerCamera = gameObject.GetComponent<Camera>();
        Vector3 rayStartPosition = playerCamera.transform.position;
        Vector3 rayDirection = playerCamera.transform.forward.normalized;
        RaycastHit raycastHit;

        // Rayを飛ばす（out raycastHit でHitしたオブジェクトを取得する）
        bool isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // 何かヒットした時
        if (isHit)
        {
            IPlayerSelectRayReceive[] tempReceive = raycastHit.collider.gameObject.GetComponents<IPlayerSelectRayReceive>();

            // ヒットしたObjに受信側スクリプトが1つ以上あるか
            if(tempReceive.Length != 0)
            {
                foreach(IPlayerSelectRayReceive receive in tempReceive)
                {
                    // 初ヒットか
                    if (selectReceiveObj.Count == 0)
                    {
                        receive.FirstHit();
                        selectReceiveObj.Add(receive);
                    }
                    else
                    {
                        // ヒット中
                        receive.HitNow();
                    }
                }
            }
            else
            {
                // 保持中のreceiveObjがある場合
                if (selectReceiveObj.Count != 0)
                {
                    foreach (IPlayerSelectRayReceive receive in selectReceiveObj)
                    {
                        receive.NotHit();
                    }
                    selectReceiveObj.Clear();
                }
            }
        }
        // 何もヒットしなかった時
        else
        {
            // 保持中のreceiveObjがある場合
            if (selectReceiveObj.Count != 0)
            {
                foreach (IPlayerSelectRayReceive receive in selectReceiveObj)
                {
                    receive.NotHit();
                }
                selectReceiveObj.Clear();
            }
        }
    }
}
