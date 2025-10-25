using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("이동 설정")]
    public float walkSpeed = 3.0f;
    public float runSpeed = 6.0f;
    public float rotationSpeed = 10.0f;
    public float gravity = -9.81f;

    [Header("공격 설정")]
    public float attackDuration = 0.8f; //공격 지속 시간
    public bool canMoveWhileAttacking = false; //공격중 이동 가능 여부 판단 bool

    [Header("컴포넌트")]
    public Animator animator; //컴포넌트 하위에 animator 가 존재하기 때문에

    private CharacterController controller;
    public CinemachineVirtualCamera virtualCam;
    private CinemachinePOV pov;

    [Header("체력 변수")]
    public float maxHP = 100f;
    public float currentHP;

    [Header("화염방사기")]
    public ParticleSystem Flame;

    //현재 상태 값들
    private float currentSpeed;
    //private bool isAttacking = false;
    private Vector3 velocity;
    private bool isGrounded;

    public Slider hpSlider;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        pov = virtualCam.GetCinemachineComponent<CinemachinePOV>();

        currentHP = maxHP;
        Flame.Stop();
        hpSlider.value = 1f;
    }

    void Update()
    {
        HandleMovement();
        UpdateAnimaotor();
        FlameEffect();
    }

    void HandleMovement() //이동 함수 제작
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float verical = Input.GetAxis("Vertical");
         
            Vector3 camForward = virtualCam.transform.forward;
            camForward.y = 0;
            camForward.Normalize();

            Vector3 camRight = virtualCam.transform.right;
            camRight.y = 0;
            camRight.Normalize();

            Vector3 move = (camForward * verical + camRight * horizontal).normalized;
            controller.Move(move * currentSpeed * Time.deltaTime);

            float cameraYaw = pov.m_HorizontalAxis.Value;
            Quaternion targetRot = Quaternion.Euler(0f, cameraYaw, 0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);


            if (Input.GetKey(KeyCode.LeftShift)) //왼쪽 Shift 를 눌러서 Run 모드로 변경
            {
                currentSpeed = runSpeed;
                virtualCam.m_Lens.FieldOfView = 80;
            }
            else
            {
                currentSpeed = walkSpeed;
                virtualCam.m_Lens.FieldOfView = 60;
            }

       

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void UpdateAnimaotor()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float moveAmount = new Vector2(horizontal, vertical).magnitude;

        // Shift키 누르면 달리기, 아니면 걷기
        if (Input.GetKey(KeyCode.LeftShift))
            animator.SetFloat("speed", moveAmount * 1f, 0.1f, Time.deltaTime);
        else
            animator.SetFloat("speed", moveAmount * 0.5f, 0.1f, Time.deltaTime);
    }

    void FlameEffect()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Flame.Play();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Flame.Stop();
        }
    }

    public void TakeDamage(float damage)
    {
        currentHP -= damage;
        hpSlider.value = (float)currentHP / maxHP;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SceneObject>() != null)
        {
            string info = other.GetComponent<SceneObject>().objectInfo;
            if (info.StartsWith("Scene"))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(info);
            }
        }
    }
}



