using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameManager
{
    ManagerStatus status { get; }
    // Start is called before the first frame update
    void Startup();
}
