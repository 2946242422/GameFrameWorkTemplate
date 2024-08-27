using System.Collections;
using System.Collections.Generic;
using GameFramework.Event;
using GameFramework.Procedure;
using UnityEngine;
using UnityGameFramework.Runtime;
using ProcedureOwner=GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;

public class Demo7_ProcedureLoadConfigs : ProcedureBase
{
  protected override void OnEnter(ProcedureOwner procedureOwner)
  {
    base.OnEnter(procedureOwner);
    EventComponent Event
      = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
    Event.Subscribe(LoadConfigSuccessEventArgs.EventId,LoadConfigSuccess);
    LoadConfig();
  }

  private void LoadConfigSuccess(object sender, GameEventArgs e)
  {
    int GameID=  GameEntry.GetComponent<ConfigComponent>().GetInt("Scene.Main");
    Log.Debug($"GameID:{GameID}");
  }

  void LoadConfig()
  {
    string config = "Assets/GameMain/Configs/DefaultConfig.txt";
     GameEntry.GetComponent<ConfigComponent>().ReadData(config,this);
   
  }

  protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
  {
    base.OnLeave(procedureOwner, isShutdown);
    EventComponent Event
      = UnityGameFramework.Runtime.GameEntry.GetComponent<EventComponent>();
    Event.Unsubscribe(LoadConfigSuccessEventArgs.EventId,LoadConfigSuccess);
  }
}
