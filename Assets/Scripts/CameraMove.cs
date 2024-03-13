using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 position_move = new Vector3(0, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        this.transform.rotation = Quaternion.Euler(45, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 t_position = target.transform.position;
        this.transform.position = t_position + new Vector3(0, 30, -30) + position_move;
        if(Input.GetKey(KeyCode.E))
        {
            if(this.transform.position.y < 40)
            {
                this.transform.Rotate(10 * Time.deltaTime, 0, 0);
                position_move += new Vector3(0, 11f, -12f) * Time.deltaTime;
            }
            
        }
        else if(Input.GetKey(KeyCode.Q))
        {
            if(this.transform.position.y > 10)
            {
                this.transform.Rotate(-10 * Time.deltaTime, 0, 0);
                position_move += new Vector3(0, -11f, 12f) * Time.deltaTime;
            }   
        }
    }
}
