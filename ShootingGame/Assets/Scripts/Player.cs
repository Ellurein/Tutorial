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

			//ショット音を鳴らす
			GetComponent<AudioSource>().Play();

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
		//spaceship.Move (direction);

		//移動の制限
		//Clamp ();

		//移動の制限
		Move (direction);
	}

	/*
	void Clamp()
	{
		//画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));

		//画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//プレイヤーの座標取得
		Vector2 pos = transform.position;

		//プレイヤーの位置が画面内に収まるように制限を描ける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);

		//制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}
	*/

	//機体の移動
	void Move (Vector2 direction)
	{
		//画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		
		//画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		//プレイヤーの座標取得
		Vector2 pos = transform.position;

		//移動量を加える
		pos += direction * spaceship.speed * Time.deltaTime;

		//プレイヤーの位置が画面内に収まるように制限を描ける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		//制限をかけた値をプレイヤーの位置とする
		transform.position = pos;

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
