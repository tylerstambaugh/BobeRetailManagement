﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {
        private BindingList<string> _products;
        private string _itemQuantity;
        private BindingList<string> _cart;

        public BindingList<string> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }

        public string ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }

        public BindingList<string> Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                NotifyOfPropertyChange(() => Cart);

            }
        }

        public string SubTotal
        {
            get
            {
                //replace with calculation
                return "0.00";
            }
        }

        public string Tax
        {
            get
            {
                return "0.00";
            }
        }

        public string Total
        {
            get
            {
                return "0.00";
            }
        }

        public bool CanAddToCart
        {
            get
            {
                bool output = false;

                //Make sure something is selected
                //Make sure there is an item quantity

                return output;
            }
        }

        public void AddToCart()
        {

        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //make sure something is selected
                return output;
            }
        }


        public void RemoveFromCart()
        {

        }


        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //make sure something is in the cart
                return output;
            }
        }


        public void CheckOut()
        {

        }
    }
}
