// ÇÁ¸®ÆÕ ÀÌ¸§
public enum AllyFish
{
    // RB: Red Bean(ÆÏ)
    // CC: Custard Cream(½´Å©¸²)
    AgariFish_CC, AgariFish_RB,
    BurntFish_CC, BurntFish_RB,
    GoldFish,
    MiniFish_CC, MiniFish_RB,
    TaiyakiFish_CC, TaiyakiFish_RB,
}

public enum EnemyFish
{
    AgariFish_CC, AgariFish_RB,
    BurntFish_CC, BurntFish_RB,
    GoldFish,
    MiniFish_CC, MiniFish_RB,
    TaiyakiFish_CC, TaiyakiFish_RB,
}

public enum Prefab
{
    AllyAgariFish_CC, AllyAgariFish_RB,
    AllyBurntFish_CC, AllyBurntFish_RB,
    AllyGoldFish,
    AllyMiniFish_CC, AllyMiniFish_RB,
    AllyTaiyakiFish_CC, AllyTaiyakiFish_RB,

    EnemyAgariFish_CC, EnemyAgariFish_RB,
    EnemyBurntFish_CC, EnemyBurntFish_RB,
    EnemyGoldFish,
    EnemyMiniFish_CC, EnemyMiniFish_RB,
    EnemyTaiyakiFish_CC, EnemyTaiyakiFish_RB,
}

// ºØ¾î»§ Å¸ÀÔ
public enum FishType
{
    RedBean, CustardCream, Both
}

public enum Bgm
{
    MainBGM, DefenseGame, ChickenGame, CardGame, GameClear, GameOver
}

public enum Sfx
{
   CardSelect, CardSuccess, CardFail, ButtonClick,
   BungkoSummon, BungkoAttack, BungkoDead,
   ChickenButton, ChickenFail, ChickenCombo
}