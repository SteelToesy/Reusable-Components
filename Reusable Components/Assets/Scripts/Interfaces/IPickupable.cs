using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPickupable 
{
    void OnTriggerStay2D(Collider2D collision);
}
