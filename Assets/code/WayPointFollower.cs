using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int WayPointIndex = 0;
    [SerializeField] private float speed = 2f;
    private void Update()
    {
        if(Vector2.Distance(waypoints[WayPointIndex].transform.position,transform.position) < .01f)//判断：对象触碰到航路点
        {
            WayPointIndex++;
            if (WayPointIndex >= waypoints.Length)
            {
                WayPointIndex = 0;
            }
        }
        transform.position =Vector2.MoveTowards(transform.position,waypoints[WayPointIndex].transform.position,speed*Time.deltaTime);
        //使用帧差确保每秒移动的距离统一，不会因为不同的帧率导致每秒出现不同的移动距离，速度*统一每秒帧 = 相同的距离
    }
}
