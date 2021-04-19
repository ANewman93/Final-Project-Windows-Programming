// Programmer: Andrew Newman
// Course: CP240 Lab08
// Description: Rest Api
// Limitations: Windows only


using System;
using restfulRepo;
using Model;
using Repositories;

using System.Collections.Generic;

namespace ServiceBus
{
    public class pubsService
    {
        private restfulRepo.IRepository<book> _bookRepository;
        private restfulRepo.IRepository<store> _storeRepository;
        private restfulRepo.IRepository<sales> _salesRepository;
        private restfulRepo.IRepository<booksOnOrder> _bookOrderRepository;
        public pubsService(restfulRepo.IRepository<book> bookRepoy, restfulRepo.IRepository<store> storeRepoy, restfulRepo.IRepository<sales> salesRepoy, restfulRepo.IRepository<booksOnOrder> bookOrderRepoy)
        {
            _bookRepository = bookRepoy;
            _storeRepository = storeRepoy;
            _salesRepository = salesRepoy;
            _bookOrderRepository = bookOrderRepoy;
        }


        public List<bookViewModel> getAllBooks()
        {
            List<bookViewModel> book = new List<bookViewModel>();

            List<book> puList = _bookRepository.FindAll();

            foreach (book b in puList)
            {
                book.Add(new bookViewModel(b.title_id, b.title, b.type, b.Pub.pub_id, b.Pub.pub_name, b.pubdate, b.price));

            }

            return book;
        }

        public book findBook(string id)
        {
            return _bookRepository.Find(id);
        }

        public List<storeViewModel> getAllStores()
        {
            List<storeViewModel> stores = new List<storeViewModel>();

            List<store> stList = _storeRepository.FindAll();

            foreach (store s in stList)
            {
                stores.Add(new storeViewModel(s.stor_id, s.stor_name));
            }

            return stores;
        }

        public store findStore(string stor_id)
        {
            return _storeRepository.Find(stor_id);
        }

        public List<salesViewModel> getAllSales()
        {
            List<salesViewModel> sales = new List<salesViewModel>();

            List<sales> saleList = _salesRepository.FindAll();

            foreach (sales s in saleList)
            {
                sales.Add(new salesViewModel(s.stor_id, s.ord_num, s.ord_date, s.qty, s.payterms, s.title_id));
            }

            return sales;
        }

        public bool addSaleOrder(sales addedSales)
        {
            if (_salesRepository.Add(addedSales))
            {
                return true;
            }

            return false;
        }

        public bool removeOrder(string ord_num)
        {
            if ((_salesRepository as SalesRepoREST).removeSalesOrder(ord_num))
            {
                return true;
            }

            return false;
        }
            
        


        public List<booksOnOrderViewModel> getAllBookOrders()
        {
            List<booksOnOrderViewModel> books = new List<booksOnOrderViewModel>();

            List<booksOnOrder> bookList = _bookOrderRepository.FindAll();

            foreach (booksOnOrder b in bookList)
            {
                books.Add(new booksOnOrderViewModel(b.stor_id, b.ord_num, b.title_id, b.title, b.qty, b.payterms));
            }

            return books;
        }
    }

    /*-------------*
     * View Models *
     *-------------*/
    public class bookViewModel
    {
        // the view model class is for creating a display friendly object
        // usually, class properites are converted to strings 

        public string TitleId { get; set; }
        public string pubId { get; set; }
        public string pubName { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }

        public bookViewModel(string titleId, string title, string type, string id, string Name, DateTime date, Decimal price)
        {
            TitleId = titleId;
            Title = title;
            Type = type;
            pubId = id;
            pubName = Name;
            Price = string.Format("{0:C2}", price).ToString();
            Date = date.ToShortDateString();
        }
    }

    public class storeViewModel
    {
        public string StoreID { get; set; }
        public string StoreName { get; set; }



        public storeViewModel(string stor_id, string stor_name)
        {
            StoreID = stor_id;
            StoreName = stor_name;
        }

        public override string ToString()
        {
            return StoreName;
        }
    }

    public class salesViewModel
    {
        public string StoreID { get; set; }
        public string OrderNum { get; set; }
        public string OrderDate { get; set; }
        public string Quantity { get; set; }
        public string Payterms { get; set; }
        public string TitleId { get; set; }

        public salesViewModel(string storeId, string orderNum, DateTime orderDate, Int16 quantity, string payterms, string titleId)
        {
            StoreID = storeId;
            OrderNum = orderNum;
            OrderDate = orderDate.ToShortDateString();
            Quantity = quantity.ToString();
            Payterms = payterms;
            TitleId = titleId;
        }
    }

    public class booksOnOrderViewModel
    {
        public string StoreId { get; set; }
        public string OrderNum { get; set; }
        public string TitleId { get; set; }
        public string Title { get; set; }
        public string Quantity { get; set; }
        public string Payterms { get; set; }

        public booksOnOrderViewModel(string stor_id, string ord_num, string title_id, string title, string qty, string payterms)
        {
            StoreId = stor_id;
            OrderNum = ord_num;
            TitleId = title_id;
            Title = title;
            Quantity = qty;
            Payterms = payterms;
        }
    }
}

