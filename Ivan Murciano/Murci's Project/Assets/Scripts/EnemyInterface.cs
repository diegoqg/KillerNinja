using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Enemy
{
    void Pegar();
    void RecibirDaño();
}

public interface Boss
{
    void GeneraMapaBoss();
}
