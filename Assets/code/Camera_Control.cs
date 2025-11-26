using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] private Transform player;//显式声明相机位置，方便调试合适的相机偏移
    public Vector3 CameraPosition;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + CameraPosition.y, CameraPosition.z);
    }
    //相机变换位置为玩家X位置，玩家Y位置+偏移量，相机Z位置
}
