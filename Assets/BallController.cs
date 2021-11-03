using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    // スコアを表示するテキスト
    private GameObject ScoreText;
    // スコアの初期値
    private int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // シーン中のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        // 常にScoreTextに現在のスコアを表示　←重そうなので、衝突ごとにした。テキスト初期値はインスペクタに入れた
        //this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);

        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            // GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        //スコアが大きすぎると表示バグが発生し得るため、一定以上になると0にループするカンスト設定
        if (this.score >= 9999999)
        {
            this.score = 0;
            this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);

        }
    }

    // 衝突時のScore加算処理
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            this.score += 10;
            this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);
        }

        else if (collision.gameObject.tag == "LargeStarTag")
        {
            this.score += 500;
            this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);
        }

        else if (collision.gameObject.tag == "SmallCloudTag")
        {
            this.score += 100;
            this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);
        }

        else if (collision.gameObject.tag == "LargeCloudTag")
        {
            this.score += 3000;
            this.ScoreText.GetComponent<Text>().text = string.Format("Score:{0}", this.score);
        }

    }
}
