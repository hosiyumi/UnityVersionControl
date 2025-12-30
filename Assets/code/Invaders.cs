
using UnityEngine;

public class Invaders : MonoBehaviour
{
    public Invader[] prefebs;
    public int rows ;
    public int columns ;
    public float air;
    public AnimationCurve speed;

    public int amountKilled {get;private set;}//
    public int totalInvaders => this.rows * this.columns;//
    public float percentkilled => (float)this.amountKilled/(float)totalInvaders;
    private Transform EnemyManager;
    Vector3 _direction = Vector2.right;


    private void Awake()
    {
        EnemyManager = GetComponent<Transform>();
        float width = this.columns - 1;
        float height = this.rows -1; 
        
        

        for (int row = 0; row < this.rows; row++)//批量实例化并移动
        {
            Vector2 centering = new Vector2(EnemyManager.position.x + -width /2,EnemyManager.position.y + -height /2);
            Vector3 rowposition = new Vector3(centering.x, centering.y + (row * 1.0f), 0.0f);

            for (int col = 0; col < this.columns; col++)
            {
                Invader invader = Instantiate(this.prefebs[row],this.transform);//实例化预制件
                invader.killed += InvaderKilled;
                Vector3 position = rowposition;
                position.x += col * air;
                invader.transform.position = position;
            }
        }
    }

    private void Update()
    {
        this.transform.position += _direction * this.speed.Evaluate(this.percentkilled) * Time.deltaTime;


        foreach(Transform invader in this.transform)
        {
            if(!invader.gameObject.activeInHierarchy)
            {continue;}
            if (_direction == Vector3.right && invader.position.x >= 4.5)
            {AdvanceRow();}
            else if (_direction == Vector3.left && invader.position.x <= -4.5  )
            {AdvanceRow();}
        }
    }

    private void AdvanceRow()
    {
        _direction.x *= -1.0f;

        Vector3 position = this.transform.position;
        position.y -= 0.5f;
        this.transform.position = position;
    }

    private void InvaderKilled()
    {
    this.amountKilled++;
    }
}
