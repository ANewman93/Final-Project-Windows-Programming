// Programmer: Andrew Newman
// Course: CP240 Lab08
// Description: Rest Api
// Limitations: Windows only

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using Model;
using System.Configuration;
using Repositories;

namespace WebApi.Controllers
{
    class Repos
    {
        public static IRepository<book> get_book_repo()
        {
            string conn = configFile.getSetting("pubsDBConnectionString");

            IRepository<book> book_repo = new BookRepositoryDB(conn);

            return book_repo;
        }

        public static IRepository<store> get_store_repo()
        {
            string conn = configFile.getSetting("pubsDBConnectionString");

            IRepository<store> store_repo = new StoreRepositoryDB(conn);

            return store_repo;
        }

        public static IRepository<sales> get_sales_repo()
        {
            string conn = configFile.getSetting("pubsDBConnectionString");

            IRepository<sales> sales_repo = new SalesRepositoryDB(conn);

            return sales_repo;
        }

        public static IRepository<booksOnOrder> get_bookorder_repo()
        {
            string conn = configFile.getSetting("pubsDBConnectionString");

            IRepository<booksOnOrder> book_order_repo = new bookOrderRepositoryDB(conn);

            return book_order_repo;
        }
    }

    [RoutePrefix("Books")]
    public class PubsController : ApiController
    {
       
        [HttpGet, Route("BookList")]
        public IEnumerable<book> GetBooks()
        {
            IRepository<book> book_repo = Repos.get_book_repo();

            List<book> books = book_repo.FindAll();

            return books;
        }

        [HttpGet, Route("BookList/{title_id}")]
        public book GetBookById(string title_id)
        {
            IRepository<book> book_repo = Repos.get_book_repo();

            book book = book_repo.Find(title_id);

            return book;
        }


        [HttpGet, Route("StoreList")]
        public IEnumerable<store> GetStores()
        {
            IRepository<store> store_repo = Repos.get_store_repo();

            List<store> stores = store_repo.FindAll();

            return stores;
        }

        [HttpGet, Route("StoreList/{stor_id}")]
        public store GetStore(string stor_id)
        {
            IRepository<store> store_repo = Repos.get_store_repo();

            store store = store_repo.Find(stor_id);

            return store;
        }



        [HttpGet, Route("SalesList")]
        public IEnumerable<sales> GetSales()
        {
            IRepository<sales> sales_repo = Repos.get_sales_repo();

            List<sales> sales = sales_repo.FindAll();

            return sales;
        }

        [HttpPost, Route("SalesList")]
        public IHttpActionResult AddSales(sales addedSales)
        {
            IRepository<sales> sale_repo = Repos.get_sales_repo();

            if (sale_repo.Add(addedSales))
            {
                return StatusCode(HttpStatusCode.Created);
            }

            return StatusCode(HttpStatusCode.NotModified);
        }

        [HttpDelete, Route("SalesList/{ord_num}")]
        public IHttpActionResult DeleteSale(string ord_num)
        {
            IRepository<sales> sale_repo = Repos.get_sales_repo();

            if ((sale_repo as SalesRepositoryDB).removeSalesOrder(ord_num))
            {
                return StatusCode(HttpStatusCode.OK);
            }

            return StatusCode(HttpStatusCode.NotModified);
        }

        [HttpGet, Route("BookOrderList")]
        public IEnumerable<booksOnOrder> GetBookOrder()
        {
            IRepository<booksOnOrder> book_order_repo = Repos.get_bookorder_repo();

            List<booksOnOrder> books = book_order_repo.FindAll();

            return books;
        }

        [HttpGet, Route("BookOrderList/{ord_num}")]
        public IEnumerable<booksOnOrder> GetBooksByOrder(string ord_num)
        {
            IRepository<booksOnOrder> book_order_repo = Repos.get_bookorder_repo();

            IEnumerable<booksOnOrder> books = (book_order_repo as bookOrderRepositoryDB).getBooksByOrder(ord_num);

            return books;
        }
    }

    class configFile
    {
        public static string getSetting(string key)
        {
            return System.Web.Configuration.WebConfigurationManager.AppSettings[key];
        }
    }
}
