using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

	//Waveプレハブを格納
	public GameObject[] waves;

	//現在のWave
	private int currentWave;

	// Use this for initialization
	IEnumerator Start () {

		//Waveが存在しなければコルーチンを終了する
		if(waves.Length == 0){
			yield break;
		}

		while (true) {

			//Waveを作成する
			GameObject wave = (GameObject)Instantiate (waves [currentWave], transform.position,
			                                          Quaternion.identity);
			//WaveをEmitterの子要素にする
			wave.transform.parent = transform;

			//Waveの子要素のEnemyが全て削除されるまで待機する
			while (wave.transform.childCount != 0) {
				yield return new WaitForEndOfFrame ();
			}

			//Waveの削除a
			Destroy (wave);

			//格納されているWaveを全て実行したらcurrentWaveを0にする
			if (waves.Length <= ++currentWave) {
				currentWave = 0;
			}
		}
	}

}
