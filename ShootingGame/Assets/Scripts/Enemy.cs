﻿using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	//Spaceshipコンポーネント
	Spaceship spaceship;

	// Use this for initialization
	IEnumerator Start () {
	
		//Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();

		//ローカル座標のY軸のマイナス方向に移動
		spaceship.Move (transform.up * -1);

		if (spaceship.canShot == false) {
			yield break;
		}

		while (true) {

			//子要素を全て取得する
			for (int i = 0; i < transform.childCount; i++) {

				Transform shotPosition = transform.GetChild(i);

				//ShotPositionの位置/角度で弾を撃つ
				spaceship.Shot (shotPosition);
			}

			// shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
