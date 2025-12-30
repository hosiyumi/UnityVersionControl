
using UnityEngine;

using UnityEngine.UI;

public class Scoring : MonoBehaviour
{
    // private bool GetScore = true;
    private int score = 0;
    public bool message = false;
    [SerializeField] private Text Text_1;
    public void Scoreget(bool message) 
    {
        if(message)
        {
            score += 10;
            Debug.Log("get score message!");
            message = false;
            Text_1.text = "Score:" + score;
        }
    }
    void Update()
    {
        
    }

    

}
