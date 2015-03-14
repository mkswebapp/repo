using DemoWebAPI.DB;
using DemoWebAPI.Repository;
using DemoWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Query;

namespace WebAPI.Controllers
{
    public class ProductController : ODataController
    {
        IProductService _productservice;
        IUnitOfWork _unitOfWork;

          public ProductController(IProductService productService)
        {
          //  this.loggerService = loggerService;
            this._productservice = productService;
            

        }
        public PageResult<Product> Get(ODataQueryOptions<Product> queryOptions)
        {
            IQueryable results = queryOptions.ApplyTo(_productservice.GetAll().AsQueryable<Product>());
            return new PageResult<Product>(results as IEnumerable<Product>, Request.GetNextPageLink(), Request.GetInlineCount());
        }
    }
    public class ProductsController : ApiController
    {
       // ILogService loggerService;
        IProductService _productservice;
        IUnitOfWork _unitOfWork;


        public ProductsController(IProductService productService)
        {
          //  this.loggerService = loggerService;
            this._productservice = productService;
            

        }

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
       // [EnableCors]
        public IEnumerable<Product> GetProducts()
        {
           // loggerService.Logger().Info("Calling with null parameter as : id : " + id);
            var dat= _productservice.GetAll();// (id).AsQueryable<Product>();
            return dat;
        }

        /// <summary>
        /// To fetch Product by Category ID
        /// </summary>
        /// <returns></returns>
       // [EnableCors]
        public Product GetProductByID(int id)
        {
            //loggerService.Logger().Info("Calling with null parameter as : id : " + id);
            var product= _productservice.GetById(id);// (id).AsQueryable<Product>();
            return product;
        }

     

    }
}
