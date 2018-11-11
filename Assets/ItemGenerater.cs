using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour {
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すｘ方向の範囲
    private float posRange = 3.4f;
    //ユニティちゃんのオブジェクト
    private GameObject unitychan;
    //アイテム生成位置
    private int zPos;


    // Use this for initialization
    void Start () {
        this.unitychan = GameObject.Find("unitychan");
        zPos = startPos;
	}
	
	// Update is called once per frame
	void Update () {
            if (this.unitychan.transform.position.z>zPos-50 && zPos<=goalPos)
            {
                //どのアイテムを出すかランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab) as GameObject;
                        cone.transform.position = new Vector3(j * 4, cone.transform.position.y,zPos);
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j += 1)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くｚ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置、30%車配置、10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab) as GameObject;
                            coin.transform.position = new Vector3(j * posRange, coin.transform.position.y, zPos + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab) as GameObject;
                            car.transform.position = new Vector3(j * posRange, car.transform.position.y, zPos + offsetZ);
                        }
                    }
                }
            zPos += 15;
            }
        
	}
}
