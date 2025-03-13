using System;
using UnityEngine;

public class snitch_movement : MonoBehaviour
{
    
    private Logic_Script logic;
    private float height_offset=22;
    public float speed=10;
    float offset;
    void Start()
    {
        offset=(float)Math.Round(UnityEngine.Random.Range(-height_offset, height_offset), 2);
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            if (Math.Round(transform.position.y)==Math.Round(offset)){
                offset=(float)Math.Round(UnityEngine.Random.Range(-height_offset, height_offset), 2);
            }
            transform.position=Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, offset, transform.position.z), speed*Time.deltaTime);
        }
    }
}
