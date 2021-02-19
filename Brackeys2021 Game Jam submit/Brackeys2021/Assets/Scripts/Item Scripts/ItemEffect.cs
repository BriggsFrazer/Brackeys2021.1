using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ItemEffect {
    void AddEffect();

    void RemoveEffect();

    void PassiveOnAttackEffect();

    void PassiveOnDefendEffect();


    void PassiveTurnEffect();

}
