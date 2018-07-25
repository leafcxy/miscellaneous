using IBatisNet.DataMapper;

namespace LeaveWord.DataMapper
{
    public interface IMapper
    {
        #region 成员

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="sqlMapperPath"></param>
        void InitMapper(string sqlMapperPath);

        /// <summary>
        /// 实例化
        /// </summary>
        /// <returns></returns>
        ISqlMapper Instance();

        /// <summary>
        /// 获取映射
        /// </summary>
        /// <returns></returns>
        ISqlMapper Get();

        #endregion
    }
}
