using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	//スコアを表示するGUIText
	public GUIText scoreGUIText;

	//ハイスコアを表示するGUIText;
	public GUIText highScoreGUIText;

	//スコア
	private int score;

	//ハイスコア
	private int highScore;

	//PlayerPrefsで保存するためのキー
	private string highScoreKey = "highScore";

	// Use this for initialization
	void Start () {
		Initialize ();
	}
	
	// Update is called once per frame
	void Update () {

		//スコアがハイスコアより大きい
		if (highScore < score) {
			highScore = score;
		}
		//スコア・ハイスコアの表示
		scoreGUIText.text = score.ToString ();
		highScoreGUIText.text = "HighScore : " + highScore.ToString ();
	}

	//ゲーム開始前の状態に戻す
	private void Initialize ()
	{
		//スコアを0に戻す
		score = 0;

		//ハイスコアを取得する。保存されてなければ0を取得する.
		highScore = PlayerPrefs.GetInt (highScoreKey, 0);
	}

	//ポイントの追加
	public void AddPoint (int point)
	{
		score = score + point;
	}

	//ハイスコアの保存
	public void Save()
	{
		//ハイスコアを保存する
		PlayerPrefs.SetInt (highScoreKey, highScore);
		PlayerPrefs.Save ();

		//ゲーム開始前の状態に戻す
		Initialize ();
	}

}
