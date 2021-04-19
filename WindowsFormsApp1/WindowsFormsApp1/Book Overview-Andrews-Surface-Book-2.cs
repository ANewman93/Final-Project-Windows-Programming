using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using ServiceBus;
using restfulRepo;

namespace WindowsFormsApp1
{
    public partial class Book_Overview : Form
    {
        pubsService bookService;
        public store _store;
        public sales _sales;
        public store _storeName;
        public PlaceOrderForm _placeOrder;

        public Book_Overview()
        {
            InitializeComponent();

            string apiRoot = configFile.getSetting("apiRoot");

            BookRepoREST bookRepo = new BookRepoREST(apiRoot);
            StoreRepoREST storeRepo = new StoreRepoREST(apiRoot);
            SalesRepoREST salesRepo = new SalesRepoREST(apiRoot);
            BookOrderRepoREST bookOrderRepo = new BookOrderRepoREST(apiRoot);
            
            bookService = new pubsService(bookRepo, storeRepo, salesRepo, bookOrderRepo);
            _placeOrder = new PlaceOrderForm(this, _sales, _storeName);

            try
            {
                List<storeViewModel> stores = bookService.getAllStores();

                foreach (storeViewModel s in stores)
                {
                    StoresDropDown.Items.Add(s);
                }
            }
            catch
            {
                return;
            }
        }

        private void StoresDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                OrderIDList.Clear();
                BooksOnOrderList.Clear();
                BooksOnOrderLabel.Text = "Books On Order #: ";

                string selected = null; //sets up string to be used in try catch
                string prev = null;

                if (StoresDropDown.SelectedItem is storeViewModel st)
                {
                    selected = st.StoreID;
                }
                else
                {
                    return;
                }

                List<salesViewModel> sales = bookService.getAllSales();

                foreach (salesViewModel salesView in sales)
                {
                    if (salesView.OrderNum == prev)
                    {
                        //nothing Happens
                    }
                    else if (salesView.StoreID == selected)
                    {
                        OrderIDList.Items.Add(salesView.OrderNum);
                    }

                    prev = salesView.OrderNum;
                }

                OrderNumColumnHead();
                BooksOnOrderColumnHead();
            }
            catch
            {
                return;
            }
        }

        private void OrderIDList_Click(object sender, EventArgs e)
        {
            BooksOnOrderList.Clear();
            try
            {
                string selectedOrderNum = OrderIDList.SelectedItems[0].Text;
                List<bookViewModel> allBooks = bookService.getAllBooks();
                List<booksOnOrderViewModel> allBookOrders = bookService.getAllBookOrders();
                List<booksOnOrderViewModel> filteredBooks = new List<booksOnOrderViewModel>();
                ListViewItem lvi = null;

                foreach (booksOnOrderViewModel books in allBookOrders)
                {
                    if (selectedOrderNum == books.OrderNum)
                    {
                        filteredBooks.Add(books);
                    }
                }

                foreach (booksOnOrderViewModel orders in filteredBooks)
                {
                    foreach (bookViewModel bk in allBooks)
                    {
                        if (orders.TitleId == bk.TitleId)
                        {
                            lvi = new ListViewItem(orders.TitleId);
                            lvi.Tag = orders.OrderNum;
                            lvi.SubItems.Add(orders.Title);
                            lvi.SubItems.Add(orders.Quantity);
                            BooksOnOrderList.Items.Add(lvi);
                            PaymentTermsTextBox.Text = orders.Payterms;
                            BooksOnOrderLabel.Text = "Books On Order #: " + orders.OrderNum;
                        }
                    }
                }

                if (BooksOnOrderList.Items.Count == 0)
                {
                    return;
                }

                BooksOnOrderColumnHead();
            }
            catch
            {
                return;
            }

           
        }

        private void placeNewOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _storeName = null;

            try
            {
                if (StoresDropDown.Text == "")
                {
                    MessageBox.Show("Choose a Book Store from the drop down.", "Error", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    _storeName = new store();

                    if (StoresDropDown.SelectedItem is storeViewModel st)
                    {
                        _storeName.stor_id = st.StoreID;
                        _storeName.stor_name = st.StoreName;
                    }
                    _sales = new sales();

                    _placeOrder = new PlaceOrderForm(this, _sales, _storeName);
                    _placeOrder.Enabled = true;
                    _placeOrder.ShowDialog();
                }
            }
            catch
            {
                return;
            }
      
        }

        public void OrderNumColumnHead()
        {
            OrderIDList.Columns.Add(OrderID.Text);
            OrderIDList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            OrderIDList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            OrderIDList.Columns[0].Width = OrderIDList.Size.Width - 8;
        }

        public void BooksOnOrderColumnHead()
        {
            BooksOnOrderList.Columns.Add(TitleID.Text);
            BooksOnOrderList.Columns.Add(Title.Text);
            BooksOnOrderList.Columns.Add(Quantity.Text);
            BooksOnOrderList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            BooksOnOrderList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
    }
}
