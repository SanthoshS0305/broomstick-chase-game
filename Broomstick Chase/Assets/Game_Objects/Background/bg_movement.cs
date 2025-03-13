using UnityEngine;

public class bg_movement : MonoBehaviour
{
    public float speed=6f;
    private Logic_Script logic;
    void Start()
    {
        logic=GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.game_state){
            transform.position+=Vector3.left*speed*Time.deltaTime;
            if (transform.position.x<-88.92f){
                transform.position=new Vector3(88.92f, transform.position.y,transform.position.z);
            }
        }
    }
}
