using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {

    public float m_moveSpeed = 10.0f;
    public float m_upSpeed = 10.0f;
    public float m_rotateSpeed = 1.0f;
    public float m_timer = 30.0f;
    public Text m_TimerText;
    public Text m_PointText;
    CubeSpawnScript CSP;

    GameObject m_CubeSpawn;

    private int m_nowNum = 0;
    private int m_ClearNum;


	// Use this for initialization
	void Start () {
        m_CubeSpawn = GameObject.Find("RandomCubeSpawn");
        CSP = m_CubeSpawn.GetComponent<CubeSpawnScript>();
        m_ClearNum = CSP.m_spawnNum;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerMove();
        TimeCount();

	}

    //プレイヤーの移動
    void PlayerMove(){
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += transform.forward * m_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * m_moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0f, 90f, 0f) * m_rotateSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(new Vector3(0f, -90f, 0f) * m_rotateSpeed * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += transform.up * m_upSpeed * Time.deltaTime;
       
        }
    }

    //時間の計算
    void TimeCount(){
        m_timer -= Time.deltaTime;
        m_TimerText.text = m_timer.ToString();
        if(m_timer <= 0f){
            SceneManager.LoadScene("GameOver");
        }
    }

	void OnTriggerEnter(Collider other)
	{
        //落ちた時の処理
        if(other.gameObject.tag == "gameover"){
            SceneManager.LoadScene("GameOver");
        }

        //Cubeを取った時の処理
        if (other.gameObject.tag == "pointcube")
        {
            Destroy(other.gameObject);
            m_nowNum++;

            m_PointText.text = m_nowNum.ToString();

            if(m_ClearNum == m_nowNum){
                SceneManager.LoadScene("GameClear");
            }
        }
	}
}
