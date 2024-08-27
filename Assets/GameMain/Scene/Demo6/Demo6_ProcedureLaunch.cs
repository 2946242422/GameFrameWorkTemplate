using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;


public class Demo6_ProcedureLaunch : ProcedureBase
{
    protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
    {
        base.OnEnter(procedureOwner);
        // 获取框架实体组件
        EntityComponent entityComponent
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EntityComponent>();		// 创建实体
        entityComponent.ShowEntity<Demo6_HeroLogic>(1, "Assets/GameMain/Scene/Demo6/CubeEntity.prefab", "EntityGroup");
    }
}
