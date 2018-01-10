using Sklep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sklep.Checkout
{
	public partial class CheckoutComplete : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if(!IsPostBack)
			{
				if((string)Session["userCheckoutCompleted"] != "true")
				{
					Session["userCheckoutCompleted"] = string.Empty;
					Response.Redirect("CheckoutError.aspx?" + "Desc=Unvalidated%20Checkout.");
				}

				NVAPICaller payPalCaller = new NVAPICaller();

				string retMsg = "";
				string token = "";
				string finalPaymentAmount = "";
				string PayerID = "";
				NVPCodec decoder = new NVPCodec();

				token = Session["token"].ToString();
				PayerID = Session["payerId"].ToString();
				finalPaymentAmount = Session["payment_amt"].ToString();

				bool ret = payPalCaller.DoCheckoutPayment(finalPaymentAmount, token, PayerID, ref decoder, ref retMsg);

				if(ret)
				{
					string PaymentConfirmation = decoder["PAYMENTINFO_0_TRANSACTIONID"].ToString();
					TransactionId.Text = PaymentConfirmation;

					ProductContext _db = new ProductContext();
					int currentOrderId = -1;
					if (Session["currentOrderId"] != string.Empty)
					{
						currentOrderId = Convert.ToInt32(Session["currentOrderID"]);
					}
					Order myCurrentOrder;
					if (currentOrderId >= 0)
					{
						myCurrentOrder = _db.Orders.Single(o => o.OrderId == currentOrderId);
						myCurrentOrder.PaymentTransactionId = PaymentConfirmation;
						_db.SaveChanges();
					}

					using (Sklep.Logic.ShoppingCartActions usersShoppingCart = new Sklep.Logic.ShoppingCartActions())
					{
						usersShoppingCart.EmptyCart();
					}

					Session["currentOrderId"] = string.Empty;
				}
				else
				{
					Response.Redirect("CheckoutError.aspx?" + retMsg);
				}
			}
		}

		protected void Continue_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}
	}
}