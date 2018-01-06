using System;
using System.Linq;
using Sklep.Models;
using System.Web.ModelBinding;

namespace Sklep
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int?categoryID)
        {
            var _db = new Sklep.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryID.HasValue && categoryID > 0)
            {
                query = query.Where(p => p.CategoryID == categoryID);
            }
            return query;
        }
    }
}