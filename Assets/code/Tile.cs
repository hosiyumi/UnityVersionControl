using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Tile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;
    private void Update()
    {
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.destroyed.Invoke();
        Destroy(this.gameObject);
    }

    public static explicit operator TileBase(Tile v)
    {
        throw new NotImplementedException();
    }
}
