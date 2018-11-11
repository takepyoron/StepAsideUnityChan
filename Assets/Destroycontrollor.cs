using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroycontrollor : MonoBehaviour {
    //カメラのオブジェクト
    private GameObject maincamera;


	// Use this for initialization
	void Start () {
        //カメラオブジェクトの取得
        this.maincamera=GameObject.Find("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
        //アイテムのｚ軸座標がカメラのｚ軸座標より小さいとき
        if (this.transform.position.z < maincamera.transform.position.z)
        {
            //アイテムオブジェクトを破棄する
            Destroy(this.gameObject);
        }
	}
}
