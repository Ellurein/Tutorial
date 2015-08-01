using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	/*
	//移動スピード
	public float speed = 5;

	//PlayerBulletプレハブ
	public GameObject bullet;
	*/

	//Spaceshipコンポーネント
	Spaceship spaceship;

	//Startメソッドをコルーチンとして呼び出す
	IEnumerator Start()
	{
		//Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();

		while (true) {
			//弾をプレイヤーと同じ位置/角度で作成
			spaceship.Shot(transform);
			//shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
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
		//GetComponent<Rigidbody2D>().velocity = direction * speed;

		//移動
		spaceship.Move (direction);
	}

	//ぶつかった瞬間呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		//レイヤー名を取得
		string layerName = LayerMask.LayerToName (c.gameObject.layer);

		//レイヤー名がBullet (Enemy)のとき
		if (layerName == "Bullet(Enemy)") {
			//弾の削除
			Destroy (c.gameObject);
		}

		//レイヤー名がBullet (Enemy)またはEnemyのとき
		if (layerName == "Bullet(Enemy)" || layerName == "Enemy") {
			//爆発する
			spaceship.Explosion ();
		
			//プレイヤーを削除
			Destroy (gameObject);
		}
	}


}
