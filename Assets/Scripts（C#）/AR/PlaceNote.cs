// using UnityEngine;
// using Vuforia;

// public class PlaceNote : MonoBehaviour
// {
//     public GameObject notePrefab;
//     public float yOffset = 0.01f;   // 仅抬高 1cm，避免与平面重叠闪烁

//     private PlaneFinderBehaviour planeFinder;

//     void Start()
//     {
//         planeFinder = GetComponent<PlaneFinderBehaviour>();
//     }

//     void Update()
//     {
//         if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
//         {
//             planeFinder?.PerformHitTest(Input.GetTouch(0).position);
//         }
//     }

//     public void AnchorCreated(HitTestResult result)
//     {
//         if (result == null) return;

//         Vector3 position = result.Position;
//         position.y += yOffset;  // 略微抬高，使其浮在平面表面上

//         // 便签平躺：不旋转（或者只绕 Y 轴设置一个固定方向，例如随机角度）
//         Quaternion rotation = Quaternion.identity;
//         // 可选：随机绕 Y 轴旋转，使便签朝向不同方向
//         // rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

//         Instantiate(notePrefab, position, rotation);
//     }
// }

using UnityEngine;
using Vuforia;

public class PlaceNote : MonoBehaviour
{
    public GameObject notePrefab;
    public float offset = 0.01f;

    private PlaneFinderBehaviour planeFinder;

    void Start()
    {
        planeFinder = GetComponent<PlaneFinderBehaviour>();
    }

    void Update()
    {
        // 只有当用户点击屏幕时才进行射线检测
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            planeFinder?.PerformHitTest(Input.GetTouch(0).position);
        }
    }

    /// <summary>
    /// 当 Vuforia 检测到平面并点击后调用
    /// </summary>
    public void AnchorCreated(HitTestResult result)
    {
        if (result == null || notePrefab == null) return;

        // --- 1. 计算旋转（扶正逻辑） ---
        Vector3 surfaceNormal = result.Rotation * Vector3.up;
        Quaternion finalRotation;

        if (Mathf.Abs(surfaceNormal.y) < 0.5f) // 墙面
        {
            // 头部强制对齐世界坐标上方
            finalRotation = Quaternion.LookRotation(surfaceNormal, Vector3.up);
        }
        else // 地面
        {
            // 正脸强制对着相机水平方向
            Vector3 camForward = Camera.main.transform.forward;
            camForward.y = 0;
            if (camForward.sqrMagnitude < 0.01f) camForward = Camera.main.transform.up;
            finalRotation = Quaternion.LookRotation(camForward, Vector3.up);
        }

        // --- 2. 核心修复：创建物理锚点防止飘移 ---
        // 创建一个空物体作为锚点节点
        GameObject anchorObj = new GameObject("NoteAnchor");
        anchorObj.transform.position = result.Position;
        anchorObj.transform.rotation = finalRotation;
        
        // 关键：挂载 AnchorBehaviour 告诉系统这是需要持久化追踪的物理点
        anchorObj.AddComponent<AnchorBehaviour>();

        // --- 3. 生成便签并设置为锚点的子物体 ---
        GameObject instantiatedNote = Instantiate(notePrefab, anchorObj.transform);
        
        // 将便签在本地空间内根据 offset 稍微抬高（防止与平面重叠闪烁）
        // 在该旋转下，Vector3.up 是指向平面外部的
        instantiatedNote.transform.localPosition = new Vector3(0, offset, 0); 
        instantiatedNote.transform.localRotation = Quaternion.identity;
    }
}