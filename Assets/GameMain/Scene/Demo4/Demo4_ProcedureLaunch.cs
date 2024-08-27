using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo4_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        scene.LoadScene("Assets/GameMain/Scene/Demo4/Demo4_Menu.unity", this);
        // 切换流程

        ChangeState<Demo4_ProcedureMenu>(procedureOwner);
    }
}
