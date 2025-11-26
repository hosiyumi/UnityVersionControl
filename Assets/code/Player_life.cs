using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_life : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private AudioSource deathsound; 
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))//如果碰撞到trap图层的对象
        {
            rb.bodyType = RigidbodyType2D.Static;//切换玩家的身体类型为静态(不可移动与交互)
            anim.SetTrigger("death");//播放死亡动画
            deathsound.Play();
        }
    }
    private void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
