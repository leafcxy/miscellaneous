using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IBatisNet.DataMapper;
using Comit.XJPublicServicePlatform.Web.DataMapper;
using System.Collections;
using System.Data;
using IBatisNet.DataMapper.MappedStatements;
using IBatisNet.DataMapper.Scope;
using IBatisNet.Common.Exceptions;

namespace Comit.XJPublicServicePlatform.Web.Dao.IBatis.Common
{
    public class CommonDao
    {        
        public CommonDao()
        {
        }

        /// <summary>
        /// 执行存储过程按基础表创建带后缀名的新表
        /// </summary>
        /// <param name="sqlMap"></param>
        /// <param name="baseTable"></param>
        /// <param name="tableSuffix"></param>
        public static void CreateTable(ISqlMapper sqlMap, string baseTable, string tableSuffix)
        {
            //调用表创建的存储过程
            var parameters = new Hashtable();
            parameters.Add("param_BaseTable", baseTable);
            parameters.Add("param_TableSuffix", tableSuffix);
            sqlMap.QueryForObject("Proc_CreateTable", parameters);
        }

        
        /// <summary>
        /// 根据selectSql获取单条记录的对象，该语句完全自定义
        /// </summary>
        /// <param name="selectSql">自定义查询语句</param>
        /// <returns></returns>
        public object GetSingleRecord(string selectSql, ISqlMapper sqlMapper)
        {
            try
            {
                return sqlMapper.QueryForObject("Common.GetBySql", selectSql);
            }
            catch (Exception e)
            {
                throw new Exception(this + ".GetSingleRecord:" + e.Message);
            }
        }

        /// <summary>
        /// 根据selectSql获取所有记录（未分页），该语句完全自定义
        /// </summary>
        /// <param name="selectSql">条件语句</param>
        /// <returns>返回列表</returns>
        public IList GetAll(string selectSql, ISqlMapper sqlMapper)
        {
            try
            {
                return (IList)sqlMapper.QueryForList("Common.GetAllBySql", selectSql);
            }
            catch (Exception e)
            {
                throw new Exception(this + ".GetAll" + e.Message);
            }
        }


        // <summary>
        /// 根据addSql执行添加操作，该语句完全自定义
        /// </summary>
        /// <param name="addSql">自定义插入语句</param>
        public void Add(string addSql, ISqlMapper sqlMapper)
        {
            try
            {
                object obj = sqlMapper.Insert("Common.AddBySql", addSql);
            }
            catch (Exception e)
            {
                throw new Exception(this + ".Add:" + e.Message);
            }
        }

        /// <summary>
        /// 插入之前，执行更新操作
        /// </summary>
        /// <param name="updateSql">更新语句</param>
        /// <param name="addSql">添加语句</param>
        public void UpdateBeforeAdd(string updateSql, string addSql, ISqlMapper sqlMapper)
        {
            try
            {
                sqlMapper.BeginTransaction();
                Update(updateSql, sqlMapper);
                Add(addSql, sqlMapper);
                sqlMapper.CommitTransaction();
            }
            catch (Exception e)
            {
                sqlMapper.RollBackTransaction();

                throw new Exception(this + ".AddAfterDelete:" + e.Message);
            }
        }

        /// <summary>
        /// 查询所有记录前，根据selectConidtion，判断符合该条件的记录是否存在，
        /// 若不存在，则先执行update操作，最终返回由selectSql查出的记录集
        /// </summary>
        /// <param name="selectConidtion">判断记录是否存在的查询条件</param>
        /// <param name="updateSql">更新语句</param>
        /// <param name="selectSql">查询所有记录的语句</param>
        /// <returns></returns>
        public IList UpdateBeforeSelectAll(string selectConidtion, string updateSql, string selectSql, ISqlMapper sqlMapper)
        {
            if (GetSingleRecord(selectConidtion, sqlMapper) == null)
            {
                Update(updateSql, sqlMapper);
            }

            return GetAll(selectSql, sqlMapper);
        }

        /// <summary>
        /// 如果满足查询条件selectConidtion的记录不存在，则执行更新操作（包括插入）
        /// </summary>
        /// <param name="selectConidtion">查询条件语句</param>
        /// <param name="updateSql">更新语句</param>
        public void UpdateIfNotExists(string selectConidtion, string updateSql, ISqlMapper sqlMapper)
        {
            if (GetSingleRecord(selectConidtion, sqlMapper) == null)
            {
                Update(updateSql, sqlMapper);
            }
        }

