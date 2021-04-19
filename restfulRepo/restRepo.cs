// Programmer: Andrew Newman
// Course: CP240 Lab08
// Description: Rest Api
// Limitations: Windows only

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Http.Formatting;

using Model;

namespace restfulRepo
{
    public interface IRepository<T>
    {
        List<T> FindAll();
        T Find(string id);
        bool Add(T x);
        bool Update(T x);
        bool Remove(T x);
    }

    /*-----------------*
     * Book Repository *
     *-----------------*/
    public class BookRepoREST : IRepository<book>
    {
        string _root;

        public BookRepoREST(string root)
        {
            _root = root;
        }

        List<book> IRepository<book>.FindAll()
        {
            List<book> book = null;
            string path = @_root + "BookList";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    book = responseContent.ReadAsAsync<List<book>>().Result;

                    return book;
                }
            }

            return null;

        }

        public book Find(string id)
        {
            book book = null;
            string path = @_root + @"BookList/" + id;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    book = responseContent.ReadAsAsync<book>().Result;

                    return book;
                }
            }

            return null;
        }

       /*-------------------*
        * stubbed Functions *
        *-------------------*/
        public bool Add(book x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(book x)
        {
            throw new NotImplementedException();
        }

        public bool Update(book x)
        {
            throw new NotImplementedException();
        }
    }

    /*------------------*
     * Store Repository *
     *------------------*/

    public class StoreRepoREST : IRepository<store>
    {
        string _root;

        public StoreRepoREST(string root)
        {
            _root = root;
        }

        List<store> IRepository<store>.FindAll()
        {
            List<store> stores = null;
            string path = @_root + "StoreList";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    stores = responseContent.ReadAsAsync<List<store>>().Result;

                    return stores;
                }
            }

            return null;
        }

        store IRepository<store>.Find(string stor_id)
        {
            string path = @_root + @"StoreList/" + stor_id;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    store sto = responseContent.ReadAsAsync<store>().Result;

                    return sto;
                }
            }

            return null;
        }

        /*-------------------*
         * stubbed Functions *
         *-------------------*/

        public bool Add(store x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(store x)
        {
            throw new NotImplementedException();
        }

        public bool Update(store x)
        {
            throw new NotImplementedException();
        }
    }

    /*------------------*
     * Sales Repository *
     *------------------*/

    public class SalesRepoREST : IRepository<sales>
    {
        string _root;

        public SalesRepoREST(string root)
        {
            _root = root;
        }

        public List<sales> FindAll()
        {
            List<sales> sales = null;
            string path = @_root + "SalesList";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    sales = responseContent.ReadAsAsync<List<sales>>().Result;

                    return sales;
                }
            }

            return null;
        }
        
        bool IRepository<sales>.Add(sales sale)
        {
            StringContent message = http_helper.create_content(sale);
            string path = _root + "SalesList";

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.PostAsync(path, message).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        public bool removeSalesOrder(string ord_num)
        {
            string path = @_root + @"SalesList/" + ord_num;

            using (var client = new HttpClient())
            {
                HttpResponseMessage response = client.DeleteAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }

            return false;
        }

        /*-------------------*
        * stubbed Functions *
        *-------------------*/
        public sales Find(string sale)
        {
            throw new NotImplementedException();
        }

        public bool Remove(sales x)
        {
            throw new NotImplementedException();
        }

        public bool Update(sales x)
        {
            throw new NotImplementedException();
        }
    }

    /*----------------------*
    * Book Order Repository *
    *-----------------------*/

    public class BookOrderRepoREST : IRepository<booksOnOrder>
    {
        string _root;

        public BookOrderRepoREST(string root)
        {
            _root = root;
        }

        List<booksOnOrder> IRepository<booksOnOrder>.FindAll()
        {
            List<booksOnOrder> books = null;
            string path = @_root + "BookOrderList";

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    books = responseContent.ReadAsAsync<List<booksOnOrder>>().Result;

                    return books;
                }
            }

            return null;
        }

        public booksOnOrder Find(string ord_num)
        {
            string path = @_root + @"BookOrderList/" + ord_num;

            using (var client = new HttpClient())
            {
                var response = client.GetAsync(path).Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContent responseContent = response.Content;

                    booksOnOrder bo = responseContent.ReadAsAsync<booksOnOrder>().Result;

                    return bo;
                }
            }

            return null;
        }

        /*-------------------*
        * stubbed Functions *
        *-------------------*/

        public bool Add(booksOnOrder x)
        {
            throw new NotImplementedException();
        }

        public bool Remove(booksOnOrder x)
        {
            throw new NotImplementedException();
        }

        public bool Update(booksOnOrder x)
        {
            throw new NotImplementedException();
        }
    }

    class http_helper
    {
        public static StringContent create_content(object x)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(x);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

    }

}

