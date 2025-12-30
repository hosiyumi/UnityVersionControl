using UnityEngine;

public class StickyPhysic : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(transform); 
            //当移动平台接触到玩家时，将平台设为玩家的父类来实现玩家与平台的一起移动
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
            //当移动平台不再接触到玩家时，将玩家的父类设为空来实现脱离接口
        }
    }
}
