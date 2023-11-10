using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour //턴제형 Ai 전투 스크립트
{
    public static EnemyAi instance;

    public float HP = 20;
    public int MaxHP = 20;
    public int Power = 1;
    public Slider HPBar;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        HPBar.maxValue = MaxHP;
    }
    private void Update()
    {
        HPBar.value = HP;
        if(HP <= 0)
        {
            Destroy(DIceScript.instance.gameObject);
            Player.Instance.isBattle = false;
            Player.Instance.BattleHPBar.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public float CurAttackAniTime;
    public float AttackTime = 0.005f;
    public float PosX;
    public IEnumerator GoAttackAni()
    {
        Debug.Log(Time.timeScale);
        Debug.Log("EnemyGoAttackAni");
        HPBar.maxValue = MaxHP;
        PosX = transform.position.x;
        CurAttackAniTime = 0f;
        while (CurAttackAniTime <= 1)
        {
            CurAttackAniTime += AttackTime;
            yield return new WaitForSeconds(0.001f);
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(Player.Instance.transform.position.x + 2.5f, transform.position.y, 0), CurAttackAniTime);
        }
        StartCoroutine(BackAttackAni());
        Player.Instance.Health -= Power;
        Instantiate(DIceScript.instance.HitEffect, new Vector2(Player.Instance.transform.position.x + 1,Player.Instance.transform.position.y), Quaternion.identity);
        DIceScript.instance.HitEffect.transform.localScale = new Vector3(1, 1, 1);
    }
    IEnumerator BackAttackAni()
    {
        CurAttackAniTime = 0f;
        while (CurAttackAniTime <= 1f)
        {
            CurAttackAniTime += AttackTime;
            yield return new WaitForSeconds(0.001f);
            transform.position = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, 0), new Vector3(PosX, transform.position.y, 0), CurAttackAniTime);
        }
        StartCoroutine(DIceScript.instance.AttackDice());
    }
}
