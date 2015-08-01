﻿using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	//スクロールするスピード
	public float speed = 0.1f;

	// Update is called once per frame
	void Update () {
	
		//時間によってyの値が0から1に変化していく。１になったら戻り、繰り返す
		float y = Mathf.Repeat (Time.time * speed, 1);

		//Yの値がずれていくオフセットを作成
		Vector2 offset = new Vector2 (0, y);

		//マテリアルにオフセットを設定する
		GetComponent<Renderer>().sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}
}