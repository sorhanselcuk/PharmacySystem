using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using DataAccess.Abstract;
using Business.Abstract;

namespace Business.Utilities
{
    public static class UserHelper
    {
        private static IHttpContextAccessor _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        private static IUserService _userService = ServiceTool.ServiceProvider.GetService<IUserService>();
      
        public static int GetUserId()
        {
            var userId = Convert.ToInt32(_httpContextAccessor.HttpContext.User.Identity.Name);
            return userId;
        }
        public static int GetSupplierId()
        {
            var user = _userService.GetUserById(GetUserId());
            return user.SupplierId;
        }
    }
}
