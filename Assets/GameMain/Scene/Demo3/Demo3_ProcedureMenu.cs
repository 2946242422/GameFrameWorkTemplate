using System.Collections;
using System.Collections.Generic;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner=GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo3_ProcedureMenu : ProcedureBase
{
   protected override void OnEnter(ProcedureOwner procedureOwner)
   {
      base.OnEnter(procedureOwner);
      // 加载框架UI组件

      UIComponent UI

         = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
      // 加载UI

      UI.OpenUIForm("Assets/GameMain/Scene/Demo3/UI_Menu.prefab", "DefaultGroup");
   }
}
