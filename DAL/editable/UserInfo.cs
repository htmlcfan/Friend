using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DAL
{
    /// <summary>
    /// 数据访问类 UserInfo
    /// <summary>
    public partial class UserInfo : DALHelper
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.UserInfo model)
        {
            IDbDataParameter[] parms4UserInfo = PrepareAddParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_ADD, parms4UserInfo);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Model.UserInfo model)
        {
            IDbDataParameter[] parms4UserInfo = PrepareUpdateParameters(model);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_UPDATE, parms4UserInfo);
        }

        /// <summary>
        /// 清空所有数据
        /// </summary>
        public int Truncate()
        {
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_TRUNCATE);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int? UID)
        {
            IDbDataParameter[] parms4UserInfo = PrepareDeleteParameters(UID);
            return dbHelper.ExecuteNonQuery(CommandType.Text, COMMAND_DELETE, parms4UserInfo);
        }

        /// <summary>
        /// 获取DataTable数据列表
        /// </summary>
        public DataTable GetDataTable(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataTable dt = dbHelper.ExecuteDataTable(CommandType.Text, strSql.ToString(), null);
            return dt;
        }

        /// <summary>
        /// 获取DataSet数据列表
        /// </summary>
        public DataSet GetDataSet(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataSet ds = dbHelper.ExecuteDataset(CommandType.Text, strSql.ToString(), null);
            return ds;
        }

        /// <summary>
        /// 获取DataView数据列表
        /// </summary>
        public DataView GetDataView(string strWhere = "", string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            DataView dv = dbHelper.ExecuteDataView(CommandType.Text, strSql.ToString(), null);
            return dv;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.UserInfo GetModel(int? UID)
        {
            IDbDataParameter[] parms4UserInfo = PrepareGetModelParameters(UID);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, COMMAND_GETMODEL, parms4UserInfo))
            {
                if (dr.Read()) return GetModel(dr);
                return null;
            }
        }


        public Model.UserInfo GetModel(string name)
        {
            string sql = "select * from UserInfo where UserName=@in_UserName";
            var parms = new IDbDataParameter[]{
                    dbHelper.CreateDbParameter(PARM_OPEID, DbType.AnsiString, ParameterDirection.Input)};
            parms[0].Value = name;
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, sql, parms))
            {
                if (dr.Read()) return GetModel(dr);
                return null;
            }
        }




        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int? UID)
        {
            IDbDataParameter[] parms4UserInfo = PrepareExistParameters(UID);
            object obj = dbHelper.ExecuteScalar(CommandType.Text, COMMAND_EXISTS, parms4UserInfo);
            return int.Parse(obj.ToString()) > 0;
        }

        /// <summary>
        /// 获取数量
        /// </summary>
        public int GetCount(string strWhere = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(*) FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = dbHelper.ExecuteScalar(CommandType.Text, strSql.ToString(), null);
            return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        public int GetMaxId()
        {
            object obj = dbHelper.ExecuteScalar(CommandType.Text, COMMAND_GETMAXID, null);
            return int.Parse(obj.ToString());
        }

        /// <summary>
        /// 获取泛型数据列表
        /// </summary>
        public List<Model.UserInfo> GetList(string strWhere = "",string strOrder = "")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                List<Model.UserInfo> lst = new List<Model.UserInfo>();
                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));
                return lst;
            }
        }

        /// <summary>
        /// 根据每页记录数及所要获取的页数
        /// </summary>
        public Model.PageData GetPageList(int pageSize, int curPage, string strWhere, string strOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM UserInfo");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (strOrder.Trim() != "")
            {
                strSql.Append(" " + strOrder);
            }
            List<Model.UserInfo> list = new List<Model.UserInfo>();
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                Model.PageData pageData = new Model.PageData();
                pageData.PageSize = pageSize;
                pageData.CurPage = curPage;
                pageData.RecordCount = 0;
                pageData.PageCount = 1;
                int first = (curPage - 1) * pageSize + 1;
                int last = curPage * pageSize;

                while (dr.Read())
                {
                    pageData.RecordCount++;
                    if (pageData.RecordCount >= first && last >= pageData.RecordCount)
                    {
                        Model.UserInfo md = new Model.UserInfo();
                        PrepareModel(md, dr);
                        list.Add(md);
                    }
                }
                dr.Close();
                if (pageData.RecordCount > 0)
                    pageData.PageCount = Convert.ToInt32(Math.Ceiling((double)pageData.RecordCount / (double)pageSize));
                pageData.PageList = list;
                return pageData;
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public List<Model.UserInfo> GetListByPage(string strWhere, string strOrder, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(strOrder.Trim()))
            {
                strSql.Append("order by T." + strOrder);
            }
            else
            {
                strSql.Append("order by T.UID desc");
            }
            strSql.Append(")AS Row, T.*  from UserInfo T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            using (IDataReader dr = dbHelper.ExecuteReader(CommandType.Text, strSql.ToString()))
            {
                List<Model.UserInfo> lst = new List<Model.UserInfo>();
                ExecuteReaderAction(dr, r => lst.Add(GetModel(r)));
                return lst;
            }
        }

        /// <summary>
        /// 由一行数据得到一个实体
        /// </summary>
        private Model.UserInfo GetModel(IDataReader dr)
        {
            Model.UserInfo model = new Model.UserInfo();
            PrepareModel(model, dr);
            return model;
        }

        public int UpdateState(string proId, string state)
        {
            proId = DAL.DALHelper.GetSafeParam(proId);
            state = DAL.DALHelper.GetSafeParam(state);
            string sql = "update userInfo set UserType=" + state + " where uid='" + proId + "'";
            return dbHelper.ExecuteNonQuery(CommandType.Text, sql);
        }
    }
}