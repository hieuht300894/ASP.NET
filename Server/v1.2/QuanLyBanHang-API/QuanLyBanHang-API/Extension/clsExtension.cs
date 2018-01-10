using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyBanHang_API.Extension
{
    public static class clsExtension
    {
        #region Linq
        public static T GetObjectByName<T>(this object oSource, string pName)
        {
            Type convertTo = typeof(T);
            if (oSource == null) return (T)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
            var properties = oSource.GetType().GetProperties();
            var oRe = oSource.GetType().GetProperty(pName).GetValue(oSource, null);
            return oRe != null ? (T)Convert.ChangeType(oRe, convertTo) : (T)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
        }
        //public static object ConvertType<T>(this object obj) where T : class
        //{
        //    PropertyInfo pInfo = GetPrimaryKey<T>();
        //    return
        //        obj != null ?
        //        Convert.ChangeType(obj, pInfo.PropertyType) :
        //        Convert.ChangeType(Activator.CreateInstance(pInfo.PropertyType), pInfo.PropertyType);
        //}

        public static TOut Sum<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Type convertTo = typeof(TOut);

            if (convertTo == typeof(Int16))
            {
                Func<TIn, Int16> columnMapper = new Func<TIn, Int16>((TIn item) => { return item.GetObjectByName<Int16>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Int32))
            {
                Func<TIn, Int32> columnMapper = new Func<TIn, Int32>((TIn item) => { return item.GetObjectByName<Int32>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Int64))
            {
                Func<TIn, Int64> columnMapper = new Func<TIn, Int64>((TIn item) => { return item.GetObjectByName<Int64>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Double))
            {
                Func<TIn, Double> columnMapper = new Func<TIn, Double>((TIn item) => { return item.GetObjectByName<Double>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }
            if (convertTo == typeof(Decimal))
            {
                Func<TIn, Decimal> columnMapper = new Func<TIn, Decimal>((TIn item) => { return item.GetObjectByName<Decimal>(Column); });
                return (TOut)Convert.ChangeType(List.DefaultIfEmpty().Sum(x => columnMapper(x)), convertTo);
            }

            return (TOut)Convert.ChangeType(Activator.CreateInstance(convertTo), convertTo);
        }
        public static IEnumerable<TIn> OrderBy<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectByName<TOut>(Column); });
            return List.OrderBy(x => columnMapper(x)).ToList();
        }
        public static IEnumerable<TIn> OrderByDescending<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectByName<TOut>(Column); });
            return List.OrderByDescending(x => columnMapper(x)).ToList();
        }
        public static TOut Min<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectByName<TOut>(Column); });
            return List.DefaultIfEmpty().Min(x => columnMapper(x));
        }
        public static TOut Max<TIn, TOut>(this IEnumerable<TIn> List, String Column)
        {
            Func<TIn, TOut> columnMapper = new Func<TIn, TOut>((TIn item) => { return item.GetObjectByName<TOut>(Column); });
            return List.DefaultIfEmpty().Max(x => columnMapper(x));
        }
        #endregion
    }
}