using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using procedureOwner=GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo2_ProcedureLuanch : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        Log.Debug("初始！！");
        SceneComponent sceneComponent = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
        sceneComponent.LoadScene("Assets/GameMain/Scene/Demo2/Demo2_Menu.unity",this);
        ChangeState<Demo2_ProcedureMenu>(procedureOwner);
    }
}
