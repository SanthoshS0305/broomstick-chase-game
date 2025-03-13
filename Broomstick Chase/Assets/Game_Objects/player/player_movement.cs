using System.Numerics;
using UnityEngine;
using UnityEngine.UIElements;

public class player_movement : MonoBehaviour
{
    public float movement_sensitivity;
    public float knockback;
    private Logic_Script logic;
    public float accel_rate;
    public int knockback_accel;
    public UnityEngine.Vector3 knocked_location;
    public float knock_magnitude;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        knocked_location=transform.position;
        Debug.Log("Start Position: "+transform.position);
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
        logic.missed=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            if (transform.position.x>37.5){
                Debug.Log("End Game with Loss, Score="+logic.score_text.text+"\nKnockback Pos "+knocked_location);
        
                logic.game_state=false;
                logic.game_over(0);
            }
            if (!logic.missed){
                //negative offset to knockback
                float knocked_dist = transform.position.x-knock_magnitude;
                //knockback limit @ border
                if (knocked_dist<-37.5){
                    knocked_dist=-37.5f;
                }
                //if !missed, set knocked location to negative offset
                knocked_location= new UnityEngine.Vector3(knocked_dist, transform.position.y,transform.position.z);
                Debug.Log(transform.position+" and "+knocked_location);
                //logic.reset_score();
                logic.missed=true;
                logic.knocked_state=true;
            }
            //if knocked location==current location, then there is no knockback
            if (knocked_location.x==transform.position.x){
                logic.knocked_state=false;
                //standard acceleration in +ve x axis
                transform.position+=UnityEngine.Vector3.right*accel_rate*Time.deltaTime;
                knocked_location=transform.position;
                //vertical movement controls
                if (transform.position.y<20.8&&(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.UpArrow))){
                transform.position+=UnityEngine.Vector3.up*Time.deltaTime*movement_sensitivity;
                }
                if (transform.position.y>-20.8&&(Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.DownArrow))){
                    transform.position+=UnityEngine.Vector3.down*Time.deltaTime*movement_sensitivity;
                }
            }
            if (transform.position.x<37.5){
                transform.position=UnityEngine.Vector3.MoveTowards(transform.position, knocked_location, knockback_accel*Time.deltaTime);
            }
        }
    }
}
