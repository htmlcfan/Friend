using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类 Admin ，此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    public partial class Admin
    {
        internal const string COMMAND_ADD = "INSERT INTO Admin(UserName, Password) VALUES (@in_UserName, @in_Password)";
        internal const string COMMAND_UPDATE = "UPDATE Admin SET UserName=@in_UserName, Password=@in_Password WHERE ID=@in_ID";
        internal const string COMMAND_DELETE = "DELETE FROM Admin WHERE ID=@in_ID";
        internal const string COMMAND_TRUNCATE = "TRUNCATE TABLE Admin";
        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM Admin WHERE ID=@in_ID";
        internal const string COMMAND_GETMODEL = "SELECT * FROM Admin WHERE ID=@in_ID";
        internal const string COMMAND_GETLIST = "SELECT * FROM Admin";
        internal const string COMMAND_GETMAXID = "SELECT MAX(ID) FROM Admin";

        internal const string PARM_ID = "@in_ID";
        internal const string PARM_USERNAME = "@in_UserName";
        internal const string PARM_PASSWORD = "@in_Password";

        /// <summary>
        /// 为新增一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareAddParameters(Model.Admin model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_ADD);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_USERNAME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSWORD, DbType.AnsiString, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_ADD, parms);
            }

            parms[0].Value = model.UserName;
            parms[1].Value = model.Password;

            return parms;
        }

        /// <summary>
        /// 为更新一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareUpdateParameters(Model.Admin model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_USERNAME, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSWORD, DbType.AnsiString, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE, parms);
            }

            parms[0].Value = model.UserName;
            parms[1].Value = model.Password;
            parms[2].Value = model.ID;

            return parms;
        }

        /// <summary>
        /// 为删除一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareDeleteParameters(int? ID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_DELETE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_DELETE, parms);
            }

            parms[0].Value = ID;

            return parms;
        }

        /// <summary>
        /// 为查询是否存在一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareExistParameters(int? ID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS, parms);
            }

            parms[0].Value = ID;

            return parms;
        }

        /// <summary>
        /// 为获取一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareGetModelParameters(int? ID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_ID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL, parms);
            }

            parms[0].Value = ID;

            return parms;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal static void PrepareModel(Model.Admin model, IDataReader dr)
        {
            model.ID = DbValue.GetInt(dr["ID"]);
            model.UserName = DbValue.GetString(dr["UserName"]);
            model.Password = DbValue.GetString(dr["Password"]);
        }
    }
}
