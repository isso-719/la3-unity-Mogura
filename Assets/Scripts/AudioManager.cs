using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource buttonSE;
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ゲーム開始時の処理
    public void GameStart()
    {
        // スタートボタンクリック時の効果音を流す
        buttonSE.Play();

        //音がなり終わったら, ゲーム開始とし, BGMを流す
        StartCoroutine(Checking(() => {
            GameManager.isPlaying = true;
            bgm.Play();
        }));
    }

    //音がなり終わったかどうか確認する
    public delegate void functionType();
    IEnumerator Checking(functionType callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!buttonSE.isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
