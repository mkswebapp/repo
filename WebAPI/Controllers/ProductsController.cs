using DemoWebAPI.DB;
using DemoWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class ProductsController : ApiController
    {
       // ILogService loggerService;
        IEntityService<Product> _productservice;


        ///
        //public ProductsController(ILogService loggerService, IProductService productService)
        //{
        //    this.loggerService = loggerService;
        //    this._productservice = productService;
        //}

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
       // [EnableCors]
        public IEnumerable<Product> GetProducts()
        {
           // loggerService.Logger().Info("Calling with null parameter as : id : " + id);
            return _productservice.GetAll();// (id).AsQueryable<Product>();
        }

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
       // [EnableCors]
        public Product GetProductByID(int id)
        {
            //loggerService.Logger().Info("Calling with null parameter as : id : " + id);
            return _productservice.GetById(id);// (id).AsQueryable<Product>();
        }


    }
}
