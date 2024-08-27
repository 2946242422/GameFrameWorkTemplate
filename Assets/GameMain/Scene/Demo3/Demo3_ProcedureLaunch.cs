using System.Collections;
using System.Collections.Generic;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner=GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo3_ProcedureLaunch : ProcedureBase
{
   protected override void OnEnter(ProcedureOwner procedureOwner)
   {
      base.OnEnter(procedureOwner);
      SceneComponent scene = UnityGameFramework.Runtime.GameEntry.GetComponent<SceneComponent>();
      scene.LoadScene("Assets/GameMain/Scene/Demo3/Demo3_Menu.unity", this);
      // 切换流程

      ChangeState<Demo3_ProcedureMenu>(procedureOwner);
   }
}
