using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawnScript : MonoBehaviour {

    public int m_spawnNum = 10;
    public GameObject m_Stage;
    public GameObject m_pointCube;

    private int m_StageScale_x, m_StageScale_z;

	// Use this for initialization
	void Start () {
        m_StageScale_x = (int)m_Stage.transform.localScale.x;
        m_StageScale_z = (int)m_Stage.transform.localScale.z;

        //設定した分のCubeをランダムに生成
        for (int i = 0; i < m_spawnNum; i++){
            Instantiate(m_pointCube, new Vector3(Random.Range(-m_StageScale_x/2, m_StageScale_x/2), Random.Range(2, 5), Random.Range(-m_StageScale_z/2, m_StageScale_z/2)), Quaternion.identity);
        }
	}
}
