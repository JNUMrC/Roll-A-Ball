using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    private Rigidbody rd;

    public int force = 5;

    private int score = 0;

    public Text text;
    public Text left;
    public Text right;

    public GameObject winText;

	// Use this for initialization
	void Start () {
        rd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h,0,v) * force);
	}

    void OnCollisionEnter(Collision collision) {
        //collision.collider//获取碰撞到的物体身上的Collider组件
        //string name = collision.collider.name;//获取碰撞到物体的名字
        //print(name);//print 可以把内容显示到控制台
        if(collision.collider.tag == "PickUp"){
            Destroy(collision.collider.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        left.text = collider.tag;
        right.text = collider.name;
        if(collider.tag == "PickUp") {
            score++;
            text.text = score.ToString();
            if (score == 11)
            {
                winText.SetActive(true);
            }
            Destroy(collider.gameObject);
        }
    }

}
