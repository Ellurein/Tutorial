using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//移動スピード
	public float speed = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//右・左
		float x = Input.GetAxisRaw ("Horizontal");
	
		//上・下
		float y = Input.GetAxisRaw ("Vertical");

		//移動する向き決定
		Vector2 direction = new Vector2 (x, y).normalized;

		//移動する向きとスピード代入
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
