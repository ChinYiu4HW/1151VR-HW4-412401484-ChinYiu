using UnityEngine;
using PinePie.SimpleJoystick;

public class carController : MonoBehaviour
{
    [Header("移動設定")]
    public float moveSpeed = 10f;
    public float forwardSpeed = 10f;
    public float acceleration = 8f;

    [Header("搖桿參考")]
    public JoystickController joystick;

    [Header("音效設定")]
    public AudioSource crashAudioSource;   // 撞擊音效
    public AudioSource engineAudioSource;  // 噴射引擎音效 Looop

    private Rigidbody rb;
    private Vector3 currentVelocity;
    private float throttleInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = false;
            rb.freezeRotation = true;
        }
    }

    void FixedUpdate()
    {
        if (joystick == null) return;

        //移動運算
        Vector2 input = joystick.InputDirection;
        Vector3 targetMoveDir = new Vector3(input.x * moveSpeed, input.y * moveSpeed, throttleInput * forwardSpeed);

        currentVelocity = Vector3.Lerp(currentVelocity, targetMoveDir, acceleration * Time.fixedDeltaTime);
        rb.velocity = currentVelocity;

        //飛船傾斜轉向
        if (input.sqrMagnitude > 0.01f)
        {
            float targetRoll = -input.x * 25f;
            float targetPitch = input.y * 15f;

            Quaternion targetRotation = Quaternion.Euler(targetPitch, 0f, targetRoll);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.identity, 10f * Time.fixedDeltaTime);
        }

        
        // 噴射引擎音效控制-> 前進時播放

        if (engineAudioSource != null)
        {
            // throttleInput < 0 時代表按下了前進按鈕
            if (throttleInput < 0f)
            {
                // 如果聲音還沒播放 -> 開始播放
                if (!engineAudioSource.isPlaying)
                {
                    engineAudioSource.Play();
                }
            }
            else
            {
                // 如果沒有在前進 -> 停止播放
                if (engineAudioSource.isPlaying)
                {
                    engineAudioSource.Stop();
                }
            }
        }
    }

    public void SetThrottleForward(bool isPressed)
    {
        throttleInput = isPressed ? 1f : 0f;
    }

    public void SetThrottleBackward(bool isPressed)
    {
        throttleInput = isPressed ? -1f : 0f;
    }

    // 撞擊音效
    void OnCollisionEnter(Collision collision)
    {
        if (crashAudioSource != null && crashAudioSource.clip != null)
        {
            if (!crashAudioSource.isPlaying)
            {
                crashAudioSource.Play();
            }
        }
    }
}