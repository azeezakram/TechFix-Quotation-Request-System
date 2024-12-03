using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UserService.Logics;
using UserService.Models;

namespace UserService
{
    /// <summary>
    /// Summary description for TechFixWebServices
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class TechFixWebServices : System.Web.Services.WebService
    {
        [WebMethod]
        public bool isStaffUsernameNotExists(string username)
        {
            return new TechFixStaffManagement().isStaffUsernameNotExists(username);
        }

        [WebMethod]
        public string[] GetStaffUsernameAndPassword(string username)
        {
            return new TechFixStaffManagement().GetStaffUsernameAndPassword(username);
        }

        [WebMethod]
        public int AddNewStaff(TechFixStaff newStaff)
        {
            return new TechFixStaffManagement().AddNewStaff(newStaff);
        }

        [WebMethod]
        public List<TechFixStaff> GetAllStaffs()
        {
            return new TechFixStaffManagement().GetAllStaffs();
        }

        [WebMethod]
        public int UpdateStaff(TechFixStaff updatedStaff)
        {
            return new TechFixStaffManagement().UpdateStaff(updatedStaff);
        }

        [WebMethod]
        public int DeleteStaff(int staffId)
        {
            return new TechFixStaffManagement().DeleteStaff(staffId);
        }

        [WebMethod]
        public int AddNewProduct(Product newProduct)
        {
            return new ProductManagement().AddNewProduct(newProduct);
        }

        [WebMethod]
        public List<Product> GetAllProducts()
        {
            return new ProductManagement().GetAllProducts();
        }

        [WebMethod]
        public int UpdateProduct(Product product)
        {
            return new ProductManagement().UpdateProduct(product);
        }

        [WebMethod]
        public int DeleteProduct(Product product)
        {
            return new ProductManagement().DeleteProduct(product);
        }

        [WebMethod]
        public int ClearTheInventory(int supplierId)
        {
            return new ProductManagement().ClearTheInventory(supplierId);
        }

        [WebMethod]
        public int AddNewSupplier(Supplier newSupplier)
        {
            return new SupplierManagement().AddNewSupplier(newSupplier);
        }

        [WebMethod]
        public bool isUsernameNotExists(string username) { 
            return new SupplierManagement().isUsernameNotExists(username);
        }

        [WebMethod]
        public string[] GetSupplierUsernameAndPassword(string username)
        {
            return new SupplierManagement().GetSupplierUsernameAndPassword(username);
        }


        [WebMethod]
        public List<Supplier> GetSuppliers()
        {
            return new SupplierManagement().GetSuppliers();
        }

        [WebMethod]
        public int GetSupplierId(int productId)
        {
            return new SupplierManagement().GetSupplierId(productId);
        }

        [WebMethod]
        public int UpdateSupplier(Supplier updatedSupplier)
        {
            return new SupplierManagement().UpdateSupplier(updatedSupplier);
        }

        [WebMethod]
        public int DeleteSupplier(int supplierId)
        {
            return new SupplierManagement().DeleteSupplier(supplierId);
        }

        [WebMethod]
        public int CreateNewQuotationRequest(Quotation newQuotation, List<QuotationDetail> itemList)
        {
            if (newQuotation == null || itemList == null || itemList.Count == 0)
            {
                throw new ArgumentException("Invalid quotation or item list.");
            }

            return new QuotationManagement().CreateNewQuotationRequest(newQuotation, itemList);
        }

        [WebMethod]
        public int UpdateRequestDiscount(int quotationDetailId, decimal requestDiscount)
        {
            return new QuotationManagement().UpdateRequestDiscount(quotationDetailId, requestDiscount);
        }

        [WebMethod]
        public int SetQuotationApproved(int quotationId)
        {
            return new QuotationManagement().SetQuotationApproved(quotationId);
        }

        [WebMethod]
        public List<Quotation> GetAllQuotations()
        {
            return new QuotationManagement().GetAllQuotations();
        }

        [WebMethod]
        public List<QuotationDetail> GetAllQuotationDetails()
        {
            return new QuotationManagement().GetAllQuotationDetails();
        }

        [WebMethod]
        public List<Order> GetAllOrders()
        {
            return new OrderManagement().GetAllOrders();
        }

        [WebMethod]
        public List<OrderItem> GetAllOrderItems()
        {
            return new OrderManagement().GetAllOrderItems();
        }

        [WebMethod]
        public int CreateNewOrder(Order newOrder, List<OrderItem> orderItemList)
        {
            return new OrderManagement().CreateNewOrder(newOrder, orderItemList);
        }
    }
}
