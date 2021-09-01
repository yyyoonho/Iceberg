using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControllWorldQuestVar : MonoBehaviour
{
    public Enemy enemy;
    public int enemyStartingHealth;
    public int snowDamage;

    public PackControll antipack;
    public float Time;

    public PackGenerator packGenerator;
    public float instantTime;

    public Player player;
    public int antipackDamage;
    public int healpackDamage;

    public PlayerInput playerInput;
    public float timeBetweenShot;

    void Start()
    {
        packGenerator = enemy.GetComponent<Transform>().GetComponentInChildren<PackGenerator>();

        enemy.startingHealth = this.enemyStartingHealth; //적의 시작HP
        enemy.snowDamage = this.snowDamage; // 스노우 데미지
        antipack.time = this.Time; //안티팩 지속시간
        packGenerator.instantTime = this.instantTime; //안티팩 인스턴트 빈도
        player.antipackDamage = this.antipackDamage; //안티팩 공격력
        player.healpackDamage = this.healpackDamage; //힐팩 회복력
        playerInput.timeBetweenShot = this.timeBetweenShot; //공격속도
    }
}
