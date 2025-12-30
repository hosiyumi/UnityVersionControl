using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    [SerializeField] private Text CheeriesText;
    [SerializeField] private AudioSource collectsound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cherry"))
        {
            Destroy(collision.gameObject);
            cherries ++;
            CheeriesText.text = "Cheereis:" + cherries;
            collectsound.Play();
            //碰撞到带有樱桃标签的对象时，销毁对象并使玩家获得的樱桃+1，播放拾取的音源
        }
    }
}
