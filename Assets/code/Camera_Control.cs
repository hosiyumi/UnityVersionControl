using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Control : MonoBehaviour
{
    [SerializeField] private Transform player;//显式声明相机位置，方便调试合适的相机偏移
    public Vector3 CameraPosition;

    void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y + CameraPosition.y, CameraPosition.z);
    }
}
