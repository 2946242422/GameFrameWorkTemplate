using System;
using System.Collections;
using System.Collections.Generic;
using GameFramework.DataTable;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner=GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo4_ProcedureMenu : ProcedureBase
{
    protected override void OnEnter(ProcedureOwner procedureOwner)
    {
        base.OnEnter(procedureOwner);
        // 加载框架Event组件
        EventComponent Event
            = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
        // 加载框架UI组件
        UIComponent UI
            = UnityGameFramework.Runtime.GameEntry.GetComponent<UIComponent>();
        // 订阅UI加载成功事件
        Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        DataTableComponent  DataTable= UnityGameFramework.Runtime.GameEntry.GetComponent<DataTableComponent >();
        
        DataTableBase dataTableBase = DataTable.CreateDataTable(Type.GetType("DRMusic"));
        dataTableBase.ReadData("Assets/GameMain/Scene/Demo5/Music.txt",this);
        Event.Subscribe(LoadDataTableSuccessEventArgs.EventId,LoadDataTableSuccess);
        // 加载UI
        UI.OpenUIForm("Assets/GameMain/Scene/Demo4/UI_Menu.prefab", "DefaultGroup", this);
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


    private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
    {
        OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
        if (ne.UserData!=this)
        {
            return;
        }
        Log.Debug("UI_Menu：恭喜你，成功地召唤了我。");
    }
}
