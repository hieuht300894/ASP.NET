using EntityModel.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Model
{
    public class aModel : zModel
    {
        public override int SaveChanges()
        {
            List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
            .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
            .ToList());
            var lstObjs = AutoLog(entries);
            int res = base.SaveChanges();
            //SaveLog(lstObjs);
            return res;
        }
        private List<ObjectBinding> AutoLog(List<DbEntityEntry> lstEntries)
        {
            List<ObjectBinding> lstObjs = new List<ObjectBinding>();
            foreach (var entry in lstEntries)
            {
                ObjectBinding obj = new ObjectBinding();

                if (entry.State == EntityState.Added)
                {
                    obj.State = entry.State;
                    obj.Entity = entry;
                    obj.CurrentValues = entry.CurrentValues;
                    lstObjs.Add(obj);
                }
                else if (entry.State == EntityState.Modified)
                {
                    obj.State = entry.State;
                    obj.Entity = entry;
                    obj.OriginalValues = entry.OriginalValues;
                    obj.CurrentValues = entry.CurrentValues;
                    lstObjs.Add(obj);
                }
                else if (entry.State == EntityState.Deleted)
                {
                    obj.State = entry.State;
                    obj.Entity = entry;
                    obj.OriginalValues = entry.OriginalValues;
                    lstObjs.Add(obj);
                }
            }
            return lstObjs;
        }

        public override async Task<int> SaveChangesAsync()
        {
            List<DbEntityEntry> entries = new List<DbEntityEntry>(ChangeTracker.Entries()
              .Where(e => (e.Entity.GetType().Name.StartsWith("e") || e.Entity.GetType().Name.StartsWith("x")) && (e.State == EntityState.Added || e.State == EntityState.Deleted || e.State == EntityState.Modified))
              .ToList());
            List<ObjectBinding> lstObjs = await AutoLogAsync(entries);
            var res = await base.SaveChangesAsync();
            //SaveLog(lstObjs);
            return res;
        }
        private async Task<List<ObjectBinding>> AutoLogAsync(List<DbEntityEntry> lstEntries)
        {
            return await Task.Factory.StartNew(() =>
            {
                List<ObjectBinding> lstObjs = new List<ObjectBinding>();

                foreach (var entry in lstEntries)
                {
                    ObjectBinding obj = new ObjectBinding();

                    if (entry.State == EntityState.Added)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.CurrentValues = entry.CurrentValues;
                        lstObjs.Add(obj);
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.OriginalValues = entry.OriginalValues;
                        obj.CurrentValues = entry.CurrentValues;
                        lstObjs.Add(obj);
                    }
                    else if (entry.State == EntityState.Deleted)
                    {
                        obj.State = entry.State;
                        obj.Entity = entry;
                        obj.OriginalValues = entry.OriginalValues;
                        lstObjs.Add(obj);
                    }
                }
                return lstObjs;
            });
        }

        private async void SaveLog(List<ObjectBinding> lstObjs)
        {
            try
            {
                using (zModel db = new zModel())
                {
                    DateTime CurrentDate = DateTime.Now;

                    foreach (var obj in lstObjs)
                    {
                        xLichSu log = new xLichSu();
                        log.KeyID = 0;
                        log.NguoiTao = 0;
                        log.NgayTao = CurrentDate;
                        log.Bang = obj.Entity.Entity.GetType().Name;
                        log.ThaoTac = obj.State.ToString();
                        log.TrangThai = (Int32)obj.State;

                        if (obj.OriginalValues != null)
                        {
                            Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                            foreach (string prop in obj.OriginalValues.PropertyNames) { ParamsValues.Add(prop, obj.OriginalValues[prop]); }
                            log.GiaTriCu = ParamsValues.SerializeJSON();
                        }
                        else
                        {
                            Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                            log.GiaTriCu = ParamsValues.SerializeJSON();
                        }
                        if (obj.CurrentValues != null)
                        {
                            Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                            foreach (string prop in obj.CurrentValues.PropertyNames) { ParamsValues.Add(prop, obj.CurrentValues[prop]); }
                            log.GiaTriMoi = ParamsValues.SerializeJSON();
                        }
                        else
                        {
                            Dictionary<string, object> ParamsValues = new Dictionary<string, object>();
                            log.GiaTriMoi = ParamsValues.SerializeJSON();
                        }
                        db.xLichSu.Add(log);
                    }
                    await db.SaveChangesAsync();
                }
            }
            catch 
            {
            }
        }
    }

    public class ObjectBinding
    {
        public EntityState State { get; set; }
        public DbEntityEntry Entity { get; set; }
        public DbPropertyValues CurrentValues { get; set; }
        public DbPropertyValues OriginalValues { get; set; }
    }

    public static class Json
    {
        public static T Clone<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<T>(serialized);
        }
        public static List<T> Clone<T>(this List<T> source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return JsonConvert.DeserializeObject<List<T>>(serialized);
        }
        public static string SerializeJSON<T>(this T source)
        {
            var serialized = JsonConvert.SerializeObject(
                source,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            return serialized;
        }
        public static T DeserializeJSON<T>(this string source) where T : new()
        {
            try { return JsonConvert.DeserializeObject<T>(source); }
            catch { return new T(); }
        }
    }
}
