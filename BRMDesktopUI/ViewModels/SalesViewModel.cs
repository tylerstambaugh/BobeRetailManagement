using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TRMDesktopUI.Library.Api;
using TRMDesktopUI.Library.Models;

namespace BRMDesktopUI.ViewModels
{
    public class SalesViewModel : Screen
    {

        IProductEndpoint _productEndpoint;
        private BindingList<ProductModel> _products;
        private ProductModel _selectedProduct;
        private BindingList<CartItemModel> _cart = new BindingList<CartItemModel>();
        private int _itemQuantity = 1;

        public SalesViewModel(IProductEndpoint productEndpoint)
        {
            _productEndpoint = productEndpoint;
        }

        protected override async void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);
            await LoadProducts();
        }

        private async Task LoadProducts()
        {
            var productList = await _productEndpoint.GetAll();
            Products = new BindingList<ProductModel>(productList);
        }



        public BindingList<ProductModel> Products
        {
            get { return _products; }
            set
            {
                _products = value;
                NotifyOfPropertyChange(() => Products);
            }
        }



        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                NotifyOfPropertyChange(() => SelectedProduct);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        public int ItemQuantity
        {
            get { return _itemQuantity; }
            set
            {
                _itemQuantity = value;
                NotifyOfPropertyChange(() => ItemQuantity);
                NotifyOfPropertyChange(() => CanAddToCart);
            }
        }


        public BindingList<CartItemModel> Cart
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
                decimal subtotal = 0;

                foreach (var item in _cart)
                {
                    subtotal += (item.Product.RetailPrice * item.QuantityInCart);
                }
                return subtotal.ToString("C");
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
                if (ItemQuantity > 0 &&
                    SelectedProduct?.QuantityInStock >= ItemQuantity)
                    output = true;
                return output;
            }
        }

        public void AddToCart()
        {
            if (CanAddToCart)
            {
                CartItemModel existingItem = Cart
                    .FirstOrDefault(x => x.Product == SelectedProduct);

                if (existingItem != null)
                {
                    existingItem.QuantityInCart += ItemQuantity;                    
                    
                    // hack in order to get the quantity property
                     //updated correctly in the cart
                    Cart.Remove(existingItem);
                    Cart.Add(existingItem);
                }
                else
                {
                    CartItemModel item = new CartItemModel
                    {
                        Product = SelectedProduct,
                        QuantityInCart = ItemQuantity
                    };
                    Cart.Add(item);
                }

                SelectedProduct.QuantityInStock -= ItemQuantity;
                ItemQuantity = 1;
                NotifyOfPropertyChange(() => SubTotal);
            }
        }

        public bool CanRemoveFromCart
        {
            get
            {
                bool output = false;

                //if (_cart.Count > 0)
                //    output = true;

                return output;
            }
        }


        public void RemoveFromCart()
        {


            NotifyOfPropertyChange(() => SubTotal);
        }


        public bool CanCheckOut
        {
            get
            {
                bool output = false;

                //if (_cart.Count > 0)
                //    output = true;

                return output;
            }
        }


        public void CheckOut()
        {

        }
    }
}
