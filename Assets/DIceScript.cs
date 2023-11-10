using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIceScript : MonoBehaviour
{
    public static DIceScript instance;
    public Text DiceNumber;
    public Text TitleText;
    public bool isRandomNumber;
    public GameObject HitEffect;
    Animator ani;
    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
    }
    void Start()
    {
        Player.Instance.Health = Json_DataManager.instance.data.Health;
        Player.Instance.MaxHealth = Json_DataManager.instance.data.MaxHealth;
        EnemyAi.instance.HPBar.gameObject.SetActive(true);
        Player.Instance.BattleHPBar.gameObject.SetActive(true);
        if(!isRandomNumber)
        {
            isRandomNumber = true;
            StartCoroutine(RandomNumber());
        }
    }
    IEnumerator RandomNumber()
    {
        ani.SetTrigger("Shoot");
        Player.Instance.BattleHPBar.maxValue = Player.Instance.MaxHealth;
        yield return new WaitForSeconds(1.2f);
        int rand = Random.Range(1, 3);
        DiceNumber.text = rand.ToString(); //주사위 텍스트 출력
        if (rand == 1)
            TitleText.text = "플레이어 선공!";
        if (rand == 2)
            TitleText.text = "적 선공!";
        yield return new WaitForSeconds(1.7f);
        transform.position = new Vector2(transform.position.x, 1000);
        TitleText.text = "";
        DiceNumber.text = "";
        if (rand == 1)
        {
            StartCoroutine(AttackDice());
        }
        else if (rand == 2)
        {
            StartCoroutine(EnemyAi.instance.GoAttackAni());
        }
        //gameObject.SetActive(false);
    }
    public IEnumerator AttackDice()
    {
        transform.position = new Vector2(transform.position.x,5f);
        ani.SetTrigger("Shoot");
        Debug.Log("AttackDice");
        yield return new WaitForSeconds(1.2f);
        int rand2 = Random.Range(1, 21);
        DiceNumber.text = rand2.ToString();
        AttackAbility(rand2);
        yield return new WaitForSeconds(1.7f);
        DiceNumber.text = "";
        transform.position = new Vector2(transform.position.x, 1000);
        //gameObject.SetActive(false);
    }
    void AttackAbility(int DiceNumber)
    {
        Player.Instance.Power = Player.Instance.PlayerPower;
        switch (DiceNumber)
        {
            case 1:
                Player.Instance.Power = 0;
                /*Player.Instance.Power = Mathf.Round(Player.Instance.Power * 30 / 100); *///확정 패배
                break;
            case 2:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 30f / 100);
                break;
            case 3:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 27.5f / 100);
                break;
            case 4:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 25 / 100);
                break;
            case 5:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 22.5f / 100);
                break;
            case 6:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 20 / 100);
                break;
            case 7:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 17.5f / 100);
                break;
            case 8:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 15 / 100);
                break;
            case 9:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 12.5f / 100);
                break;
            case 10:
                Player.Instance.Power -= Mathf.Round(Player.Instance.Power * 10 / 100);
                break;

            case 11:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 10 / 100);
                break;
            case 12:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 15 / 100);
                break;
            case 13:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 20 / 100);
                break;
            case 14:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 25 / 100);
                break;
            case 15:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 30 / 100);
                break;
            case 16:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 35 / 100);
                break;
            case 17:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 40 / 100);
                break;
            case 18:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 45 / 100);
                break;
            case 19:
                Player.Instance.Power += Mathf.Round(Player.Instance.Power * 50 / 100);
                break;
            case 20:
                Player.Instance.Power = EnemyAi.instance.MaxHP; //확정 승리
                break;
        }
        StartCoroutine(Player.Instance.GoAttackAni());
    }
}
