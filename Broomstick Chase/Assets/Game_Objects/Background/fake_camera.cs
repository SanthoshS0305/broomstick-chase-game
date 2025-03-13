using Unity.IntegerTime;
using UnityEngine;
using UnityEngine.Timeline;

public class fake_camera : MonoBehaviour
{
    private Logic_Script logic;
    private player_movement player;
    public float rate;
    private Vector3 init_pos;
    private Vector3 player_init_pos;
    public float upper, lower;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        init_pos=transform.position;
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
        player=GameObject.FindGameObjectWithTag("Player_wrap").GetComponent<player_movement>();
        player_init_pos=player.transform.position;
        Debug.Log(init_pos+" "+player_init_pos);
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            float y_offset=540-player.transform.position.y;
            if (y_offset>lower&&y_offset<upper){
                transform.position=Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, y_offset, transform.position.z), rate*Time.deltaTime);
            }
        }
    }
}
