using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 10;
	// Use this for initialization

	//ゲームオブジェクト生成から削除されるまでの時間
	public float lifeTime = 5;

	//攻撃力
	public int power = 1;

	void Start () {
		//ローカル座標のy軸方向へ移動
		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * speed;

		//lifeTime秒後に削除
		Destroy (gameObject, lifeTime);
	}

}
