﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Movation.Frameworks.Mewh;
using Movation.Core;
using Movation.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace CheckUserAccountExpiry
{
    [MewhServiceContract]
    public class UserAccountExpiry : MewhService
    {
        #region Properties
            [MewhPropertyContract]
            public string ConnectionString { get; set; }
        #endregion
        #region SERVICE METHODS
            [MewhMethodContract]
            public void ValidateUserAccount()
            {
              //Try to run sql procedure to check the user accounts, the procedure changes the state of the user accordingly
              try
              {
                TSql.ExecuteNonQuery("spCheckUserAccountExpiry", this.ConnectionString);
              }
              catch(Exception ex)
              {
                EventLogger.LogEvent(EventLogType.Error, ex);
              }
            }
        #endregion
    }
}
