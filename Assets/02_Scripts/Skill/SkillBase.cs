using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
// VR
public class SkillBase
{

    public float coolDown;
    public float mana;
    public Sprite icon;
    public string name;
    public string context;
    List<CharacterAction> actions = new List<CharacterAction>();

    public SkillBase(float wantCoolDown, float manaRequire, Sprite wantIcon, string wantName, string wantContext, params CharacterAction[] wantActions)
    {
        coolDown = wantCoolDown;    // 쿨타임
        mana = manaRequire;         // 마나
        icon = wantIcon;            // 스킬아이콘
        name = wantName;            // 스킬 이름
        context = wantContext;      // 스킬 설명
        foreach (var current in wantActions)
        {
            actions.Add(current);   // 실행할 액션들 리스트
        }
    }


    public List<CharacterAction> GetActionClone()
    {
        List<CharacterAction> result = new List<CharacterAction>();
        foreach (var current in actions)
        {
            result.Add(current.Copy());
        }
        return result;
    }

    //public static SkillBase whirlwind = new SkillBase(0f, 2f, null, "소용돌이", "소용돌이처럼 세차게 돌며 경로에 있는 모든 적에게 피해를 줍니다.",
    //                                                    new Action_PlayAnimation("SkillWhirlwindMotion"),
    //                                                    new Action_DamageRangeContinous(1.2f, 2, "소용돌이"),  // OO의 데미지범위, OO의 데미지
    //                                                    new Action_PlayAnimation("SkillWhirlwindFinish"));

    //public static SkillBase furiousCharge = new SkillBase(3f, 10f, null, "맹렬한 돌진", "적을 향해 돌진합니다. 돌진 경로에 있는 모든 적을 밀쳐내며 피해를 줍니다.",
    //                                                    new Action_PlayAnimation("DashOnMotion"),
    //                                                    new Action_PlaySkillEffect("맹렬한돌진대쉬", true),
    //                                                    new Action_Dash(8f),            // 5의 대시범위
    //                                                    new Action_PlaySkillEffect("맹렬한돌진공격"),
    //                                                    new Action_PlayAnimation("DashOffMotion"),
    //                                                    new Action_DamageRangeSingle(2f, 4)); // OO의 데미지범위, OO의 데미지

    //public static SkillBase earthquake = new SkillBase(10f, 10f, null, "지진", "난폭하게 땅을 뒤흔들어 범위 내의 모든 적에게 피해를 줍니다.",
    //                                                    new Action_PlayAnimation("JumpMotion"),
    //                                                    new Action_Jump(0f),             // 2의 점프범위
    //                                                    new Action_PlaySkillEffect("지진"),
    //                                                    new Action_PlayAnimation("IdleMotion"),
    //                                                    new Action_DamageRangeSingle(2.5f, 8)); // OO의 데미지범위, OO의 데미지

    //public static SkillBase bossProjectile = new SkillBase(999f, 10f, null, "보스 불던지기", "보스가 주변으로 불덩이를 뿜어냄니다",
    //                                                    //new Action_PlaySkillEffect("보스투사체"),
    //                                                    new Action_PlayAnimation("BossSkillRoar"),
    //                                                    new Action_WaitForSeconds(1f),
    //                                                    new Action_ProjectileAround(5));

    //public static SkillBase bossWhip = new SkillBase(999f, 10f, null, "보스 채찍", "보스가 전방으로 채찍을 휘두룹니다",
    //                                                    new Action_PlayAnimation("IdleMotion"),
    //                                                    new Action_PlayAnimation("BossSkillWhip"),
    //                                                    new Action_DamageForwardSingle(5));
}