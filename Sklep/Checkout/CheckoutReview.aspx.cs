﻿using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep.Checkout
{
	public partial class CheckoutReview : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				NVAPICaller payPalcaller = new NVAPICaller();

				string retMsg = "";
				string token = "";
				string PayerID = "";
				NVPCodec decoder = new NVPCodec();
				token = Session["token"].ToString();

				bool ret = payPalcaller.GetCheckoutDetails(token, ref PayerID, ref decoder, ref retMsg);

				if(ret)
				{
					Session["payerId"] = PayerID;

					var myOrder = new Order();
					myOrder.OrderDate = Convert.ToDateTime(decoder["TIMESTAMP"].ToString());
					myOrder.UserName = User.Identity.Name;
					myOrder.FirstName = decoder["FIRSTNAME"].ToString();
					myOrder.LastName = decoder["LASTNAME"].ToString();
					myOrder.Address = decoder["SHIPTOSTREET"].ToString();
					myOrder.City = decoder["SHIPTOCITY"].ToString();
					myOrder.State = decoder["SHIPTOSTATE"].ToString();
					myOrder.PostalCode = decoder["SHIPTOZIP"].ToString();
					myOrder.Country = decoder["SHIPTOCOUNTRYCODE"].ToString();
					myOrder.Email = decoder["EMAIL"].ToString();
					myOrder.Total = Convert.ToDecimal(decoder["AMT"].ToString());

					try
					{
						decimal paymentAmountOnCheckout =
							Convert.ToDecimal(Session["payment_amt"].ToString());
						decimal paymentAmountFromPayPal =
							Convert.ToDecimal(decoder["AMT"].ToString());
						if (paymentAmountOnCheckout != paymentAmountFromPayPal)
						{
							Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
						}
					}
					catch (Exception)
					{
						Response.Redirect("CheckoutError.aspx?" + "Desc=Amount%20total%20mismatch.");
					}

					ProductContext _db = new ProductContext();

					_db.Orders.Add(myOrder);
					_db.SaveChanges();

					using (Sklep.Logic.ShoppingCartActions usersShoppingCart = new Sklep.Logic.ShoppingCartActions())
					{
						List<CartItem> myOrderList = usersShoppingCart.GetCartItems();

						for(int i = 0; i < myOrderList.Count; i++)
						{
							var myOrderDetail = new OrderDetail();
							myOrderDetail.OrderId = myOrder.OrderId;
							myOrderDetail.UserName = User.Identity.Name;
							myOrderDetail.ProductId = myOrderList[i].ProductId;
							myOrderDetail.Quantity = myOrderList[i].Quantity;
							myOrderDetail.UnitPrice = myOrderList[i].Product.UnitPrice;

							_db.OrderDetails.Add(myOrderDetail);
							_db.SaveChanges();
						}

						Session["currentOrderId"] = myOrder.OrderId;

						List<Order> orderList = new List<Order>();
						orderList.Add(myOrder);
						ShipInfo.DataSource = orderList;
						ShipInfo.DataBind();

						OrderItemList.DataSource = myOrderList;
						OrderItemList.DataBind();
					}
				}
				else
				{
					Response.Redirect("CheckoutError.aspx?" + retMsg);
				}
			}
		}

		protected void CheckoutConfrim_Click(object sender, EventArgs e)
		{
			Session["userCheckoutCompleted"] = "true";
			Response.Redirect("~/Checkout/CheckoutComplete.aspx");
		}
	}
}