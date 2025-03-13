using UnityEngine;

public class spec_movement : MonoBehaviour
{
    public float height_offset;
    void Start()
    {
    }

    // Update is called once per frame
    void Update(){
        if (transform.position.y<3){
            transform.position+=Vector3.up*height_offset*Time.deltaTime;
        }
    }
}
