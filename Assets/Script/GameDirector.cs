using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDirector : MonoBehaviour
{
    GameObject car;
    GameObject flag;
    GameObject distance;

    [Header("音效設定")]
    public AudioSource reachAudioSource;
    private bool hasReached = false;

    void Start()
    {
        this.car = GameObject.Find("Player");
        this.flag = GameObject.Find("flag");
        this.distance = GameObject.Find("Distance");

    }


    void Update()
    {

        float length = Mathf.Abs(this.flag.transform.position.z - this.car.transform.position.z);

        // 如果還沒到終點就正常顯示距離
        if (!hasReached)
        {
            this.distance.GetComponent<TextMeshProUGUI>().text = "Distance: " + length.ToString("F2") + "m";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        // 檢查撞到旗子的是不是飛船且還沒觸發過
        if (other.gameObject == car && !hasReached)
        {
            hasReached = true;

            
            if (this.distance != null)
            {
                this.distance.GetComponent<TextMeshProUGUI>().text = "GOAL~!";
            }

            // 播放通關音效
            if (reachAudioSource != null && reachAudioSource.clip != null)
            {
                reachAudioSource.Play();
                Debug.Log("碰到終點 Collider，播放通關音效！");
            }
        }
    }






}