using UnityEngine;

public class score_trigger : MonoBehaviour
{
private Logic_Script logic;
    void Start()
    {
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==7){
            Debug.Log("End Game with Win, Score="+logic.score_text.text+" layer="+collision.gameObject.layer);
            logic.game_state=false;
            logic.game_over(1);
        }
    }
}
