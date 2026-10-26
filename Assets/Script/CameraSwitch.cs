using UnityEngine;
using TMPro;

public class CameraSwitcher : MonoBehaviour
{
    [Header("攝影機設定")]
    public Camera camera1; // 駕駛艙第一人稱camera
    public Camera camera2; // 機尾第三人稱camera

    [Header("模型設定")]
    public GameObject cockpitModel; // 駕駛艙 Camera 1
    public GameObject aircraftBodyModel; // 機身外部 Camera2 

    [Header("UI 設定 (選填)")]
    public TextMeshProUGUI viewText; // 畫面上的視角提示文字

    private bool isCamera1Active = true; // 記錄目前是否為第一人稱

    void Start()
    {
        UpdateViewState();
    }

    void Update()
    {
        // 偵測有沒有按下E鍵
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCamera();
        }
    }

    //手機 UI 按鈕
    public void SwitchCamera()
    {
        isCamera1Active = !isCamera1Active;
        UpdateViewState();
    }

    void UpdateViewState()
    {
        // 切換攝影機
        if (camera1 != null) camera1.enabled = isCamera1Active;
        if (camera2 != null) camera2.enabled = !isCamera1Active;

        // 切換模型的顯示 & 隱藏
        if (cockpitModel != null)
            cockpitModel.SetActive(isCamera1Active); // 第一人稱時顯示駕駛艙，第三人稱時隱藏

        if (aircraftBodyModel != null)
            aircraftBodyModel.SetActive(!isCamera1Active); // 第一人稱時隱藏機身，第三人稱時顯示

        if (viewText != null)
        {
            viewText.text = isCamera1Active ? "View: (1st Person)" : "View: (3rd Person)";
        }
    }
}