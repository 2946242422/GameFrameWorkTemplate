using System.Collections;
using System.Collections.Generic;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo8_ProcedureDataNote : ProcedureBase
{
   protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
   {
      base.OnEnter(procedureOwner);
      DataNodeComponent dataNodeComponent = GameEntry.GetComponent<DataNodeComponent>();
      dataNodeComponent.SetData("Player.Id",(VarInt32)1001);
      dataNodeComponent.SetData("Player.Name",(VarString)"Xiaoling");
      dataNodeComponent.SetData("Player.Sex",(VarBoolean)true);
      dataNodeComponent.SetData("Player.Age",(VarInt32)20);
      // 获取节点上数据
      string name = dataNodeComponent.GetData<VarString>("Player.Name");
      Log.Debug($"name:{name}");
      // 根据父节点获取孩子数据
      var parent = dataNodeComponent.GetNode("Player");
      var age = parent.GetChild("Age").GetData();
      Debug.Log("根据父节点获取孩子数据：" + age);
      // 判断节点是否存在
      var node = dataNodeComponent.GetNode("Player.Age");
      if (node != null)
      {
         Debug.Log("节点：存在");
      }
      else
      {
         Debug.Log("节点：不存在");
      }
      // 移除节点
      dataNodeComponent.RemoveNode("Player.Age");

      var del_node = dataNodeComponent.GetNode("Player.Age");
      if (del_node != null)
      {
         Debug.Log("节点：存在");
      }
      else
      {
         Debug.Log("节点：不存在");
      }
   }
}
