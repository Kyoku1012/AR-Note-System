using UnityEngine;
using Vuforia;

public class PlaceNote : MonoBehaviour
{
    public GameObject notePrefab;
    public float yOffset = 0.01f;   // 仅抬高 1cm，避免与平面重叠闪烁

    private PlaneFinderBehaviour planeFinder;

    void Start()
    {
        planeFinder = GetComponent<PlaneFinderBehaviour>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            planeFinder?.PerformHitTest(Input.GetTouch(0).position);
        }
    }

    public void AnchorCreated(HitTestResult result)
    {
        if (result == null) return;

        Vector3 position = result.Position;
        position.y += yOffset;  // 略微抬高，使其浮在平面表面上

        // 便签平躺：不旋转（或者只绕 Y 轴设置一个固定方向，例如随机角度）
        Quaternion rotation = Quaternion.identity;
        // 可选：随机绕 Y 轴旋转，使便签朝向不同方向
        // rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);

        Instantiate(notePrefab, position, rotation);
    }
}