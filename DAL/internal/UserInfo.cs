using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// 数据访问类 UserInfo ，此类请勿动，以方便表字段更改时重新生成覆盖
    /// </summary>
    public partial class UserInfo
    {
        internal const string COMMAND_ADD = "INSERT INTO UserInfo(NAME, SEX, DATA, PLACE, NATION, HEIGHT, IMG, HISTORY, EDUCATION, SCHOOL, ADDRESS, WORKT, WORKPLACE, PHONE, INTEREST, OHEIGHT, OWORK, OINTEREST, OSTRENGTH, MIN, MAX, OWORKPLACE, FAMILY, Password, UserType, OpeID) VALUES (@in_NAME, @in_SEX, @in_DATA, @in_PLACE, @in_NATION, @in_HEIGHT, @in_IMG, @in_HISTORY, @in_EDUCATION, @in_SCHOOL, @in_ADDRESS, @in_WORKT, @in_WORKPLACE, @in_PHONE, @in_INTEREST, @in_OHEIGHT, @in_OWORK, @in_OINTEREST, @in_OSTRENGTH, @in_MIN, @in_MAX, @in_OWORKPLACE, @in_FAMILY, @in_Password, @in_UserType, @in_OpeID)";
        internal const string COMMAND_UPDATE = "UPDATE UserInfo SET NAME=@in_NAME, SEX=@in_SEX, DATA=@in_DATA, PLACE=@in_PLACE, NATION=@in_NATION, HEIGHT=@in_HEIGHT, IMG=@in_IMG, HISTORY=@in_HISTORY, EDUCATION=@in_EDUCATION, SCHOOL=@in_SCHOOL, ADDRESS=@in_ADDRESS, WORKT=@in_WORKT, WORKPLACE=@in_WORKPLACE, PHONE=@in_PHONE, INTEREST=@in_INTEREST, OHEIGHT=@in_OHEIGHT, OWORK=@in_OWORK, OINTEREST=@in_OINTEREST, OSTRENGTH=@in_OSTRENGTH, MIN=@in_MIN, MAX=@in_MAX, OWORKPLACE=@in_OWORKPLACE, FAMILY=@in_FAMILY, Password=@in_Password, UserType=@in_UserType, OpeID=@in_OpeID WHERE UID=@in_UID";
        internal const string COMMAND_DELETE = "DELETE FROM UserInfo WHERE UID=@in_UID";
        internal const string COMMAND_TRUNCATE = "TRUNCATE TABLE UserInfo";
        internal const string COMMAND_EXISTS = "SELECT COUNT(1) FROM UserInfo WHERE UID=@in_UID";
        internal const string COMMAND_GETMODEL = "SELECT * FROM UserInfo WHERE UID=@in_UID";
        internal const string COMMAND_GETLIST = "SELECT * FROM UserInfo";
        internal const string COMMAND_GETMAXID = "SELECT MAX(UID) FROM UserInfo";

        internal const string PARM_UID = "@in_UID";
        internal const string PARM_NAME = "@in_NAME";
        internal const string PARM_SEX = "@in_SEX";
        internal const string PARM_DATA = "@in_DATA";
        internal const string PARM_PLACE = "@in_PLACE";
        internal const string PARM_NATION = "@in_NATION";
        internal const string PARM_HEIGHT = "@in_HEIGHT";
        internal const string PARM_IMG = "@in_IMG";
        internal const string PARM_HISTORY = "@in_HISTORY";
        internal const string PARM_EDUCATION = "@in_EDUCATION";
        internal const string PARM_SCHOOL = "@in_SCHOOL";
        internal const string PARM_ADDRESS = "@in_ADDRESS";
        internal const string PARM_WORKT = "@in_WORKT";
        internal const string PARM_WORKPLACE = "@in_WORKPLACE";
        internal const string PARM_PHONE = "@in_PHONE";
        internal const string PARM_INTEREST = "@in_INTEREST";
        internal const string PARM_OHEIGHT = "@in_OHEIGHT";
        internal const string PARM_OWORK = "@in_OWORK";
        internal const string PARM_OINTEREST = "@in_OINTEREST";
        internal const string PARM_OSTRENGTH = "@in_OSTRENGTH";
        internal const string PARM_MIN = "@in_MIN";
        internal const string PARM_MAX = "@in_MAX";
        internal const string PARM_OWORKPLACE = "@in_OWORKPLACE";
        internal const string PARM_FAMILY = "@in_FAMILY";
        internal const string PARM_PASSWORD = "@in_Password";
        internal const string PARM_USERTYPE = "@in_UserType";
        internal const string PARM_OPEID = "@in_OpeID";

        /// <summary>
        /// 为新增一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareAddParameters(Model.UserInfo model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_ADD);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SEX, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_DATA, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_NATION, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_HEIGHT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_IMG, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_HISTORY, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_EDUCATION, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SCHOOL, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ADDRESS, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_WORKT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_WORKPLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PHONE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_INTEREST, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OHEIGHT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OWORK, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OINTEREST, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OSTRENGTH, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_MIN, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_MAX, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OWORKPLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_FAMILY, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSWORD, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_USERTYPE, DbType.Int32, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OPEID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_ADD, parms);
            }

            parms[0].Value = model.NAME;
            parms[1].Value = model.SEX;
            parms[2].Value = model.DATA;
            parms[3].Value = model.PLACE;
            parms[4].Value = model.NATION;
            parms[5].Value = model.HEIGHT;
            parms[6].Value = model.IMG;
            parms[7].Value = model.HISTORY;
            parms[8].Value = model.EDUCATION;
            parms[9].Value = model.SCHOOL;
            parms[10].Value = model.ADDRESS;
            parms[11].Value = model.WORKT;
            parms[12].Value = model.WORKPLACE;
            parms[13].Value = model.PHONE;
            parms[14].Value = model.INTEREST;
            parms[15].Value = model.OHEIGHT;
            parms[16].Value = model.OWORK;
            parms[17].Value = model.OINTEREST;
            parms[18].Value = model.OSTRENGTH;
            parms[19].Value = model.MIN;
            parms[20].Value = model.MAX;
            parms[21].Value = model.OWORKPLACE;
            parms[22].Value = model.FAMILY;
            parms[23].Value = model.Password;
            parms[24].Value = model.UserType;
            parms[25].Value = model.OpeID;

            return parms;
        }

        /// <summary>
        /// 为更新一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareUpdateParameters(Model.UserInfo model)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_NAME, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SEX, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_DATA, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_NATION, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_HEIGHT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_IMG, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_HISTORY, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_EDUCATION, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_SCHOOL, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_ADDRESS, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_WORKT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_WORKPLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PHONE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_INTEREST, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OHEIGHT, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OWORK, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OINTEREST, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OSTRENGTH, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_MIN, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_MAX, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OWORKPLACE, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_FAMILY, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_PASSWORD, DbType.String, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_USERTYPE, DbType.Int32, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_OPEID, DbType.Int32, ParameterDirection.Input),
                    dbHelper.CreateDbParameter(PARM_UID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_UPDATE, parms);
            }

            parms[0].Value = model.NAME;
            parms[1].Value = model.SEX;
            parms[2].Value = model.DATA;
            parms[3].Value = model.PLACE;
            parms[4].Value = model.NATION;
            parms[5].Value = model.HEIGHT;
            parms[6].Value = model.IMG;
            parms[7].Value = model.HISTORY;
            parms[8].Value = model.EDUCATION;
            parms[9].Value = model.SCHOOL;
            parms[10].Value = model.ADDRESS;
            parms[11].Value = model.WORKT;
            parms[12].Value = model.WORKPLACE;
            parms[13].Value = model.PHONE;
            parms[14].Value = model.INTEREST;
            parms[15].Value = model.OHEIGHT;
            parms[16].Value = model.OWORK;
            parms[17].Value = model.OINTEREST;
            parms[18].Value = model.OSTRENGTH;
            parms[19].Value = model.MIN;
            parms[20].Value = model.MAX;
            parms[21].Value = model.OWORKPLACE;
            parms[22].Value = model.FAMILY;
            parms[23].Value = model.Password;
            parms[24].Value = model.UserType;
            parms[25].Value = model.OpeID;
            parms[26].Value = model.UID;

            return parms;
        }

        /// <summary>
        /// 为删除一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareDeleteParameters(int? UID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_DELETE);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_UID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_DELETE, parms);
            }

            parms[0].Value = UID;

            return parms;
        }

        /// <summary>
        /// 为查询是否存在一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareExistParameters(int? UID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_UID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_EXISTS, parms);
            }

            parms[0].Value = UID;

            return parms;
        }

        /// <summary>
        /// 为获取一条数据准备参数
        /// </summary>
        internal static IDbDataParameter[] PrepareGetModelParameters(int? UID)
        {
            IDbDataParameter[] parms = DbParameterCache.GetCachedParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL);
            if (parms == null)
            {
                parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_UID, DbType.Int32, ParameterDirection.Input)};
                DbParameterCache.CacheParameterSet(dbHelper.ConnectionString, COMMAND_GETMODEL, parms);
            }

            parms[0].Value = UID;

            return parms;
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        internal static void PrepareModel(Model.UserInfo model, IDataReader dr)
        {
            model.UID = DbValue.GetInt(dr["UID"]);
            model.NAME = DbValue.GetString(dr["NAME"]);
            model.SEX = DbValue.GetString(dr["SEX"]);
            model.DATA = DbValue.GetString(dr["DATA"]);
            model.PLACE = DbValue.GetString(dr["PLACE"]);
            model.NATION = DbValue.GetString(dr["NATION"]);
            model.HEIGHT = DbValue.GetString(dr["HEIGHT"]);
            model.IMG = DbValue.GetString(dr["IMG"]);
            model.HISTORY = DbValue.GetString(dr["HISTORY"]);
            model.EDUCATION = DbValue.GetString(dr["EDUCATION"]);
            model.SCHOOL = DbValue.GetString(dr["SCHOOL"]);
            model.ADDRESS = DbValue.GetString(dr["ADDRESS"]);
            model.WORKT = DbValue.GetString(dr["WORKT"]);
            model.WORKPLACE = DbValue.GetString(dr["WORKPLACE"]);
            model.PHONE = DbValue.GetString(dr["PHONE"]);
            model.INTEREST = DbValue.GetString(dr["INTEREST"]);
            model.OHEIGHT = DbValue.GetString(dr["OHEIGHT"]);
            model.OWORK = DbValue.GetString(dr["OWORK"]);
            model.OINTEREST = DbValue.GetString(dr["OINTEREST"]);
            model.OSTRENGTH = DbValue.GetString(dr["OSTRENGTH"]);
            model.MIN = DbValue.GetString(dr["MIN"]);
            model.MAX = DbValue.GetString(dr["MAX"]);
            model.OWORKPLACE = DbValue.GetString(dr["OWORKPLACE"]);
            model.FAMILY = DbValue.GetString(dr["FAMILY"]);
            model.Password = DbValue.GetString(dr["Password"]);
            model.UserType = DbValue.GetInt(dr["UserType"]);
            model.OpeID = DbValue.GetInt(dr["OpeID"]);
        }
    }
}
