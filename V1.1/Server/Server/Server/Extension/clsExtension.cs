﻿using Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Server.Extension
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

        #region Database
        public static void BeginTransaction(this zModel db)
        {
            db.Database.BeginTransaction();
        }

        public static void CommitTransaction(this zModel db)
        {
            if (db.Database.CurrentTransaction != null)
                db.Database.CurrentTransaction.Commit();
        }

        public static void RollbackTransaction(this zModel db)
        {
            if (db.Database.CurrentTransaction != null)
                db.Database.CurrentTransaction.Rollback();
        }
        #endregion
    }

    public class CustomController : Controller   
    {
        protected JsonResult Ok(String message) { return new Ok(message); }
        protected JsonResult BadRequest(String message) { return new BadRequest(message); }
        protected JsonResult NoContent(String message) { return new NoContent(message); }

        protected JsonResult Ok() { return new Ok(); }
        protected JsonResult BadRequest() { return new BadRequest(); }
        protected JsonResult NoContent() { return new NoContent(); }

        protected JsonResult Ok(Object obj) { return new Ok(obj); }
        protected JsonResult BadRequest(Object obj) { return new BadRequest(obj); }
        protected JsonResult NoContent(Object obj) { return new NoContent(obj); }
    }

    public class Ok : JsonResult
    {
        public Ok()
        {
        }

        public Ok(string message)
        {
            Data = message;
        }

        public Ok(object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            MaxJsonLength = Int32.MaxValue;
            ContentType = "application/json";
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            context.RequestContext.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.OK;
            base.ExecuteResult(context);
        }
    }

    public class BadRequest : JsonResult
    {
        public BadRequest()
        {

        }

        public BadRequest(string message)
        {
            Data = message;
        }

        public BadRequest(object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            MaxJsonLength = Int32.MaxValue;
            ContentType = "application/json";
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            context.RequestContext.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.BadRequest;
            base.ExecuteResult(context);
        }
    }

    public class NoContent : JsonResult
    {
        public NoContent()
        {
        }

        public NoContent(string message)
        {
            Data = message;
        }

        public NoContent(object data)
        {
            Data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            MaxJsonLength = Int32.MaxValue;
            ContentType = "application/json";
            JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            context.RequestContext.HttpContext.Response.StatusCode = (Int32)HttpStatusCode.NoContent;
            base.ExecuteResult(context);
        }
    }
}