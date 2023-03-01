using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.System.Users;

namespace Thegioididong.Data.Repositories
{
    public partial interface IUserRepository
    {
        UserClaim Login(LoginRequest request);
    }

    public class UserRepository : IUserRepository
    {
        private IDatabaseHelper _dbHelper;
        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public UserClaim Login(LoginRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_user_login",
                "@request", requestJson
                );
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }
                return dt.ConvertTo<UserClaim>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
