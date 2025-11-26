using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    void Update()
    {
        transform.Rotate(0,0,360 * speed * Time.deltaTime);//无需动画，通过脚本旋转锯片
    }
}
