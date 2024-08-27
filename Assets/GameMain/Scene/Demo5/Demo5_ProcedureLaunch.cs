using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;

public class Demo5_ProcedureLaunch : ProcedureBase
{
   protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
   {
      base.OnEnter(procedureOwner);
      // 加载框架Event组件
      EventComponent Event
         = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
      DataTableComponent  DataTable= UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent >();
        
      DataTableBase dataTableBase = DataTable.CreateDataTable(Type.GetType("DRMusic"));
      dataTableBase.ReadData("Assets/GameMain/Scene/Demo5/Music.txt",this);
      Event.Subscribe(LoadDataTableSuccessEventArgs.EventId,LoadDataTableSuccess);
   }
   private void LoadDataTableSuccess(object sender, GameEventArgs e)
   {
      LoadDataTableSuccessEventArgs ne = (LoadDataTableSuccessEventArgs)e;
      if (ne.UserData==this)
      {
         DataTableComponent  DataTable= UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent >();
         IDataTable<DRMusic> drMusics= DataTable.GetDataTable<DRMusic>();
         DRMusic[] drHeros = drMusics.GetAllDataRows();
         Log.Debug("drHeros:" + drHeros.Length);
         Log.Debug(drHeros[0].AssetName);
         foreach (var VARIABLE in drMusics)
         {
            UnityEngine.Debug.Log($"id{VARIABLE.m_Id}|name{VARIABLE.AssetName}");
         }
         
      }
   }
}
