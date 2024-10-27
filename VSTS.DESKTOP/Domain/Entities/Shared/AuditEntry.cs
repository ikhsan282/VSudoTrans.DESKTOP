﻿using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Domain.Entities.Shared
{
    public class AuditEntry
    {
        public string ActionType { get; set; }
        public string UserName { get; set; }
        public string TableName { get; set; }
        public string EntityName { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();
        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();
        public List<string> ChangedColumns { get; } = new List<string>();
        public AuditTrail ToAudit()
        {
            var audit = new AuditTrail();
            audit.Username = UserName;
            audit.ActionType = ActionType;
            audit.TableName = TableName;
            audit.TimeStamp = DateTime.Now;
            audit.EntityId = JsonConvert.SerializeObject(KeyValues);
            audit.OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues);
            audit.NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues);
            audit.AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns);
            return audit;
        }
    }
}
