using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    CardGame_cardtouch,
    main_bgm,   // ���� ȭ��, ī�� �÷��� �⺻ BGM
    main_button_touch,  // ����, �÷��� ��ư, ����, �θ�� ���� Ȯ�� ��ư ��ġ �� ��µǴ� ȿ����
    collection_card_touch,  // ȹ���� ī�� ��ġ �� ��� ����
    collection_check_box,   // ���� ������ ������ ī�带 Ȯ���ϴ� üũ �ڽ� ��ġ �� ��µǴ� ȿ����
    store_bgm,  // �峭�� ������ ���� BGM
    store_door_touch,   // ���� �� ��ư ��ġ �� ��µǴ� ȿ����
    store_enter_guest,  // �մ� ���� �� ��µǴ� ȿ����
    multiplication_new_question,    // ���� ���� �� ���ο� ���� ���� �� ��µǴ� ȿ����
    multiplication_parts_selection, // ��ǰ ���� �� ��� ȿ����
    multiplication_correct, // ������ ���� ��� ��µǴ� ȿ����
    multiplication_incorrect,   // ������ ������ ���� ��� ��µǴ� ȿ����
    multiplication_doll_complete,   // ��� ������ Ǯ�� ���� �ϼ� �� ��� ȿ����
    multiplication_get_doll,    // ���̵��� ����� ���� ȹ�� �� ��µǴ� ȿ����
    division_bgm,   // �ΰ����� ���� ���� BGM
    division_enter, // �ΰ����� ���� ���� �� ��µǴ� ȿ����
    division_correct,   // ������ ������ �巡���� ��� ��µǴ� ȿ����
    division_incorrect  // ������ ������ �巡���� ��� ��µǴ� ȿ����
}

public class StoreQuestData : IEquatable<StoreQuestData>
{
    public string stg_cd;   // ������ �ڵ� (�н����� ���� �������� ������)
    public string stg_nm;   // �������� (������ �̸�)
    public string dtl_cn;   // ������ ���� ���� (�������� ���� ���� ����)

    public StoreQuestData(string stg_cd, string stg_nm, string dtl_cn)
    {
        this.stg_cd = stg_cd;
        this.stg_nm = stg_nm;
        this.dtl_cn = dtl_cn;
    }

    public bool Equals(StoreQuestData other)
    {
        // Check whether the compared object is null.
        if (ReferenceEquals(other, null))
        {
            return false;
        }

        // Check whether the compared object references the same data.
        if (ReferenceEquals(this, other))
        {
            return true;
        }

        // Check whether the StoreQuestData's properties are equal.
        return stg_cd.Equals(other.stg_cd);
    }

    // If Equals() returns true for a pair of objects
    // then GetHashCode() must return the same value for these objects.
    public override int GetHashCode()
    {
        // Get hash code for the stg_cd field if it is not null.
        int hashProductName = stg_cd == null ? 0 : stg_cd.GetHashCode();

        // Calculate the hash stg_cd for the StoreQuestData.
        return hashProductName;
    }
}

public class LocalDBService : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
