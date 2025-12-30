using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    public Sprite[] animationSprites;
    public float animationTime = 0.0f;
    private SpriteRenderer _spriteRender;
    private int _animationFrame;
    public System.Action killed;
    private void Awake() 
    {
        _spriteRender = GetComponent<SpriteRenderer>();//获取精灵
    }

    void Start()
    {
        InvokeRepeating(nameof(AnimateSprite),this.animationTime,this.animationTime);//重复函数

    }

    void Update()
    {

    }

    private void AnimateSprite()//简易动画器函数，显式循环精灵
    {
        _animationFrame++;

        if (_animationFrame >= this.animationSprites.Length)
        {
            _animationFrame = 0;
        }
        _spriteRender.sprite = this.animationSprites[_animationFrame];
        //至少保证有两个精灵，否则会报错 
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {
            this.killed.Invoke();
            this.gameObject.SetActive(false);
    }

}
