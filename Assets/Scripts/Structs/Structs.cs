using UnityEngine;
using UnityEngine.AI;

public enum MonsterType { greenMonster, bigGreenMonster }
public struct AiMonsters
{
    public MonsterType monsterType;
    public GameObject monsterObject;
    public NavMeshAgent monsterAgent;
    public Animator monsterAnimation;
    public BoxCollider monsterColl;
    public float monsterHP;
    public bool monsterIsDead;
}

public struct AiBoss
{
    public GameObject bossObject;
    public Transform bossTransform;
    public NavMeshAgent bossAgent;
    public Animator bossAnimator;
    public BoxCollider bossColl;
    public float bossHP;
    public bool bossIsDead;
}

public enum AmmoType {bossAmmo, ammoAutomat, ammoPistolet, ammoRacketnica }
public struct WeaponsAmmoStruct
{
    public GameObject bullet;
    public BoxCollider bulletColl;
    public AmmoType ammoType;
    public bool isFull;

    public WeaponsAmmoStruct(GameObject bull, BoxCollider bullColl, AmmoType type, bool full)
    {
        full = false;
        isFull = full;
        bullet = bull;
        bulletColl = bullColl;
        ammoType = type;
    }
}

public struct AmmoShopsStruct
{
    public Transform ammoShop;
    public BoxCollider ammoShopColl;
    public AmmoType ammoShopType;
}

public struct AmmoBossStruct
{
    public Transform bulletBoss;
    public Rigidbody bulletBossRigidbody;
    public BoxCollider bulletBossCollider;
}

