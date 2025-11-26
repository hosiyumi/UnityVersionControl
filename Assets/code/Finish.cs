using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool completelevel = false;

    void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    //2D碰撞函数，参数为2D碰撞器
    {
        if(collision.gameObject.name == "Player" && !completelevel)
        //旗帜接触到玩家  并且  没有触发关卡结束
        {
            finishsound.Play();
            completelevel = true;
            Invoke("CompleteLevel",2f);
            //Invoke函数会在2.0秒后调用CompleteLevel函数
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        //切换到下一个场景
    }
}
