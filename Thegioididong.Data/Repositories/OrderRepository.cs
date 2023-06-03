﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thegioididong.Data.Infrastructure;
using Thegioididong.Model.Models;
using Thegioididong.Model.ViewModels.Catalog.ProductCategories;
using Thegioididong.Model.ViewModels.Catalog.Products;
using Thegioididong.Model.ViewModels.CMS.Slides;
using Thegioididong.Model.ViewModels.Common;
using Thegioididong.Model.ViewModels.Sales.Orders;
using Thegioididong.Model.ViewModels.Sales.SaleInvoices;

namespace Thegioididong.Data.Repositories
{
    public partial interface IOrderRepository
    {
        // Manage


        // Public
        public OrderPublicCreateResult Create(OrderPublicCreateRequest request);

        PagedResult<Order> GetOrders(OrderCustomerPublicGetRequest request);

        OrderViewModel GetById(int id);

    }
    public partial class OrderRepository : IOrderRepository
    {
        private IDatabaseHelper _dbHelper;
        public OrderRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public OrderPublicCreateResult Create(OrderPublicCreateRequest request)
        {
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Order_CustomerCreate", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var products = dt.ConvertTo<OrderPublicCreateResult>().FirstOrDefault();
                return products;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PagedResult<Order> GetOrders(OrderCustomerPublicGetRequest request)
        {
            string[] valueJsonColumns = { "Items" };
            var requestJson = request != null ? MessageConvert.SerializeObject(request) : null;
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Order_GetPublicOrders", "@request", requestJson);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var users = dt.ConvertTo<PagedResult<Order>>(valueJsonColumns).FirstOrDefault();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public OrderViewModel GetById(int id)
        {
            string[] valueJsonColumns = { "OrderDetails" };
            try
            {
                string msgError = "";
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_Order_GetPublicDetail", "@id", id);
                if (!string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(msgError);
                }

                var users = dt.ConvertTo<OrderViewModel> (valueJsonColumns).FirstOrDefault();
                return users;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Manage


        #endregion
    }
}
