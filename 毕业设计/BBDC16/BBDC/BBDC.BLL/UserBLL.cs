using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBDC.DAL;
using BBDC.Model;

namespace BBDC.BLL
{
    public class UserBLL
    {
        public UserDAL dal = new UserDAL();

        #region  BasicMethod

        public int Add(UserInfo model)
        {
            //首先判断用户名是否已存在
            UserInfo entity = dal.GetModel(model.userid);
            if (entity != null)
            {
                return -1;    //用户名已存在
            }
            else
            {
                return dal.Add(model);
            }
        }

        //更新一条数据
        public int Update(UserInfo model)
        {
            return dal.Update(model);
        }
        //更新一条wordid
        public bool Updatewordid(UserInfo model)
        {
            return dal.Updatewordid(model);
        }
        //更新一条number
        public bool Updatenumber(UserInfo model)
        {
            return dal.Updatenumber(model);
        }

        //删除一条数据
        //public int Delete(string userName)
        //{
        //    return dal.Delete(userName);
        //}

        //得到一个对象实体
        public UserInfo GetModel(string userId)
        {
            return dal.GetModel(userId);
        }

        //获得数据列表
        //public List<Admin> GetList()
        //{
        //    return dal.GetList();
        //}
        //public List<Admin> GetListByUserName(string UserName)
        //{
        //    return dal.GetListByUserName(UserName);
        //}
        #endregion  BasicMethod

        #region  ExtensionMethod
        //用户登录检查
        public bool Login(string userId, string pwd)
        {
            UserInfo model = dal.GetModel(userId);
            if (model != null)
            {
                if (pwd == model.pwd)
                {
                    return true;
                }
            }
            return false;
        }
        //public int ForgotPwd(UserInfo model)
        //{
        //    //首先判断用户名是否已存在
        //    UserInfo entity = dal.GetModel(model.userid);
        //    if (entity == null)
        //    {
        //        return -1;    //用户名不存在
        //    }
        //    else
        //    {
        //        return entity;
        //    }
        //}

        #endregion  ExtensionMethod
    }
}
