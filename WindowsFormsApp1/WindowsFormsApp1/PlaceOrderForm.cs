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
    public partial class PlaceOrderForm : Form
    {
        public Book_Overview _bookOverview;
        public BookList _bookList;
        public BookQuantityForm _bookQtyEdit;
        public sales _sales;
        public store _store;
        public string orderNum;
        DateTime date;

        public List<sales> transaction;
        public List<sales> editedTransaction;

        pubsService placeOrderService;

        public PlaceOrderForm( Book_Overview frm1, store store)
        {
            InitializeComponent();

            ActiveControl = payTermsDropDown;

            string apiRoot = configFile.getSetting("apiRoot");

            BookRepoREST bookRepo = new BookRepoREST(apiRoot);
            StoreRepoREST storeRepo = new StoreRepoREST(apiRoot);
            SalesRepoREST salesRepo = new SalesRepoREST(apiRoot);
            BookOrderRepoREST bookOrderRepo = new BookOrderRepoREST(apiRoot);

            placeOrderService = new pubsService(bookRepo, storeRepo, salesRepo, bookOrderRepo);

            //creates new order number
            orderNum = RandomString(8);

            _store = store;
            _bookOverview = frm1;
            _bookList = new BookList(this, _sales);
            _bookQtyEdit = new BookQuantityForm(this, _sales);

            transaction = new List<sales>();
        }

        private void PlaceOrderForm_Load(object sender, EventArgs e)
        {
            date = DateTime.Now.Date;
            order_bookstoreTextBox.Text = orderNum + " - " + _bookOverview._storeName.stor_name;
            booksOnOrderLabelPOF.Text = "Books on Order #: " + orderNum;
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Are you sure you want to cancel this order?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.No)
            {
                return;
            }
            else
            {
                Dispose();
            }
        }

        private void addBooksButton_Click(object sender, EventArgs e)
        {
            book book;

            if (payTermsDropDown.Text == "")
            {
                MessageBox.Show("Select Pay Term.", "Error", MessageBoxButtons.OK);
                return;
            }
            else
            {
                try
                {
                    _sales = new sales
                    {
                        stor_id = _bookOverview._storeName.stor_id,
                        ord_num = orderNum,
                        ord_date = date,
                        payterms = payTermsDropDown.Text,
                        qty = new short(),
                        title_id = ""
                    };

                    _bookList = new BookList(this, _sales)
                    {
                        Enabled = true
                    };

                    _bookList.ShowDialog();

                    if(_sales.qty == 0)
                    {
                        return;
                    }

                    //existing books in order wont show. This was kept for a backup

                    /*foreach(sales sale in transaction)
                    //{
                    //    if(sale.title_id == _sales.title_id)
                    //    {
                    //        MessageBox.Show("Book is already in order.", "Error", MessageBoxButtons.OK);
                    //        return;
                    //    }
                    //}
                    */

                    //try catch for when cancel in booklist form is pressed
                    try
                    {
                        book = placeOrderService.findBook(_sales.title_id);
                    }
                    catch
                    {
                        return;
                    }                    

                    ListViewItem lvi = new ListViewItem(_sales.title_id);
                    lvi.SubItems.Add(book.title);
                    lvi.SubItems.Add(_sales.qty.ToString());
                    bookOrderListViewPOF.Items.Add(lvi);
                    
                    if(bookOrderListViewPOF.Items.Count != 0)
                    {
                        removeBookButton.Enabled = true;
                        submitOrderButton.Enabled = true;
                        payTermsDropDown.Enabled = false; //if list count is not zero, payterms is disabled
                    }

                    transaction.Add(_sales);

                    bookOrderColumnHead();
                }
                catch
                {
                    MessageBox.Show("Could not add book to order.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }       
        }

        private void removeBookButton_Click(object sender, EventArgs e)
        {
            var DialogResult = MessageBox.Show("Are you sure you want remove this book?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (DialogResult == DialogResult.No)
            {
                return;
            }

            try
            {
                editBookQuantityButton.Enabled = false;

                if (bookOrderListViewPOF.SelectedItems.Count != 0)
                {
                    string selectedSaleId = bookOrderListViewPOF.SelectedItems[0].Text;

                    editedTransaction = new List<sales>();

                    foreach (sales sale in transaction)
                    {
                        editedTransaction.Add(sale);
                    }

                    foreach (sales sale in transaction)
                    {
                        if (selectedSaleId == sale.title_id)
                        {
                            editedTransaction.Remove(sale);
                        }
                    }

                    bookOrderListViewPOF.Items.RemoveAt(bookOrderListViewPOF.SelectedIndices[0]);

                    if (bookOrderListViewPOF.Items.Count == 0)
                    {
                        removeBookButton.Enabled = false;
                        submitOrderButton.Enabled = false;
                        editBookQuantityButton.Enabled = false;
                        payTermsDropDown.Enabled = true; //when listview count is zero, payters is enabled
                    }

                    transaction = editedTransaction;
                }
                else
                {
                    MessageBox.Show("Select book to remove from order.", "Error", MessageBoxButtons.OK);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Could not remove book from order.", "Error", MessageBoxButtons.OK);
                return;
            }
            
        }

        private void editBookQuantityButton_Click(object sender, EventArgs e)
        {
            book book;

            try
            {
                string selectedSaleId = bookOrderListViewPOF.SelectedItems[0].Text;

                foreach (sales sale in transaction)
                {
                    if (selectedSaleId == sale.title_id)
                    {
                        _bookQtyEdit = new BookQuantityForm(this, sale);
                        _bookQtyEdit.Enabled = true;
                        _bookQtyEdit.ShowDialog();

                    }
                }

                try
                {
                    book = placeOrderService.findBook(selectedSaleId);

                    //removes original list view item
                    bookOrderListViewPOF.Items.RemoveAt(bookOrderListViewPOF.SelectedIndices[0]);

                    //allows modification of tranaction
                    editedTransaction = transaction;

                    foreach (sales sale in editedTransaction)
                    {
                        if (selectedSaleId == sale.title_id)
                        {
                            ListViewItem lvi = new ListViewItem(sale.title_id);
                            lvi.SubItems.Add(book.title);
                            lvi.SubItems.Add(sale.qty.ToString());
                            bookOrderListViewPOF.Items.Add(lvi);
                        }
                    }                       
                                      

                    editBookQuantityButton.Enabled = false;

                    if(bookOrderListViewPOF.Items.Count == 0)
                    {
                        submitOrderButton.Enabled = false;
                        removeBookButton.Enabled = false;
                        payTermsDropDown.Enabled = true;
                        ActiveControl = submitOrderButton;
                    }
                }
                catch
                {
                    return;
                }

                bookOrderColumnHead();
            }
            catch
            {
                return;
            }

        }

        private void submitOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                store storeName = placeOrderService.findStore(_sales.stor_id);

                var DialogResult = MessageBox.Show("Do you want to submit order to " + storeName.stor_name + "?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (DialogResult == DialogResult.Yes)
                {
                    _bookOverview.OrderIDList.Clear();

                    foreach (sales sale in transaction)
                    {
                        placeOrderService.addSaleOrder(sale);
                    }

                    MessageBox.Show("Order #: " + orderNum + " was sent to " + storeName.stor_name + ".", "Success", MessageBoxButtons.OK);

                    Dispose();
                }
                else
                {
                    return;
                }

                return;

            }
            catch
            {
                return;
            }
        }

        private void bookOrderListViewPOF_Click(object sender, EventArgs e)
        {
            if (bookOrderListViewPOF.Items.Count != 0)
            {
                editBookQuantityButton.Enabled = true;
            }
        }        

        public void bookOrderColumnHead()
        {
            bookOrderListViewPOF.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            bookOrderListViewPOF.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
