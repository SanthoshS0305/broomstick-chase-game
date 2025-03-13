using System;
using UnityEngine;

public class chaser_spawner : MonoBehaviour
{
    private Logic_Script logic;
    public GameObject chaser;
    public float spawn_rate=0.5F;
    private float timer=0;
    public float height_offset=22;
    public float step;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            if (timer<spawn_rate){
            timer+=Time.deltaTime;
        }
        else{
            Spawn();
            timer=0;
        }
        }
    }
    private void Spawn(){
            float lower_bound=transform.position.y-height_offset;
            float upper_bound=transform.position.y+height_offset;
            float y_random_pos=UnityEngine.Random.Range(lower_bound/step, upper_bound/step)*step;
            Vector3 spawn_pos=new Vector3(transform.position.x, y_random_pos, transform.position.z);
            Instantiate(chaser, spawn_pos, transform.rotation);
    }
}
