using System;
using Unity.VisualScripting;
using UnityEngine;

public class bludger_movement : MonoBehaviour
{
    private Logic_Script logic;
    public float speed_multiplier;
    private float offset;
    private float init_y;
    public float height_offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init_y=transform.position.y;
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            if (Math.Round(transform.position.y)==Math.Round(offset)){
                offset=(float)Math.Round(UnityEngine.Random.Range(-height_offset, height_offset), 2);
                Debug.Log("chaser offset: "+offset);
            }
            if (init_y+offset>20.8){
                offset=20.8f-init_y;
            }
            else if (init_y+offset<-20.8){
                offset=-20.8f-init_y;
            }
            transform.position=Vector3.MoveTowards(transform.position, new Vector3(-60, init_y+offset, transform.position.z), speed_multiplier*Time.deltaTime);            
            if (transform.position.x<-50){
                Destroy(gameObject);
            }
        }
    }
    //on hit, reset score and trigger knockback conditions
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer==6){
            logic.missed=false;
            logic.reset_score();
        }
        else if (!logic.knocked_state&&collision.gameObject.layer==8){
            logic.add_score(1);
        }
        //Debug.Log("bludger trigger"+logic.score_text.text+" layer="+collision.gameObject.layer);
    }
}
