using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  
    private Rigidbody2D rb;// 刚体
    private BoxCollider2D bc;//2D盒控制器
    private Animator Ani;//动画控制器
    private SpriteRenderer sprite;//精灵
    private enum MovementState {idle,running, jumping,falling}
    //创建一个数据结构，包含四个动画
    [SerializeField] private AudioSource jumpsound;//声音组件



    [SerializeField] private LayerMask lm;//显式声明，图层层级

    private Vector2 Movement; // 移动方向,二维变量
    public float MoveSpeed = 6f; // 移动速度
    public float jumpspeed = 24f;//跳跃速度

    public float PressingTime;//按住时间
    public KeyCode keyToCheck = KeyCode.Space;//要检测的按键
    public float Monitoring_;//速度检测
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        Ani = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ADMove(); //左右移动
        Anima();//动画
        Jump();//跳跃
        PressTimeCheck();
        Dodge();//闪避
        Monitoring_ = Movement.x;
    }


    void FixedUpdate()
    {

    }
    
    void ADMove()
    {
        
        Movement.x = Input.GetAxis("Horizontal"); // A/D 或 左/右键
        //GetAxis 和 GetaxisRaw:"前者能让移动的过渡更加平滑，属于给物体添加一个加速度，后者则是直接改变物体的速度，适用于角色的旋转"
        // movement = movement.normalized;//归一化，在2D平台游戏中是双向+跳跃，所以不需要
        rb.velocity = new Vector2(Movement.x * MoveSpeed, rb.velocity.y);//专注于X轴的移动
        //rb.velocity = movement * moveSpeed * Time.deltaTime;//别让代码做多余的事，这里的数据转移影响了跳跃
        //为什么不设置帧差？“虽然你固定了玩家每秒的移动距离，但移动过程会因为帧率波动导致速度不稳定”
        //“出于玩家游戏体验的考虑，我们需要更稳定的移动，而不是公平的移动速度”
    }

    private void Anima()
    {  
        MovementState state;
        if(Movement.x > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if(Movement.x < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else 
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)//通过检查Y速度，判断是否处于下落或者跳跃上升
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        Ani.SetInteger("state",(int)state);
        
    }

    void Jump()//按下空格键，给玩家一个瞬间向上的力
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpspeed);
            jumpsound.Play();
        }
    }

    void Dodge()
    {
        // if (Input.GetKeyDown(KeyCode.L))
        //     GetComponent<Rigidbody2D>().velocity = new Vector2(jumpspeed, 0);

    }

    void Attack()
    {

    }
    
    void PressTimeCheck()//按键时长检测
    {
           if (Input.GetKey(keyToCheck))
        {
            PressingTime += Time.deltaTime; // 累加按住时间
        }
        else if (Input.GetKeyUp(keyToCheck)) // 按键松开时
        {
            Debug.Log($"按键 {keyToCheck} 按住了 {PressingTime:F2} 秒");
            PressingTime = 0f; // 重置计时器
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, .1f,lm);
    }
}


 