using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace LeaveWord.DataMapper
{
    public class MapperLeaveWord : IMapper
    {
        #region 字段

        private static volatile ISqlMapper _mapper = null;

        #endregion

        #region 成员

        /// <summary>
        /// 配置
        /// </summary>
        /// <param name="obj"></param>
        protected void Configure(object obj)
        {
            _mapper = null;
        }

        #endregion

        #region IDataMapper 成员

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sqlMapperPath"></param>
        public void InitMapper(string sqlMapperPath)
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();
            _mapper = builder.ConfigureAndWatch(sqlMapperPath, handler);
        }

        /// <summary>
        /// 实例化
        /// </summary>
        /// <returns></returns>
        public ISqlMapper Instance()
        {
            // 如果_mapper为空，则实例化
            if (_mapper == null)
            {
                lock (typeof(SqlMapper))
                {
                    if (_mapper == null) // double-check
                    {
                        InitMapper("Setting/ORM/SqlMap.config");
                    }
                }
            }
            return _mapper;
        }

        /// <summary>
        /// 获取Mapper
        /// </summary>
        /// <returns></returns>
        public ISqlMapper Get()
        {
            return Instance();
        }

        #endregion
    }
}
