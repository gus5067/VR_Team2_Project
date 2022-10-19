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
        coolDown = wantCoolDown;    // ��Ÿ��
        mana = manaRequire;         // ����
        icon = wantIcon;            // ��ų������
        name = wantName;            // ��ų �̸�
        context = wantContext;      // ��ų ����
        foreach (var current in wantActions)
        {
            actions.Add(current);   // ������ �׼ǵ� ����Ʈ
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

    //public static SkillBase whirlwind = new SkillBase(0f, 2f, null, "�ҿ뵹��", "�ҿ뵹��ó�� ������ ���� ��ο� �ִ� ��� ������ ���ظ� �ݴϴ�.",
    //                                                    new Action_PlayAnimation("SkillWhirlwindMotion"),
    //                                                    new Action_DamageRangeContinous(1.2f, 2, "�ҿ뵹��"),  // OO�� ����������, OO�� ������
    //                                                    new Action_PlayAnimation("SkillWhirlwindFinish"));

    //public static SkillBase furiousCharge = new SkillBase(3f, 10f, null, "�ͷ��� ����", "���� ���� �����մϴ�. ���� ��ο� �ִ� ��� ���� ���ĳ��� ���ظ� �ݴϴ�.",
    //                                                    new Action_PlayAnimation("DashOnMotion"),
    //                                                    new Action_PlaySkillEffect("�ͷ��ѵ����뽬", true),
    //                                                    new Action_Dash(8f),            // 5�� ��ù���
    //                                                    new Action_PlaySkillEffect("�ͷ��ѵ�������"),
    //                                                    new Action_PlayAnimation("DashOffMotion"),
    //                                                    new Action_DamageRangeSingle(2f, 4)); // OO�� ����������, OO�� ������

    //public static SkillBase earthquake = new SkillBase(10f, 10f, null, "����", "�����ϰ� ���� ������ ���� ���� ��� ������ ���ظ� �ݴϴ�.",
    //                                                    new Action_PlayAnimation("JumpMotion"),
    //                                                    new Action_Jump(0f),             // 2�� ��������
    //                                                    new Action_PlaySkillEffect("����"),
    //                                                    new Action_PlayAnimation("IdleMotion"),
    //                                                    new Action_DamageRangeSingle(2.5f, 8)); // OO�� ����������, OO�� ������

    //public static SkillBase bossProjectile = new SkillBase(999f, 10f, null, "���� �Ҵ�����", "������ �ֺ����� �ҵ��̸� �վ�ϴ�",
    //                                                    //new Action_PlaySkillEffect("��������ü"),
    //                                                    new Action_PlayAnimation("BossSkillRoar"),
    //                                                    new Action_WaitForSeconds(1f),
    //                                                    new Action_ProjectileAround(5));

    //public static SkillBase bossWhip = new SkillBase(999f, 10f, null, "���� ä��", "������ �������� ä���� �ֵη�ϴ�",
    //                                                    new Action_PlayAnimation("IdleMotion"),
    //                                                    new Action_PlayAnimation("BossSkillWhip"),
    //                                                    new Action_DamageForwardSingle(5));
}