using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{


    public float MoveSpeed; // 移动速度
    public Tile tile;
    private bool _TileActive;

    void Update()
    {
        Player_Move();
    }

    void Player_Move()
    {
        if(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.LeftArrow))
        {this.transform.position += Vector3.left*MoveSpeed*Time.deltaTime;}
        else if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {this.transform.position += Vector3.right*MoveSpeed*Time.deltaTime;}

        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }

    private void shoot()
    {
    if (!_TileActive)
        {
            Tile tile = Instantiate(this.tile,this.transform.position,Quaternion.identity);
            tile.destroyed += TileDestory;
            _TileActive = true;

        }
    }

    private void TileDestory()
    {
        _TileActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