        // <summary>
        /// 根据updateSql执行更新操作，该语句完全自定义
        /// </summary>
        /// <param name="deleteSql">自定义更新语句</param>
        /// <returns>如果为0则更新失败</returns>
        public int Update(string updateSql, ISqlMapper sqlMapper)
        {
            try
            {
                object obj = sqlMapper.Update("Common.UpdateBySql", updateSql);
                return int.Parse(obj.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(this + ".Update:" + e.Message);
            }
        }

        /// <summary>
        /// 新增或者更新
        /// </summary>
        /// <param name="selectSql">用于查询实例的Sql语句</param>
        /// <param name="addSql">实例不存在时要执行插入的Sql语句</param>
        /// <param name="updateSql">实例存在时要执行更新的Sql语句</param>
        /// <returns></returns>
        public int AddOrUpdate(string selectSql, string addSql, string updateSql, ISqlMapper sqlMapper)
        {
            if (GetSingleRecord(selectSql, sqlMapper) != null)
            {
                return Update(updateSql, sqlMapper);
            }
            else
            {
                Add(addSql, sqlMapper);
                return 0;
            }
        }

        /// <summary>
        /// 根据deleteSql执行删除操作，该语句完全自定义
        /// </summary>
        /// <param name="deleteSql">自定义删除语句</param>
        /// <returns></returns>
        public int Delete(string deleteSql, ISqlMapper sqlMapper)
        {
            try
            {
                object obj = sqlMapper.Delete("Common.DeleteBySql", deleteSql);
                return int.Parse(obj.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(this + ".Delete:" + e.Message);
            }
        }
        /// <summary>
        /// 根据SQL获取数据
        /// </summary>
        /// <param name="strSql"></param>
        /// <returns></returns>
        public DataSet GetDataSetBySql(string strSql, ISqlMapper sqlMapper)
        {
            try
            {
                return QueryForDataSet("Common.GetDataSetBySql", strSql, sqlMapper);
            }
            catch (Exception e)
            {
                throw new Exception(this + ".GetDataSetBySql:" + e.Message);
            }
        }

        // <summary>
        /// 根据updateSql执行更新操作，该语句完全自定义
        /// </summary>
        /// <param name="deleteSql">自定义更新语句</param>
        /// <returns>如果为0则更新失败</returns>
        public int UpdateEaSql(string updateSql, ISqlMapper sqlMap)
        {
            try
            {
                object obj = sqlMap.Update("Common.UpdateBySql", updateSql);
                return int.Parse(obj.ToString());
            }
            catch (Exception e)
            {
                throw new Exception(this + ".Update:" + e.Message);
            }
        }

        /// <summary>
        /// 返回一个dataset
        /// </summary>
        /// <param name="statementName">配置语句.</param>
        /// <param name="paramObject">参数.</param>
        /// <returns>DataSet.</returns>
        protected DataSet QueryForDataSet(string statementName, object paramObject, ISqlMapper sqlMapper)
        {
            try
            {
                DataSet ds = new DataSet();
                IMappedStatement statement = sqlMapper.GetMappedStatement(statementName);
                if (!sqlMapper.IsSessionStarted)
                {
                    sqlMapper.OpenConnection();
                }
                RequestScope scope = statement.Statement.Sql.GetRequestScope(statement, paramObject, sqlMapper.LocalSession);
                statement.PreparedCommand.Create(scope, sqlMapper.LocalSession, statement.Statement, paramObject);

                //mapper.LocalSession.CreateDataAdapter((scope.IDbCommand).Fill(ds));
                IDbCommand dc = sqlMapper.LocalSession.CreateCommand(scope.IDbCommand.CommandType);
                dc.CommandText = scope.IDbCommand.CommandText;
                foreach (IDbDataParameter para in scope.IDbCommand.Parameters)
                {
                    dc.Parameters.Add(para);
                }
                //dc.Parameters = scope.IDbCommand.Parameters;
                IDbDataAdapter dda = sqlMapper.LocalSession.CreateDataAdapter(dc);
                dda.Fill(ds);
                sqlMapper.CloseConnection();

                return ds;
            }
            catch (Exception e)
            {
                throw new IBatisNetException("执行错误 '" + statementName + "' .  出错原因: " + e.Message, e);
            }
        }
    }
}
