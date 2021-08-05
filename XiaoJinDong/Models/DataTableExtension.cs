using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace XiaoJinDong.Models
{
    public static class DataTableExtension
    {
        public static List<T> ToList<T>(this DataTable dt) where T : class, new()
        {
            List<PropertyInfo> prolist = new List<PropertyInfo>();
            Type t = typeof(T);
            Array.ForEach<PropertyInfo>(t.GetProperties(), p => { if (dt.Columns.IndexOf(p.Name) != -1) prolist.Add(p); });
            List<T> obList = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T ob = new T();
                prolist.ForEach(p => { if (row[p.Name] != DBNull.Value) p.SetValue(ob, row[p.Name], null); });
                obList.Add(ob);
            }
            return obList;
        }

        public static DataTable ToDataTable<T>(this IEnumerable<T> value) where T : class
        {
            List<PropertyInfo> proList = new List<PropertyInfo>();
            Type t = typeof(T);
            DataTable dt = new DataTable(t.Name);
            Array.ForEach<PropertyInfo>(
                t.GetProperties(),
                p => { proList.Add(p); dt.Columns.Add(p.Name, p.PropertyType); }
            );
            foreach (var item in value)
            {
                DataRow row = dt.NewRow();
                proList.ForEach(p => row[p.Name] = p.GetValue(item, null));
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}