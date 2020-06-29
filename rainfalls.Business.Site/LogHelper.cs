/*
         //区间报警 雨量图绘制
         if (this.Type.Equals("ssl"))
         {
             if (g_nRecords > 0)
             {
                 if (Time.DateTime2DbTime(DateTime.Now) - g_pList[g_nRecords - 1].tm > 3600)
                 {
                     //雨量图绘制
                     if (SiteObserver != null)
                     {
                         LogHelpers.LogHelpers.getInstance().Write("ssl只绘制雨量图", roninzyf.CLog.MsgType.Information);
                         SiteObserver.DrawRainMapOnly(SiteID);
                     }
                 }
                 else
                 {
                     //区间报警 雨量图绘制
                     if (SiteObserver != null)
                     {
                         LogHelpers.LogHelpers.getInstance().Write("ssl绘制雨量图,报警", roninzyf.CLog.MsgType.Information);
                         SiteObserver.Update(SiteID);
                     }
                 }
             }
         }
         else if (this.Type.Equals("comm"))
         {
             //区间报警 雨量图绘制
             if (SiteObserver != null)
             {
                 LogHelpers.LogHelpers.getInstance().Write("comm绘制雨量图,报警", roninzyf.CLog.MsgType.Information);
                 SiteObserver.Update(SiteID);
             }
         }

            
         LogHelpers.LogHelpers.getInstance().Write("雨量列表计算", roninzyf.CLog.MsgType.Information);
          * */